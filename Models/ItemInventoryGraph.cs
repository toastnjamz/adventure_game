using System;
using System.Collections.Generic;

namespace AdventureGame
{
    /// <summary>
    /// A weighted edge undirected graph of player inventory items.
    /// Items are related by edges, and value of pairing is indicated by weight.
    /// Using an adjacency-list representation of relationships between items. 
    /// </summary>

    public class ItemInventoryGraph
    {
        public class Vertex
        {
            public int Index { get; set; }
            public int ItemID { get; private set; }
            public string ItemName { get; private set; }
            public List<Vertex> Neighbors { get; private set; }

            public Vertex(int itemID, string itemName)
            {
                ItemID = itemID;
                ItemName = itemName;
                Neighbors = new List<Vertex>();
            }
        }

        public class Edge
        {
            private readonly int _sourceVertex;
            private readonly int _targetVertex;
            private readonly double _weight;

            public Edge(int sourceVertex, int targetVertex, double weight)
            {
                _sourceVertex = sourceVertex;
                _targetVertex = targetVertex;
                _weight = weight;
            }

            public int SourceVertex()
            {
                return _sourceVertex;
            }

            // Can you compare two items like this?
            public int TargetVertex(int vertex)
            {
                if (vertex == _sourceVertex)
                {
                    return _targetVertex;
                }
                if (vertex == _targetVertex)
                {
                    return _sourceVertex;
                }
                throw new Exception("Illegal endpoint.");
            }

            public double Weight()
            {
                return _weight;
            }

            // Compares two edges.
            // One edge is less than the other if its weight is less.
            public int CompareTo(Edge sourceEdge, Edge targetEdge)
            {
                if (sourceEdge.Weight() < targetEdge.Weight())
                {
                    return -1;
                }
                if (sourceEdge.Weight() > targetEdge.Weight())
                {
                    return +1;
                }
                return 0;
            }

            // String representation of the graph
            public string GraphToString()
            {
                return string.Format("{0:d}-{1:d} {2:f5}", _sourceVertex.ID, _targetVertex.ID, _weight);
            }
        }

        public class Graph
        {
            private int _numberOfVertices;
            private int _numberOfEdges;
            private LinkedList<Edge>[] _adjacencyList;  //Using a linked list for adjacency-list representation.

            // Verticies is the number (count) of items in _itemsMasterList 
            public Graph(int Vertices)
            {
                if (Vertices < 0)
                {
                    throw new Exception("Number of vertices must be non-negative");
                }
                _numberOfVertices = Vertices;
                _numberOfEdges = 0;
                _adjacencyList = new LinkedList<Edge>[Vertices];

                for (int i = 0; i < Vertices; i++)
                {
                    _adjacencyList[i] = new LinkedList<Edge>();
                }
            }

            public int NumberOfVerticies()
            {
                return _numberOfVertices;
            }

            public int NumberOfEdges()
            {
                return _numberOfEdges;
            }

            // Since this is an undirected graph, adding new edge to each vertice's adjacency list.
            public void AddEdge(Edge edge)
            {
                int sourceVertex = edge.SourceVertex();
                int targetVertex = edge.TargetVertex(sourceVertex);
                _adjacencyList[sourceVertex].AddFirst(edge);
                _adjacencyList[targetVertex].AddFirst(edge);
                _numberOfEdges++;
            }

            // Return edges for a specific vertex
            public IEnumerable<Edge> Adj(int vertex)
            {
                return _adjacencyList[vertex];
            }

            // TODO: Return all edges in the graph
        }
    }
}
