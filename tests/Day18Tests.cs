using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day18;

namespace tests
{
    public class Day18Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn71()
        {
            string sampleInput = "1 + 2 * 3 + 4 * 5 + 6";
            ExpressionParser expression = new ExpressionParser(sampleInput);
            expression.Parse();
            Assert.Equal(71, expression.Evaluate());
        }

        [Theory]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 26)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void Part1_WithAdditionalSamples_ShouldReturnCorrectly(string expr, long expected)
        {
            ExpressionParser expression = new ExpressionParser(expr);
            expression.Parse();
            Assert.Equal(expected, expression.Evaluate());
        }

        [Fact]
        public void Part2_WithSampleInput_ShouldReturn231()
        {
            string sampleInput = "1 + 2 * 3 + 4 * 5 + 6";
            ExpressionParser expression = new ExpressionParser(sampleInput);
            expression.ParseDifferentPrecedence();
            Assert.Equal(231, expression.Evaluate());
        }

        [Theory]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 46)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void Part2_WithAdditionalSamples_ShouldReturnCorrectly(string expr, long expected)
        {
            ExpressionParser expression = new ExpressionParser(expr);
            expression.ParseDifferentPrecedence();
            Assert.Equal(expected, expression.Evaluate());
        }
    }
}
