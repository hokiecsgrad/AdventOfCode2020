using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class AdapterChain
    {
        public List<int> Adapters { get; private set; } = new List<int>();
        public Graph<int> Graph { get; private set; } = new Graph<int>();

        public AdapterChain(List<int> adapters)
        {
            Adapters = adapters;
        }

        public (int, int) GetJoltageDiffs()
        {
            Adapters.Sort();
            int adapterIndex = 1;
            int countOf1Diffs = 0;
            int countOf3Diffs = 0;
            int joltageDiff = Adapters[adapterIndex] - Adapters[adapterIndex - 1];

            while (joltageDiff <= 3)
            {
                _ = joltageDiff switch
                {
                    1 => countOf1Diffs++,
                    3 => countOf3Diffs++,
                    _ => 0,
                };

                adapterIndex++;
                if (adapterIndex >= Adapters.Count) break;
                joltageDiff = Adapters[adapterIndex] - Adapters[adapterIndex - 1];
            }

            return (countOf1Diffs, countOf3Diffs);
        }

        public long CountCombinations()
        {
            Adapters.Sort();
            Graph = BuildGraph();
            long paths = Graph.GetNumPaths();
            return paths;
        }

        private Graph<int> BuildGraph()
        {
            Graph<int> graph = new Graph<int>();
            graph.AddNodes(Adapters);
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                Node<int> node = graph.Nodes[i];
                int lookAhead = 1;
                while ((i + lookAhead) < graph.Nodes.Count
                        && graph.Nodes[i + lookAhead].Value - node.Value <= 3)
                {
                    node.AddEdge(graph.Nodes[i + lookAhead]);
                    lookAhead++;
                }
            }
            return graph;
        }
    }
}