using System;
using System.Collections.Generic;

namespace AdventureGame
{
    /// <summary>
    /// A weighted edge undirected graph of all game items (that derive from Item class).
    /// Items are related by edges, and value of pairing is indicated by weight.
    /// Using an adjacency-list representation of relationships between items. 
    /// Nodes should be the number (count) of items in _itemsMasterList.
    /// </summary>

    public class Test
    {
        public void DoStuff()
        {
            Graph<Item> graph = new Graph<Item>();
            if (10 == graph.Head.Value.ID)
            {
                //Do stuff
            }
        }
    }

    public class Graph<DataType> // where DataType : Item
    {
        public class Node
        {
            public DataType Value { get; }
            public List<Edge> Edges { get; }

            public Node(DataType value)
            {
                Value = value;
                Edges = new List<Edge>();
            }

            public Edge Connect(Node node)
            {
                if (null == node)
                    return null;
                for (int i = 0; i < Edges.Count; ++i)
                {
                    if (Edges[i].GetOtherNode(this) == node)
                        return Edges[i];
                }
                var edge = new Edge(this, node);
                Edges.Add(edge);
                node.Edges.Add(edge);
                return edge;
            }

            public void Disconnect(Node node)
            {
                if (null == node)
                    return;
                for (int i = 0; i < Edges.Count; ++i)
                {
                    if (Edges[i].GetOtherNode(this) == node)
                    {
                        node.Edges.Remove(Edges[i]);
                        Edges.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        public class Edge
        {
            public Node Start { get; }
            public Node End { get; }
            public float Weight { get; set; }

            public Edge(Node start, Node end)
            {
                Start = start;
                End = end;
            }

            public Node GetOtherNode(Node node)
            {
                if (Start == node)
                    return End;
                if (End == node)
                    return Start;
                return null;
            }

            // One edge is less than the other if its weight is less.
            public int CompareTo(Edge sourceEdge, Edge targetEdge)
            {
                if (sourceEdge.Weight < targetEdge.Weight)
                {
                    return -1;
                }
                if (sourceEdge.Weight > targetEdge.Weight)
                {
                    return +1;
                }
                return 0;
            }
        }

        readonly List<Node> _nodes = new List<Node>();

        public Node Head { get; }

        public Node CreateNode(DataType value)
        {
            var node = new Node(value);
            _nodes.Add(node);
            return node;
        }

        public void DeleteNode(Node node)
        {
            if (null == node)
                return;
            int index = _nodes.IndexOf(node);
            if (index < 0)
                return;
            var edges = new List<Edge>(node.Edges);
            for (int i = 0; i < edges.Count; ++i)
            {
                Node other = edges[i].GetOtherNode(node);
                other.Disconnect(node);
            }
            _nodes.RemoveAt(index);
        }
    }
}
