namespace AdventOfCode.Day11
{
    public delegate int CountingFunction(char[,] seatMap, int row, int col);
    public delegate int GetOccupiedSeatThreshold();

    public class RuleSet
    {
        public CountingFunction GetNumOccupiedSeats { get; set; }
        public GetOccupiedSeatThreshold GetOccupiedThreshold { get; set; }

        public int CountAdjacentOccupiedSeats(char[,] seatMap, int row, int col)
        {
            int numOccupiedSeats = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (
                            IsInBounds(row + i, col + j, seatMap.GetLength(0), seatMap.GetLength(1)) &&
                            !(i == 0 && j == 0) &&
                            seatMap[row + i, col + j] == '#'
                            )
                        numOccupiedSeats++;

            return numOccupiedSeats;
        }

        public int GetPart1OccupiedThreshold()
            => 4;

        public int CountLineOfSightOccupiedSeats(char[,] seatMap, int row, int col)
        {
            int numOccupiedSeats = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int currRow = row + i;
                    int currCol = col + j;
                    while (
                        IsInBounds(currRow, currCol, seatMap.GetLength(0), seatMap.GetLength(1))
                        )
                    {
                        char currSpace = seatMap[currRow, currCol];
                        if (currSpace == '#')
                        {
                            numOccupiedSeats++;
                            break;
                        }
                        if (currSpace == 'L')
                            break;

                        currRow += i;
                        currCol += j;
                    }
                }

            return numOccupiedSeats;
        }

        private bool IsInBounds(int currRow, int currCol, int maxRow, int maxCol)
            => (currRow >= 0 && currCol >= 0) && (currRow < maxRow && currCol < maxCol);

        public int GetPart2OccupiedThreshold()
            => 5;
    }
}