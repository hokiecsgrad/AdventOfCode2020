using System;

namespace AdventOfCode.Day17
{
    public class HyperCube
    {
        public const char ON = '#';
        public const char OFF = '.';
        public char[,,,] BoardState { get; private set; }

        public HyperCube(string board)
        {
            int boardSize = (int)Math.Pow(board.Length, 1 / 2.0);
            BoardState = new char[1, 1, boardSize, boardSize];
            for (int i = 0; i < board.Length; i++)
            {
                int currY = i / boardSize;
                int currX = i % boardSize;
                BoardState[0, 0, currY, currX] = board[i];
            }
        }

        public void Tick()
        {
            GrowBoard();
            SetNewState();
        }

        public void SetNewState()
        {
            char[,,,] newState = CreateNewBoard(BoardState.GetLength(0), BoardState.GetLength(1), BoardState.GetLength(2), BoardState.GetLength(3), OFF);
            newState = CopyBoard(BoardState, newState);
            for (int w = 0; w < BoardState.GetLength(0); w++)
                for (int z = 0; z < BoardState.GetLength(1); z++)
                    for (int y = 0; y < BoardState.GetLength(2); y++)
                        for (int x = 0; x < BoardState.GetLength(3); x++)
                        {
                            int activeNeighbors = GetActiveNeighborCount(w, z, y, x);
                            if (BoardState[w, z, y, x] == ON && activeNeighbors >= 2 && activeNeighbors <= 3)
                                newState[w, z, y, x] = ON;
                            else
                                newState[w, z, y, x] = OFF;

                            if (BoardState[w, z, y, x] == OFF && activeNeighbors == 3)
                                newState[w, z, y, x] = ON;
                        }
            BoardState = CopyBoard(newState, BoardState);
        }

        public int GetActiveNeighborCount(int w, int z, int y, int x)
        {
            int neighborCount = 0;
            for (int wOffset = -1; wOffset <= 1; wOffset++)
                for (int zOffset = -1; zOffset <= 1; zOffset++)
                    for (int yOffset = -1; yOffset <= 1; yOffset++)
                        for (int xOffset = -1; xOffset <= 1; xOffset++)
                        {
                            if (w + wOffset < 0 || w + wOffset > BoardState.GetLength(0) - 1)
                                continue;
                            if (z + zOffset < 0 || z + zOffset > BoardState.GetLength(1) - 1)
                                continue;
                            if (y + yOffset < 0 || y + yOffset > BoardState.GetLength(2) - 1)
                                continue;
                            if (x + xOffset < 0 || x + xOffset > BoardState.GetLength(3) - 1)
                                continue;
                            if (wOffset == 0 && zOffset == 0 && yOffset == 0 && xOffset == 0)
                                continue;
                            if (BoardState[w + wOffset, z + zOffset, y + yOffset, x + xOffset] == ON)
                                neighborCount++;
                        }
            return neighborCount;
        }

        public int CountAllActive()
        {
            int active = 0;
            for (int w = 0; w < BoardState.GetLength(0); w++)
                for (int z = 0; z < BoardState.GetLength(1); z++)
                    for (int y = 0; y < BoardState.GetLength(2); y++)
                        for (int x = 0; x < BoardState.GetLength(3); x++)
                            if (BoardState[w, z, y, x] == ON)
                                active++;
            return active;
        }

        public void GrowBoard()
        {
            int newW = BoardState.GetLength(0);
            int newZ = BoardState.GetLength(1);
            int newY = BoardState.GetLength(2);
            int newX = BoardState.GetLength(3);

            (bool w, bool z, bool y, bool x) = ShouldGrowBoard();
            if (w || z || y || x)
            {
                if (w) newW += 2;
                if (z) newZ += 2;
                if (y) newY += 2;
                if (x) newX += 2;

                char[,,,] newBoard = CreateNewBoard(newW, newZ, newY, newX, OFF);
                BoardState = CopyBoard(BoardState, newBoard);
            }
        }

        public (bool, bool, bool, bool) ShouldGrowBoard()
        {
            bool growBoardW = false;
            bool growBoardZ = false;
            bool growBoardY = false;
            bool growBoardX = false;

            for (int w = 0; w < BoardState.GetLength(0); w++)
                for (int z = 0; z < BoardState.GetLength(1); z++)
                    for (int y = 0; y < BoardState.GetLength(2); y++)
                        for (int x = 0; x < BoardState.GetLength(3); x++)
                        {
                            if ((w == 0 || w == BoardState.GetLength(0) - 1) && BoardState[w, z, y, x] == ON)
                                growBoardW = true;
                            if ((z == 0 || z == BoardState.GetLength(1) - 1) && BoardState[w, z, y, x] == ON)
                                growBoardZ = true;
                            if ((y == 0 || y == BoardState.GetLength(2) - 1) && BoardState[w, z, y, x] == ON)
                                growBoardY = true;
                            if ((x == 0 || x == BoardState.GetLength(3) - 1) && BoardState[w, z, y, x] == ON)
                                growBoardX = true;
                        }

            return (growBoardW, growBoardZ, growBoardY, growBoardX);
        }

        private char[,,,] CreateNewBoard(int newW, int newZ, int newY, int newX, char fill)
        {
            char[,,,] newBoard = new char[newW, newZ, newY, newX];
            for (int w = 0; w < newBoard.GetLength(0); w++)
                for (int z = 0; z < newBoard.GetLength(1); z++)
                    for (int y = 0; y < newBoard.GetLength(2); y++)
                        for (int x = 0; x < newBoard.GetLength(3); x++)
                            newBoard[w, z, y, x] = fill;
            return newBoard;
        }

        private char[,,,] CopyBoard(char[,,,] source, char[,,,] dest)
        {
            char[,,,] newBoard = new char[dest.GetLength(0), dest.GetLength(1), dest.GetLength(2), dest.GetLength(3)];
            for (int w = 0; w < dest.GetLength(0); w++)
                for (int z = 0; z < dest.GetLength(1); z++)
                    for (int y = 0; y < dest.GetLength(2); y++)
                        for (int x = 0; x < dest.GetLength(3); x++)
                            newBoard[w, z, y, x] = dest[w, z, y, x];
            int wOffset = (dest.GetLength(0) - source.GetLength(0)) / 2;
            int zOffset = (dest.GetLength(1) - source.GetLength(1)) / 2;
            int yOffset = (dest.GetLength(2) - source.GetLength(2)) / 2;
            int xOffset = (dest.GetLength(3) - source.GetLength(3)) / 2;
            for (int w = 0; w < source.GetLength(0); w++)
                for (int z = 0; z < source.GetLength(1); z++)
                    for (int y = 0; y < source.GetLength(2); y++)
                        for (int x = 0; x < source.GetLength(3); x++)
                            newBoard[w + wOffset, z + zOffset, y + yOffset, x + xOffset] = source[w, z, y, x];
            return newBoard;
        }
    }
}