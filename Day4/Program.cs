using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day4
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
            string[] passportsData = inputter.GetStringsFromInput();
            watch.Stop();
            timeToLoadInput = watch.ElapsedMilliseconds;

            Console.WriteLine($"Input loaded in {timeToLoadInput} ms");

            // Process Part 1
            watch.Start();
            int validPassports = ProcessInputData(passportsData, "required");
            watch.Stop();
            timeToSolvePart1 = watch.ElapsedMilliseconds - timeToLoadInput;

            Console.WriteLine($"The number of valid passports is: {validPassports}");
            Console.WriteLine($"Solved in {timeToSolvePart1} ms");

            // Process Part 2
            watch.Start();
            validPassports = ProcessInputData(passportsData, "valid");
            watch.Stop();
            timeToSolvePart2 = watch.ElapsedMilliseconds - timeToSolvePart1 - timeToLoadInput;

            Console.WriteLine($"The number of valid passports is: {validPassports}");
            Console.WriteLine($"Solved in {timeToSolvePart2} ms");

            totalTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total execution time: {totalTime} ms");
        }

        private static int ProcessInputData(string[] passportsData, string validatorFunction)
        {
            int validPassports = 0;
            PassportBuilder passportBuilder = new PassportBuilder();
            for (int i = 0; i <= passportsData.Length; i++)
            {
                if (i == passportsData.Length || IsAnEmptyLine(passportsData[i]))
                {
                    Passport passport = passportBuilder.CreatePassport();
                    passport.HackRequirements(new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" });

                    switch (validatorFunction)
                    {
                        case "required":
                            validPassports += passport.AreAllRequiredDataSet() ? 1 : 0;
                            break;
                        case "valid":
                            validPassports += passport.IsValid() ? 1 : 0;
                            break;
                    }

                    passportBuilder = new PassportBuilder();
                }
                else
                {
                    passportBuilder.AddData(passportsData[i]);
                }
            }
            return validPassports;
        }

        private static bool IsAnEmptyLine(string data)
            => String.IsNullOrEmpty(data);

    }
}
