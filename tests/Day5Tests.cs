using Xunit;
using AdventOfCode.Day5;

namespace tests
{
    public class Day5Tests
    {
        [Theory]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void GetSeatInfo_WithTestInput_ShouldCalculateData(string input, int expectedRow, int expectedCol, int expectedId)
        {
            BoardingPassParser seatCalc = new BoardingPassParser(input);

            int row = seatCalc.GetRow();
            int col = seatCalc.GetCol();
            int id = seatCalc.GetId();

            Assert.Equal(expectedRow, row);
            Assert.Equal(expectedCol, col);
            Assert.Equal(expectedId, id);
        }

        [Fact]
        public void BinaryTreeParser_WithSmallValidTree_ShouldReturn7()
        {
            BinaryTreeParser parser = new BinaryTreeParser("LRL", 'L', 'R');
            Assert.Equal(2, parser.GetValue());
        }

        [Fact]
        public void BinaryTreeParser_WithLargeValidTree_ShouldReturn44()
        {
            BinaryTreeParser parser = new BinaryTreeParser("FBFBBFF", 'F', 'B');
            Assert.Equal(44, parser.GetValue());
        }
    }
}
