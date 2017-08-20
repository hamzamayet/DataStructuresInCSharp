using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresInCSharp
{
    public class Tree
    {
        public List<TreeNode> Nodes;
        public List<int> Weights;
        public int RootId;

        public Tree()
        {
            this.Nodes = new List<TreeNode>();
            this.Weights = new List<int>();
            this.RootId = 0;
        }

        public void AddNode(int id)
        {
            this.Nodes.Add(new TreeNode(id));
            this.Weights.Add(0);
        }

        public void AddEdge(int u, int v)
        {
            this.Nodes[u].Edges.Add(v);
            this.Nodes[v].Edges.Add(u);
        }

        public void SetRoot(int id)
        {
            this.RootId = id;
        }

        public void SetNodeVisited(int id)
        {
            this.Nodes[id].Visited = true;
        }
    }
    public class TreeNode
    {
        public int Id;
        public bool Visited;
        public List<int> Edges;

        public TreeNode(int id)
        {
            this.Id = id;
            this.Visited = false;
            this.Edges = new List<int>();
        }
    }
}
