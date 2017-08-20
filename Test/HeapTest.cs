using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresInCSharp;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int range = 1000;

            // Insert random values into heaps:
            Heap minHeap = new MinHeap();
            Heap maxHeap = new MaxHeap();
            Console.WriteLine("Insert Number Sequence:");
            for (int i = 0; i < range; i++)
            {
                Random rand = new Random();
                int value = (int)(rand.Next() * 100);
                minHeap.Add(value);
                maxHeap.Add(value);
                Console.WriteLine(+value + " ");
            }

            // Remove values from heaps:
            Console.WriteLine("\n\nPoll Values:\n------------\nMinHeap MaxHeap");
            for (int i = 0; i < range; i++)
            {
                Console.WriteLine("minHeap : {0}", minHeap.Poll());
                Console.WriteLine("maxHeap : {0}", maxHeap.Poll());
            }
            try
            {
                minHeap.Peek();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                maxHeap.Poll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        [TestMethod]
        public void TestPriorityHeapMedian()
        {
            int range = 10;
            List<int> source = new List<int>();
            PriorityHeap lows = new PriorityHeap(range, true);
            PriorityHeap highs = new PriorityHeap(range);
            // Insert random values into heaps:
            Random rand = new Random();
            Console.WriteLine("Insert Number Sequence:");
            for (int i = 0; i < range; i++)
            {
                int value = rand.Next(1, 100);
                source.Add(value);
                Add(lows, highs, value);
                double m = Median(lows, highs);

                Console.WriteLine(string.Join(",", source.Take(i+1)));
                Console.WriteLine("Low >> " + string.Join(",", lows.ToArray()));
                Console.WriteLine("High >> " + string.Join(",", highs.ToArray()));

                Console.WriteLine(m.ToString("0.0"));

            }
            Console.WriteLine(string.Join(",", source));
  
            Console.WriteLine("Low >> " + string.Join(",", lows.ToArray()));
            Console.WriteLine("High >> " + string.Join(",", highs.ToArray()));
        }

        [TestMethod]
        public void TestPriorityHeapMedian2()
        {
            int[] arr = Enumerable.Range(1, 10).ToArray();
            // this heap will have lower half array in maxheap order
            PriorityHeap lows = new PriorityHeap(arr.Length, true);

            //this Heap will have highier half array in minheap order
            PriorityHeap highs = new PriorityHeap(arr.Length);

            Console.WriteLine("Insert Number Sequence:");
            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
               
                Add(lows, highs, value);
                double m = Median(lows, highs);

                Console.WriteLine("actual >> " + string.Join(",", arr));
                Console.WriteLine("Low >> " + string.Join(",", lows.ToArray()));
                Console.WriteLine("High >> " + string.Join(",", highs.ToArray()));
                Console.WriteLine(m.ToString("0.0"));


            }
            Console.WriteLine(string.Join(",", arr));
            Console.WriteLine("Low >> " + string.Join(",", lows.ToArray()));
            Console.WriteLine("High >> " + string.Join(",", highs.ToArray()));
        }
        
        static void Add(PriorityHeap lows, PriorityHeap highs, int a)
        {
            if (lows.Count() == 0)
            {
                lows.Add(a);
                return;
            }

            if (a < lows.Peek())
            {
                lows.Add(a);
                if (lows.Count() > highs.Count() + 1)
                {
                    highs.Add(lows.Remove());
                }
            }
            else
            {
                highs.Add(a);
                if (highs.Count() > lows.Count() + 1)
                {
                    lows.Add(highs.Remove());
                }
            }
        }

        static double Median(PriorityHeap lows, PriorityHeap highs)
        {
            if (lows.Count() == highs.Count())
            {
                return (((double)(lows.Peek() + highs.Peek())) / 2);
            }
            if (lows.Count() > highs.Count())
            {
                return lows.Peek();
            }
            return highs.Peek();
        }


    }
}
