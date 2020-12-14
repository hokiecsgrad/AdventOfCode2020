using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day13;

namespace tests
{
    public class Day13Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn295()
        {
            string sampleInput = @"939
                7,13,x,x,59,x,31,19";
            string[] timetable = sampleInput.Split(Environment.NewLine,
                                        StringSplitOptions.TrimEntries |
                                        StringSplitOptions.RemoveEmptyEntries
                                        );

            int earliestTime = int.Parse(timetable[0]);
            int[] schedules = timetable[1].Split(',').ToList()
                                .Where(s => s != "x")
                                .Select(s => int.Parse(s))
                                .OrderBy(s => s)
                                .ToArray();

            long minWaitId = -1;
            long minWaitTime = int.MaxValue;
            for (int i = 0; i < schedules.Length; i++)
            {
                Schedule schedule = new Schedule(schedules[i]);
                long busArrivalTime = schedule.GetNearestDepartureTimeTo(earliestTime);

                long waitTime = busArrivalTime - earliestTime;
                if (waitTime < minWaitTime)
                {
                    minWaitTime = waitTime;
                    minWaitId = schedules[i];
                }
            }

            long total = minWaitId * minWaitTime;

            Assert.Equal(295, total);
        }
    }
}
