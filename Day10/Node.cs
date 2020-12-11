using System;
using System.Collections.Generic;

namespace AdventOfCode.Day10
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Edges { get; set; } = new List<Node<T>>();
        public bool HasVisited { get; set; } = false;
        public int NumPaths { get; set; } = 0;

        public Node(T value)
        {
            Value = value;
        }

        public void AddEdge(Node<T> to)
        {
            Edges.Add(to);
        }
    }
}