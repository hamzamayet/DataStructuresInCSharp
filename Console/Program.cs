using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            string[] coins_temp = Console.ReadLine().Split(' ');
            int[] coins = Array.ConvertAll(coins_temp, Int32.Parse);
        }
    }
}