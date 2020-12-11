using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Day10;

namespace tests
{
    public class Day10Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn35()
        {
            string sampleInput = @"16
                10
                15
                5
                1
                11
                7
                19
                6
                12
                4";
            string[] input = new List<string>(
                sampleInput.Split(Environment.NewLine,
                                    StringSplitOptions.TrimEntries |
                                    StringSplitOptions.RemoveEmptyEntries
                                    )
                )
                .ToArray();
            List<int> joltageData = new List<int>(Array.ConvertAll(input, s => int.Parse(s)));
            joltageData.Add(0);
            joltageData.Add(joltageData.Max() + 3);

            AdapterChain adapters = new AdapterChain(joltageData);
            (int countOf1Diffs, int countOf3Diffs) = adapters.GetJoltageDiffs();
            int product = countOf1Diffs * countOf3Diffs;

            Assert.Equal(35, product);
        }

        [Fact]
        public void Part1_WithSecondSampleInput_ShouldReturn220()
        {
            string sampleInput = @"28
                33
                18
                42
                31
                14
                46
                20
                48
                47
                24
                23
                49
                45
                19
                38
                39
                11
                1
                32
                25
                35
                8
                17
                7
                9
                4
                2
                34
                10
                3";
            string[] input = new List<string>(
                sampleInput.Split(Environment.NewLine,
                                    StringSplitOptions.TrimEntries |
                                    StringSplitOptions.RemoveEmptyEntries
                                    )
                )
                .ToArray();
            List<int> joltageData = new List<int>(Array.ConvertAll(input, s => int.Parse(s)));
            joltageData.Add(0);
            joltageData.Add(joltageData.Max() + 3);

            AdapterChain adapters = new AdapterChain(joltageData);
            (int countOf1Diffs, int countOf3Diffs) = adapters.GetJoltageDiffs();
            int product = countOf1Diffs * countOf3Diffs;

            Assert.Equal(220, product);
        }

        [Fact]
        public void Part2_WithSampleInput_ShouldReturn8()
        {
            string sampleInput = @"16
                10
                15
                5
                1
                11
                7
                19
                6
                12
                4";
            string[] input = new List<string>(
                sampleInput.Split(Environment.NewLine,
                                    StringSplitOptions.TrimEntries |
                                    StringSplitOptions.RemoveEmptyEntries
                                    )
                )
                .ToArray();
            List<int> joltageData = new List<int>(Array.ConvertAll(input, s => int.Parse(s)));
            joltageData.Add(0);
            joltageData.Add(joltageData.Max() + 3);

            AdapterChain adapters = new AdapterChain(joltageData);
            int total = adapters.CountCombinations();

            Assert.Equal(8, total);
        }

        [Fact]
        public void GraphTopSort_WithVerySmallInput_ShouldReturnReverseGraph()
        {
            Graph graph = new Graph();
            graph.AddNodes(new List<int> { 1, 3, 6, 9 });
            graph.AddEdge(graph.Nodes[0], graph.Nodes[1]);
            graph.AddEdge(graph.Nodes[1], graph.Nodes[2]);
            graph.AddEdge(graph.Nodes[2], graph.Nodes[3]);
            int numPaths = graph.GetNumPaths();

            Assert.Equal(1, numPaths);
        }

        [Fact]
        public void TestName()
        {
            Graph graph = new Graph();
            graph.AddNodes(new List<int> { 1, 3, 6, 9 });
            graph.AddEdge(graph.Nodes[0], graph.Nodes[1]);
            graph.AddEdge(graph.Nodes[0], graph.Nodes[2]);
            graph.AddEdge(graph.Nodes[1], graph.Nodes[2]);
            graph.AddEdge(graph.Nodes[2], graph.Nodes[3]);
            int numPaths = graph.GetNumPaths();

            Assert.Equal(2, numPaths);
        }
    }
}