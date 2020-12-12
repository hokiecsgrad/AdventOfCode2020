using System;
using System.Collections.Generic;

namespace AdventOfCode.Day11
{
    public class GameOfChairs
    {
        public char[,] SeatMap { get; private set; }
        public char[,] CurrentMap { get; private set; }
        public delegate int CountingFunction(int row, int col);

        public GameOfChairs(char[,] seatMap)
        {
            SeatMap = seatMap;
            CurrentMap = new char[seatMap.GetLength(0), seatMap.GetLength(1)];
            Array.Copy(seatMap, 0, CurrentMap, 0, seatMap.Length);
        }

        public int CountAllOccupiedSeats()
        {
            int occupiedChairs = 0;
            for (int i = 0; i < SeatMap.GetLength(0); i++)
                for (int j = 0; j < SeatMap.GetLength(1); j++)
                    if (CurrentMap[i, j] == '#')
                        occupiedChairs++;
            return occupiedChairs;
        }

        public void RunRound(CountingFunction count)
        {
            char[,] newMap = new char[SeatMap.GetLength(0), SeatMap.GetLength(1)];

            for (int i = 0; i < CurrentMap.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentMap.GetLength(1); j++)
                {
                    char newState = CurrentMap[i, j] switch
                    {
                        'L' => count(i, j) == 0 ? '#' : 'L',
                        '#' => count(i, j) < 4 ? '#' : 'L',
                        _ => CurrentMap[i, j]
                    };

                    newMap[i, j] = newState;
                }
            }

            Array.Copy(newMap, 0, CurrentMap, 0, newMap.Length);
        }

        public int CountAdjacentOccupiedSeats(int row, int col)
        {
            int numOccupiedSeats = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (
                            (row + i >= 0 && col + j >= 0) &&
                            (row + i < SeatMap.GetLength(0) && col + j < SeatMap.GetLength(1)) &&
                            !(i == 0 && j == 0) &&
                            CurrentMap[row + i, col + j] == '#'
                            )
                        numOccupiedSeats++;

            return numOccupiedSeats;
        }
    }
}