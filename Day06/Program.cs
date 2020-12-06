using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day6
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
            int total = ProcessInputData(data, "all");
            Console.WriteLine($"The sum where anyone in group answered questions is: {total}");
        }

        public static void Part2(string[] data)
        {
            int total = ProcessInputData(data, "unique");
            Console.WriteLine($"The sum where everyone in group answered questions is: {total}");
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