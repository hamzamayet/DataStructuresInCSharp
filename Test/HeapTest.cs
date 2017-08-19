using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresInCSharp;
using System.Collections.Generic;

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
                minHeap.add(value);
                maxHeap.add(value);
                Console.WriteLine(+value + " ");
            }

            // Remove values from heaps:
            Console.WriteLine("\n\nPoll Values:\n------------\nMinHeap MaxHeap");
            for (int i = 0; i < range; i++)
            {
                Console.WriteLine("minHeap : {0}", minHeap.poll());
                Console.WriteLine("maxHeap : {0}", maxHeap.poll());
            }
            try
            {
                minHeap.peek();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                maxHeap.poll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void TestMedian()
        {
            int range = 10;

            List<int> list = new List<int>();
            // Insert random values into heaps:
            Heap minHeap = new MinHeap();
            Heap maxHeap = new MaxHeap();
            Console.WriteLine("Insert Number Sequence:");
            for (int i = 0; i < range; i++)
            {
                Random rand = new Random();
                int value = rand.Next() * 100;
                list.Add(value);
                minHeap.add(value);
                maxHeap.add(value);

                //double m = 
                
            }

            
        }

        private double Add(Heap minHeap, )
        {
            Heap mHeap;
            if (minHeap.IsEmpty)
                mHeap = minHeap;
            else if(maxHeap.IsEmpty)
            {

            }
        }
    }
}
