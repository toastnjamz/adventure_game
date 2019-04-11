//using System.Collections;
//using System.Collections.Generic;

//namespace AdventureGame
//{
//    /// <summary>
//    /// Trying to create a weighted undirected graph using generics.
//    /// Update: it's not working.
//    /// </summary>

//    public class GraphExperiment
//    {
//        public class Vertex<Item>
//        {
//            private Item _itemData;
//            private VertexList<Item> _neighbors = null;
//            private List<int> costs;

//            public Vertex(Item itemData)
//            {
//                _itemData = itemData;
//            }

//            public Vertex(Item itemData, VertexList<Item> Neighbors)
//            {
//                _itemData = itemData;
//                _neighbors = Neighbors;
//            }
//        }

//        public class VertexList<T> : ICollection<Item>
//        {
//            public VertexList() : base() { }

//            public VertextList(int initialSize)
//            {
//                // Add a specified number of items
//                for (int i = 0; i < initialSize; i++)
//                {
//                    base.Items.Add(default(Vertex<Item>));
//                }
//            }
//        }
//    }
//}
