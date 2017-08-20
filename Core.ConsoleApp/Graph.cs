using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ConsoleApp
{
    public class Graph
    {
        public Dictionary<int,Node> NodeLookup = new Dictionary<int, Node>();

        public void AddNode(int id)
        {
            if (!NodeLookup.ContainsKey(id))
                NodeLookup.Add(id,new Node(id));
        }
        public Node GetNode(int id)
        {
            if (!NodeLookup.ContainsKey(id))
                return null;

            return NodeLookup[id];
        }

        public void AddEdge(int source, int destination)
        {
            Node srcNode = GetNode(source);
            Node destNode = GetNode(destination);

            srcNode.Adjacents.AddLast(destNode);
        }

        public void Clear()
        {
            NodeLookup.Clear();
        }

        public class Node
        {
            public Node(int id)
            {
                Adjacents = new LinkedList<Node>();
                Id = id;
            }
            public int Id { get; set; }

            public LinkedList<Node> Adjacents { get; }
            
        }



    }

    
}
