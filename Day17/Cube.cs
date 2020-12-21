using System;

namespace AdventOfCode.Day17
{
    public class Cube
    {
        public const char ON = '#';
        public const char OFF = '.';
        public char[,,] BoardState { get; private set; }
        public int[,,] Neighbors { get; private set; }

        public Cube(string board)
        {
            int boardSize = (int)Math.Pow(board.Length, 1 / 2.0);
            BoardState = new char[1, boardSize, boardSize];
            for (int i = 0; i < board.Length; i++)
            {
                int currY = i / boardSize;
                int currX = i % boardSize;
                BoardState[0, currY, currX] = board[i];
            }
        }

        public void Tick()
        {
            GrowBoard();
            SetNewState();
        }

        public void SetNewState()
        {
            char[,,] newState = CreateNewBoard(BoardState.GetLength(0), BoardState.GetLength(1), BoardState.GetLength(2), OFF);
            newState = CopyBoard(BoardState, newState);
            for (int z = 0; z < BoardState.GetLength(0); z++)
                for (int y = 0; y < BoardState.GetLength(1); y++)
                    for (int x = 0; x < BoardState.GetLength(2); x++)
                    {
                        int activeNeighbors = GetActiveNeighborCount(z, y, x);
                        if (BoardState[z, y, x] == ON && activeNeighbors >= 2 && activeNeighbors <= 3)
                            newState[z, y, x] = ON;
                        else
                            newState[z, y, x] = OFF;

                        if (BoardState[z, y, x] == OFF && activeNeighbors == 3)
                            newState[z, y, x] = ON;
                    }
            BoardState = CopyBoard(newState, BoardState);
        }

        public int GetActiveNeighborCount(int z, int y, int x)
        {
            int neighborCount = 0;
            for (int zOffset = -1; zOffset <= 1; zOffset++)
                for (int yOffset = -1; yOffset <= 1; yOffset++)
                    for (int xOffset = -1; xOffset <= 1; xOffset++)
                    {
                        if (zOffset == 0 && yOffset == 0 && xOffset == 0)
                            continue;
                        if (z + zOffset < 0 || z + zOffset > BoardState.GetLength(0) - 1)
                            continue;
                        if (y + yOffset < 0 || y + yOffset > BoardState.GetLength(1) - 1)
                            continue;
                        if (x + xOffset < 0 || x + xOffset > BoardState.GetLength(2) - 1)
                            continue;
                        if (BoardState[z + zOffset, y + yOffset, x + xOffset] == ON)
                            neighborCount++;
                    }
            return neighborCount;
        }

        public int CountAllActive()
        {
            int active = 0;
            for (int z = 0; z < BoardState.GetLength(0); z++)
                for (int y = 0; y < BoardState.GetLength(1); y++)
                    for (int x = 0; x < BoardState.GetLength(2); x++)
                        if (BoardState[z, y, x] == ON)
                            active++;
            return active;
        }

        public void GrowBoard()
        {
            int newZ = BoardState.GetLength(0);
            int newY = BoardState.GetLength(1);
            int newX = BoardState.GetLength(2);

            (bool z, bool y, bool x) = ShouldGrowBoard();
            if (z || y || x)
            {
                if (z) newZ += 2;
                if (y) newY += 2;
                if (x) newX += 2;

                char[,,] newBoard = CreateNewBoard(newZ, newY, newX, OFF);
                BoardState = CopyBoard(BoardState, newBoard);
            }
        }

        public (bool, bool, bool) ShouldGrowBoard()
        {
            bool growBoardZ = false;
            bool growBoardY = false;
            bool growBoardX = false;

            for (int z = 0; z < BoardState.GetLength(0); z++)
                for (int y = 0; y < BoardState.GetLength(1); y++)
                    for (int x = 0; x < BoardState.GetLength(2); x++)
                    {
                        if ((z == 0 || z == BoardState.GetLength(0) - 1) && BoardState[z, y, x] == ON)
                            growBoardZ = true;
                        if ((y == 0 || y == BoardState.GetLength(1) - 1) && BoardState[z, y, x] == ON)
                            growBoardY = true;
                        if ((x == 0 || x == BoardState.GetLength(2) - 1) && BoardState[z, y, x] == ON)
                            growBoardX = true;
                    }

            return (growBoardZ, growBoardY, growBoardX);
        }

        private char[,,] CreateNewBoard(int newZ, int newY, int newX, char fill)
        {
            char[,,] newBoard = new char[newZ, newY, newX];
            for (int z = 0; z < newBoard.GetLength(0); z++)
                for (int y = 0; y < newBoard.GetLength(1); y++)
                    for (int x = 0; x < newBoard.GetLength(2); x++)
                        newBoard[z, y, x] = fill;
            return newBoard;
        }

        private char[,,] CopyBoard(char[,,] source, char[,,] dest)
        {
            char[,,] newBoard = new char[dest.GetLength(0), dest.GetLength(1), dest.GetLength(2)];
            for (int z = 0; z < dest.GetLength(0); z++)
                for (int y = 0; y < dest.GetLength(1); y++)
                    for (int x = 0; x < dest.GetLength(2); x++)
                        newBoard[z, y, x] = dest[z, y, x];
            int zOffset = (dest.GetLength(0) - source.GetLength(0)) / 2;
            int yOffset = (dest.GetLength(1) - source.GetLength(1)) / 2;
            int xOffset = (dest.GetLength(2) - source.GetLength(2)) / 2;
            for (int z = 0; z < source.GetLength(0); z++)
                for (int y = 0; y < source.GetLength(1); y++)
                    for (int x = 0; x < source.GetLength(2); x++)
                        newBoard[z + zOffset, y + yOffset, x + xOffset] = source[z, y, x];
            return newBoard;
        }
    }
}