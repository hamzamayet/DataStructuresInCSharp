
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresInCSharp
{
    public class PriorityHeap
    {
        private int[] _items;
        private int _size;
        private int _capacity;
        private readonly Func<int, int, bool> _compare;

        /// <summary>
        /// Return true if item value is smaller than parent value
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private bool MinHeapCompare(int item, int parent)
        {
            if (item < parent)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if Parent value is smaller than item value
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private bool MaxHeapCompare(int item, int parent)
        {
            if (parent < item)
                return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity">initial capacity of the array</param>
        /// <param name="maxheap">If true priority will be based on max value rather than min value</param>

        public PriorityHeap(int capacity, bool maxheap = false)
        {
            _items = new int[capacity];
            _size = 0;
            _capacity = capacity;
            _compare = MinHeapCompare;
            if (maxheap)
            {
                _compare = MaxHeapCompare;
            }
        }

        private void HeapifyUp()
        {
            int i = _size - 1;
            while (HasParent(i) && _compare(_items[i], _items[ParentIndex(i)]))
            {
                Swap(i, ParentIndex(i));
                i = ParentIndex(i);
            }
        }

        private void HeapifyDown()
        {
            int i = 0;
            while (HasLeftChild(i))
            {
                int small = LeftChildIndex(i);
                if (HasRightChild(i) && _compare(_items[RightChildIndex(i)], _items[small])) { small = RightChildIndex(i); }
                if (_compare(_items[i], _items[small])) break;
                Swap(i, small);
                i = small;
            }
        }

        private int LeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int RightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int ParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) < _size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) < _size;
        }

        private bool HasParent(int index)
        {
            //return ParentIndex(index) >= 0;
            return index >= 0;
        }

        private void Swap(int i, int j)
        {
            int temp = _items[i];
            _items[i] = _items[j];
            _items[j] = temp;
        }

        private void EnsureCapacity()
        {
            if (_size == _capacity)
            {
                _capacity = _capacity << 1;
                int[] newitems = new int[_capacity];
                Array.Copy(_items, 0, newitems, 0, _size);
            }
        }

        public void Add(int item)
        {
            // Resize underlying array if it's not large enough for insertion
            EnsureCapacity();

            // Insert value at the next open location in heap
            _items[_size] = item;
            _size++;

            // Correct order property
            HeapifyUp();
        }

        public int Count()
        {
            return _size;
        }

        public int Peek()
        {
            if (_items.Length == 0) throw new ArgumentOutOfRangeException();
            return _items[0];
        }

        public int Remove()
        {
            int temp = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();
            return temp;
        }

        public int LeftChild(int index)
        {
            return _items[LeftChildIndex(index)];
        }

        public int RightChild(int index)
        {
            return _items[RightChildIndex(index)];
        }

        public int Parent(int index)
        {
            return _items[ParentIndex(index)];
        }

        public void CopyTo(Array array, int index)
        {
            Array.Copy(_items, 0, array, 0, _size);
        }

        public void Clear()
        {
            _items = new int[_capacity];
            _size = 0;
        }

        public int[] ToArray()
        {
            
            int[] arr = new int[_size];
            Array.Copy(_items, 0, arr,0,_size);

            return arr;
        }

    }

    //class Solution
    //{

    //    static void add(PriorityHeap lows, PriorityHeap highs, int a)
    //    {
    //        if (lows.Count() == 0)
    //        {
    //            lows.Add(a);
    //            return;
    //        }

    //        if (a < lows.Peek())
    //        {
    //            lows.Add(a);
    //            if (lows.Count() > highs.Count() + 1)
    //            {
    //                highs.Add(lows.Remove());
    //            }
    //        }
    //        else
    //        {
    //            highs.Add(a);
    //            if (highs.Count() > lows.Count() + 1)
    //            {
    //                lows.Add(highs.Remove());
    //            }
    //        }
    //    }

    //    static decimal median(PriorityHeap lows, PriorityHeap highs)
    //    {
    //        if (lows.Count() == highs.Count())
    //        {
    //            return (((decimal)(lows.Peek() + highs.Peek())) / 2);
    //        }
    //        else if (lows.Count() > highs.Count())
    //        {
    //            return lows.Peek();
    //        }
    //        else
    //        {
    //            return highs.Peek();
    //        }
    //    }

    //    static void Main(String[] args)
    //    {
    //        int n = Convert.ToInt32(Console.ReadLine());
    //        int[] a = new int[n];


    //        for (int a_i = 0; a_i < n; a_i++)
    //        {
    //            a[a_i] = Convert.ToInt32(Console.ReadLine());
    //            add(lows, highs, a[a_i]);
    //            Console.WriteLine("{0:f1}", median(lows, highs));
    //        }
    //    }
    //}
}
