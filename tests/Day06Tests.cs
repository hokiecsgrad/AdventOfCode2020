using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Day6;

namespace tests
{
    public class Day06Tests
    {
        [Fact]
        public void SumCountPart1_WithTestInput_ShouldReturn11()
        {
            string testInput = @"abc

                a
                b
                c

                ab
                ac

                a
                a
                a
                a

                b";
            string[] customsData = new List<string>(
                    testInput.Split(Environment.NewLine)
                )
                .Select(s => s.Trim())
                .ToArray();

            int uniqueCustomsAnswers = 0;
            CustomsBuilder customsBuilder = new CustomsBuilder();
            for (int i = 0; i <= customsData.Length; i++)
            {
                if (i == customsData.Length || IsAnEmptyLine(customsData[i]))
                {
                    CustomsForm form = customsBuilder.CreateForm();
                    uniqueCustomsAnswers += form.GetAllAnswersInGroup();
                    customsBuilder = new CustomsBuilder();
                }
                else
                {
                    customsBuilder.AddAnswersToGroup(customsData[i]);
                }
            }

            Assert.Equal(11, uniqueCustomsAnswers);
        }

        [Fact]
        public void SumCountPart2_WithTestInput_ShouldReturn6()
        {
            string testInput = @"abc

                a
                b
                c

                ab
                ac

                a
                a
                a
                a

                b";
            string[] customsData = new List<string>(
                    testInput.Split(Environment.NewLine)
                )
                .Select(s => s.Trim())
                .ToArray();

            int uniqueCustomsAnswers = 0;
            CustomsBuilder customsBuilder = new CustomsBuilder();
            for (int i = 0; i <= customsData.Length; i++)
            {
                if (i == customsData.Length || IsAnEmptyLine(customsData[i]))
                {
                    CustomsForm form = customsBuilder.CreateForm();
                    uniqueCustomsAnswers += form.GetUniqueAnswersInGroup();
                    customsBuilder = new CustomsBuilder();
                }
                else
                {
                    customsBuilder.AddAnswersToGroup(customsData[i]);
                }
            }

            Assert.Equal(6, uniqueCustomsAnswers);
        }

        [Fact]
        public void CustomsCountAll_WithOneSimplePassenger_ShouldReturn3()
        {
            List<HashSet<char>> data = new List<HashSet<char>> { new HashSet<char>() { 'a', 'b', 'c' } };
            CustomsForm form = new CustomsForm(data);

            Assert.Equal(3, form.GetAllAnswersInGroup());
        }

        [Fact]
        public void CustomsCountAll_WithTwoSimplePassengers_ShouldReturn4()
        {
            List<HashSet<char>> data = new List<HashSet<char>> {
                new HashSet<char>() { 'a', 'b', 'c' },
                new HashSet<char>() { 'd' }
                };
            CustomsForm form = new CustomsForm(data);

            Assert.Equal(4, form.GetAllAnswersInGroup());
        }

        [Fact]
        public void CustomsCountAll_WithThreeComplexPassengers_ShouldReturn9()
        {
            List<HashSet<char>> data = new List<HashSet<char>> {
                new HashSet<char>() { 'a', 'b', 'c' },
                new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f' },
                new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'x', 'y', 'z' },
                };
            CustomsForm form = new CustomsForm(data);

            Assert.Equal(9, form.GetAllAnswersInGroup());
        }

        [Fact]
        public void CustomsCountUnique_WithOneSimplePassenger_ShouldReturn2()
        {
            List<HashSet<char>> data = new List<HashSet<char>> { new HashSet<char>() { 'a', 'b' } };
            CustomsForm form = new CustomsForm(data);

            Assert.Equal(2, form.GetUniqueAnswersInGroup());
        }

        [Fact]
        public void CustomsCountUnique_WithThreeComplexPassengers_ShouldReturn3()
        {
            List<HashSet<char>> data = new List<HashSet<char>> {
                new HashSet<char>() { 'a', 'b', 'c' },
                new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f' },
                new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'x', 'y', 'z' },
                };
            CustomsForm form = new CustomsForm(data);

            Assert.Equal(3, form.GetUniqueAnswersInGroup());
        }

        private bool IsAnEmptyLine(string data)
            => String.IsNullOrEmpty(data);
    }
}