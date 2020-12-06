using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            InputGetter input = new InputGetter("input.txt");

            ProgramFramework framework = new ProgramFramework();
            framework.InputHandler = input.GetStringsFromInput;
            framework.Part1Handler = Part1;
            framework.Part2Handler = Part2;
            framework.RunProgram();
        }

        public static void Part1(string[] data)
        {
            int total = ProcessInputData(data, "required");
            Console.WriteLine($"The number of valid passports with all required data is: {total}");
        }

        public static void Part2(string[] data)
        {
            int total = ProcessInputData(data, "valid");
            Console.WriteLine($"The number of valid passports is: {total}");
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
