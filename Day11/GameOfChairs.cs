using System;
using System.Collections.Generic;

namespace AdventOfCode.Day11
{
    public class GameOfChairs
    {
        private const char Floor = '.';
        private const char EmptySeat = 'L';
        private const char OccupiedSeat = '#';

        public RuleSet Rules { get; private set; }

        public char[,] SeatMap { get; private set; }
        public char[,] CurrentMap { get; private set; }

        public GameOfChairs(char[,] seatMap, RuleSet rules)
        {
            SeatMap = seatMap;
            CurrentMap = new char[seatMap.GetLength(0), seatMap.GetLength(1)];
            Array.Copy(seatMap, 0, CurrentMap, 0, seatMap.Length);

            Rules = rules;
        }

        public int CountAllOccupiedSeats()
        {
            int occupiedChairs = 0;
            for (int i = 0; i < SeatMap.GetLength(0); i++)
                for (int j = 0; j < SeatMap.GetLength(1); j++)
                    if (CurrentMap[i, j] == OccupiedSeat)
                        occupiedChairs++;
            return occupiedChairs;
        }

        public void RunRound()
        {
            char[,] newMap = new char[SeatMap.GetLength(0), SeatMap.GetLength(1)];

            for (int i = 0; i < CurrentMap.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentMap.GetLength(1); j++)
                {
                    char newState = CurrentMap[i, j] switch
                    {
                        EmptySeat
                            =>
                                Rules.GetNumOccupiedSeats(CurrentMap, i, j) == 0
                                ? OccupiedSeat : EmptySeat,
                        OccupiedSeat
                            =>
                                Rules.GetNumOccupiedSeats(CurrentMap, i, j) < Rules.GetOccupiedThreshold()
                                ? OccupiedSeat : EmptySeat,
                        _ => CurrentMap[i, j]
                    };

                    newMap[i, j] = newState;
                }
            }

            Array.Copy(newMap, 0, CurrentMap, 0, newMap.Length);
        }
    }
}