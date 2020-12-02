using System;
using Xunit;
using AdventOfCode.Day1;


namespace tests
{
    public class Day1Tests
    {
        [Fact]
        public void FindTwoNums_WithDefaultInput_ShouldReturn1721And299()
        {
            int[] testInput = new int[] {1721, 979, 366, 299, 675, 1456};
            NumbersArray numbers = new NumbersArray(testInput);

            int num1 = 0;
            int num2 = 0;

            (num1, num2) = numbers.GetTwoNumbersThatSumTo2020();
            Assert.Equal(1721, num1);
            Assert.Equal(299, num2);
        }

        [Fact]
        public void FindThreeNums_WithDefaultInput_ShouldReturn979And366And675()
        {
            int[] testInput = new int[] {1721, 979, 366, 299, 675, 1456};
            NumbersArray numbers = new NumbersArray(testInput);

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;

            (num1, num2, num3) = numbers.GetThreeNumbersThatSumTo2020();
            Assert.Equal(979, num1);
            Assert.Equal(366, num2);
            Assert.Equal(675, num3);
        }
    }
}
