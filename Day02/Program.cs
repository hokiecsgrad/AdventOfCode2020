using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day2
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
            string[] input = inputter.GetStringsFromInput();
            watch.Stop();
            timeToLoadInput = watch.ElapsedMilliseconds;
            Console.WriteLine($"Input loaded in {timeToLoadInput} ms");

            watch.Start();
            int total = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string raw = input[i];
                RuleParser ruleParser = new RuleParser();
                ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));
                PasswordValidator passValidator = new PasswordValidator(ruleParser, raw.Substring(raw.IndexOf(':')));
                if (passValidator.IsPart1Valid())
                    total += 1;
            }
            watch.Stop();
            timeToSolvePart1 = watch.ElapsedMilliseconds - timeToLoadInput;

            Console.WriteLine($"The number of passwords that are valid: {total}");
            Console.WriteLine($"Solved in {timeToSolvePart1} ms");

            watch.Start();
            total = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string raw = input[i];
                RuleParser ruleParser = new RuleParser();
                ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));
                PasswordValidator passValidator = new PasswordValidator(ruleParser, raw.Substring(raw.IndexOf(':')));
                if (passValidator.IsPart2Valid())
                    total += 1;
            }
            watch.Stop();
            timeToSolvePart2 = watch.ElapsedMilliseconds - timeToSolvePart1 - timeToLoadInput;

            Console.WriteLine($"The number of passwords that are valid: {total}");
            Console.WriteLine($"Solved in {timeToSolvePart2} ms");

            totalTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total execution time: {totalTime} ms");
        }
    }
}
