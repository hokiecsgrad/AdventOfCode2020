using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; private set; } = new List<Node<T>>();
        public List<Node<T>> Sorted { get; private set; } = new List<Node<T>>();

        public void AddNodes(List<T> nodeValues)
        {
            foreach (T value in nodeValues)
                AddNode(new Node<T>(value));
        }

        public void AddNode(Node<T> node)
        {
            Nodes.Add(node);
        }

        public void AddEdge(Node<T> from, Node<T> to)
        {
            from.AddEdge(to);
        }

        public long GetNumPaths()
        {
            TopologicalSort();
            Sorted[0].NumPaths = 1;

            for (int i = 1; i < Sorted.Count; i++)
                Sorted[i].NumPaths = Sorted[i].Edges.Sum(e => e.NumPaths);

            return Sorted[Sorted.Count - 1].NumPaths;
        }

        // With the help of 
        // Data Structures and Algorithm Analysis by Dr. Clifford A Shaffer
        // Chapter 7: Graphs, Page 203 (Topological Sort), Section 7.3.3
        // I apologize for all the terrible things I said about your class in 1997.
        public void TopologicalSort()
        {
            for (int i = 0; i < Nodes.Count; i++)
                Nodes[i].HasVisited = false;

            for (int i = 0; i < Nodes.Count; i++)
                if (!Nodes[i].HasVisited)
                    TopSortHelper(Nodes[i]);
        }

        private void TopSortHelper(Node<T> node)
        {
            node.HasVisited = true;
            for (int i = 0; i < node.Edges.Count; i++)
            {
                if (!node.Edges[i].HasVisited)
                    TopSortHelper(node.Edges[i]);
            }
            Sorted.Add(node);
        }
    }
}