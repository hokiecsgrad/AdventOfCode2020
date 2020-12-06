using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day2
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
            int total = ProcessData(data, "part1");
            Console.WriteLine($"The number of passwords that are valid: {total}");
        }

        public static void Part2(string[] data)
        {
            int total = ProcessData(data, "part2");
            Console.WriteLine($"The number of passwords that are valid: {total}");
        }

        private static int ProcessData(string[] data, string validatorFunction)
        {
            int total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                string raw = data[i];
                RuleParser ruleParser = new RuleParser();
                ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));
                PasswordValidator passValidator = new PasswordValidator(
                                                        ruleParser,
                                                        raw.Substring(raw.IndexOf(':'))
                                                        );
                if (validatorFunction == "part1" && passValidator.IsPart1Valid())
                    total += 1;
                else if (validatorFunction == "part2" && passValidator.IsPart2Valid())
                    total += 1;
            }
            return total;
        }
    }
}
