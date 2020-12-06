using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            long totalTime = 0;
            long timeToLoadInput = 0;
            long timeToSolvePart1 = 0;
            long timeToSolvePart2 = 0;

            watch.Start();
            InputGetter inputter = new InputGetter("input.txt");
            string[] customsData = inputter.GetStringsFromInput();
            watch.Stop();
            timeToLoadInput = watch.ElapsedMilliseconds;

            Console.WriteLine($"Input loaded in {timeToLoadInput} ms");

            // Process Part 1
            watch.Start();
            int sumOfCustomsAnswers = ProcessInputData(customsData, "all");
            watch.Stop();
            timeToSolvePart1 = watch.ElapsedMilliseconds - timeToLoadInput;

            Console.WriteLine($"The sum where anyone in group answered questions is: {sumOfCustomsAnswers}");
            Console.WriteLine($"Solved in {timeToSolvePart1} ms");

            // Process Part 2
            watch.Start();
            sumOfCustomsAnswers = ProcessInputData(customsData, "unique");
            watch.Stop();
            timeToSolvePart2 = watch.ElapsedMilliseconds - timeToSolvePart1 - timeToLoadInput;

            Console.WriteLine($"The sum where everyone in group answered questions is: {sumOfCustomsAnswers}");
            Console.WriteLine($"Solved in {timeToSolvePart2} ms");

            totalTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total execution time: {totalTime} ms");
        }

        private static int ProcessInputData(string[] customsData, string validatorFunction)
        {
            int uniqueCustomsAnswers = 0;
            CustomsBuilder customsBuilder = new CustomsBuilder();
            for (int i = 0; i <= customsData.Length; i++)
            {
                if (i == customsData.Length || IsAnEmptyLine(customsData[i]))
                {
                    CustomsForm form = customsBuilder.CreateForm();
                    if (validatorFunction == "all")
                        uniqueCustomsAnswers += form.GetAllAnswersInGroup();
                    else if (validatorFunction == "unique")
                        uniqueCustomsAnswers += form.GetUniqueAnswersInGroup();
                    customsBuilder = new CustomsBuilder();
                }
                else
                {
                    customsBuilder.AddAnswersToGroup(customsData[i]);
                }
            }
            return uniqueCustomsAnswers;
        }

        private static bool IsAnEmptyLine(string data)
            => String.IsNullOrEmpty(data);

    }
}
