using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class Graph
    {
        public List<Node<int>> Nodes { get; private set; } = new List<Node<int>>();
        public List<Node<int>> Sorted { get; private set; } = new List<Node<int>>();

        public void AddNodes(List<int> nodeValues)
        {
            foreach (int value in nodeValues)
                AddNode(new Node<int>(value));
        }

        public void AddNode(Node<int> node)
        {
            Nodes.Add(node);
        }

        public void AddEdge(Node<int> from, Node<int> to)
        {
            from.AddEdge(to);
        }

        public int GetNumPaths()
        {
            TopologicalSort();
            Sorted[0].NumPaths = 1;
            for (int i = 1; i < Sorted.Count; i++)
            {
                Sorted[i].NumPaths = Sorted[i].NumPaths + (Sorted[i].Edges.Count * Sorted[i - 1].NumPaths);
            }
            return Sorted[Sorted.Count - 1].NumPaths;
        }

        public void TopologicalSort()
        {
            for (int i = 0; i < Nodes.Count; i++)
                Nodes[i].HasVisited = false;

            for (int i = 0; i < Nodes.Count; i++)
                if (!Nodes[i].HasVisited)
                    TopSort(Nodes[i]);
        }

        private void TopSort(Node<int> node)
        {
            node.HasVisited = true;
            for (int i = 0; i < node.Edges.Count; i++)
            {
                if (!node.Edges[i].HasVisited)
                    TopSort(node.Edges[i]);
            }
            Sorted.Add(node);
        }

        private int CountPathsUtil(Node<int> source, Node<int> dest, int pathCount)
        {
            if (source == dest)
                pathCount++;
            else
                foreach (Node<int> edge in source.Edges)
                    pathCount = CountPathsUtil(edge, dest, pathCount);

            return pathCount;
        }

        public Node<int> GetNodeByValue(int value)
        {
            foreach (Node<int> node in Nodes)
                if (node.Value == value)
                    return node;
            return null;
        }
    }
}