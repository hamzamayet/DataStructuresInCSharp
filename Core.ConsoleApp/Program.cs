using DataStructuresInCSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // DP: Coin Change Problem
            //DP_CoinChange(args);


            // Graph Search
            //GraphSearch(args);


            List<string> str = new List<string>();

            str.FindIndex()
            Console.ReadLine();

        }

        #region DP Coin Change

        //https://www.hackerrank.com/challenges/ctci-coin-change/problem
        private static void DP_CoinChange(string[] args)
        {
            string[] tokensN = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokensN[0]);
            int m = Convert.ToInt32(tokensN[1]);
            string[] coins_temp = Console.ReadLine().Split(' ');
            //int[] coins = Array.ConvertAll(coins_temp, Int32.Parse);
            int[] coins = coins_temp.Select(a => Int32.Parse(a)).ToArray();

            long sum = CalculatePossibilities(coins, n);
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        private static long CalculatePossibilities(int[] coins, int money)
        {
            long[] dp = new long[money + 1]; // O(N) space.
            dp[0] = 1;    // n == 0 case.
            foreach (int coin in coins)
            {
                for (int j = coin; j < dp.Length; j++)
                {
                    // The only tricky step.
                    dp[j] += dp[j - coin];
                }
            }
            return dp[money];
        }
        #endregion

        #region Graph Search

        //static void GraphSearch(string[] args)
        //{
        //    Graph graph = new Graph();
        //    int q = int.Parse(Console.ReadLine());
        //    for (int i = 0; i < q; i++)
        //    {
        //        string[] tokensN = Console.ReadLine().Split(' ');
        //        int noOfNode = int.Parse(tokensN[0]);
        //        int noOfEdge = int.Parse(tokensN[1]);
        //        for (int k = 1; k <= noOfNode; k++)
        //        {
        //            graph.AddNode(k);
        //        }
        //        for (int j = 0; j < noOfEdge; j++)
        //        {
        //            string[] connecting = Console.ReadLine().Split(' ');
        //            int nodeA = int.Parse(connecting[0]);
        //            int nodeB = int.Parse(connecting[1]);
        //            graph.AddEdge(nodeA, nodeB);
        //        }
        //        int s = int.Parse(Console.ReadLine());



        //    }

        //}

        static void GraphSearch(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            // List of Node, where the index is the id, and where Node has a collection of Nodes (representing edges).
            // Both nodes that are on the edge contain it in their collection

            //read in q
            int q = Int32.Parse(Console.ReadLine());
            //for each q...
            for (int qi = 0; qi < q; qi++)
            {
                Tree t = new Tree();
                t.AddNode(0); //buffer to align IDs
                              //...read in n and m
                String[] nandm = Console.ReadLine().Split(' ');
                int n = Int32.Parse(nandm[0]);
                int m = Int32.Parse(nandm[1]);
                //for each n
                for (int ni = 0; ni < n; ni++)
                {
                    //...add Node to list
                    int d = ni + 1;
                    t.AddNode(d);
                }
                //for each m
                for (int mi = 0; mi < m; mi++)
                {
                    //...read in u and v
                    String[] uandv = Console.ReadLine().Split(' ');
                    int u = Int32.Parse(uandv[0]);
                    int v = Int32.Parse(uandv[1]);
                    //...add edges by adding Node u to Node v's edge collection and vice versa
                    t.AddEdge(u, v);
                }

                //read in s
                int s = Int32.Parse(Console.ReadLine());
                //initialize list of integers representing weight to each other node (by index)
                //BFS from s through Node (skipping first and s) (also skipping items that were visited) Since it's BFS and every edge is the same weight, we will always hit the closest connection first. Update the entry in the weight list
                Queue<Tuple<int, int>> toCheck = new Queue<Tuple<int, int>>();
                toCheck.Enqueue(new Tuple<int, int>(s, 0));
                while (toCheck.Count > 0)
                {
                    Tuple<int, int> thisCheck = toCheck.Dequeue();
                    int nodeId = thisCheck.Item1;
                    int thisWeight = thisCheck.Item2;

                    t.Weights[nodeId] = thisWeight;
                    foreach (int childId in t.Nodes[nodeId].Edges)
                    {
                        if (!t.Nodes[childId].Visited)
                        { //don't revisit my parent or other previously visited nodes
                            t.SetNodeVisited(childId);
                            toCheck.Enqueue(new Tuple<int, int>(childId, thisWeight + 6));
                        }
                    }
                }

                //for each weight (skipping index s), output to console space-separatedly. If weight is 0, output -1.
                StringBuilder outputsb = new StringBuilder();
                for (int wi = 0; wi < t.Weights.Count; wi++)
                {
                    if (wi != 0 && wi != s)
                    {
                        outputsb.Append(t.Weights[wi] != 0 ? t.Weights[wi] : -1);
                        outputsb.Append(" ");
                    }
                }
                Console.WriteLine(outputsb.ToString());
            }

        }

        #endregion


        #region AmazonTest


        #endregion

    }


}