using System;

namespace DataStructuresInCSharp
{

    /** Heap of ints **/
    public abstract class Heap
    {
        /** Current array length **/
        protected int Capacity;
        
       
        /** Array of Heap elements **/
        protected int[] Items;

        protected Heap()
        {
            Capacity = 10;
            Size = 0;
            Items = new int[Capacity];
        }

        /** Current number of elements in Heap **/
        public int Size { get; private set; }

        public bool IsEmpty => Size == 0;

        /** @param parentIndex The index of the parent element.
            @return The index of the left child.
        **/
        protected int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        /** @param parentIndex The index of the parent element.
            @return The index of the right child.
        **/
        protected int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        /** @param childIndex The index of the child element.
            @return The index of the parent element.
        **/
        protected int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        /** @param index The index of the element you are checking.
            @return true if the Heap contains enough elements to fill the left child index, 
                    false otherwise.
        **/
        public bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < Size;
        }

        /** @param index The index of the element you are checking.
            @return true if the Heap contains enough elements to fill the right child index, 
                    false otherwise.
        **/
        public bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < Size;
        }

        /** @param index The index of the element you are checking.
            @return true if the calculated parent index exists within array bounds
                    false otherwise.
        **/
        public bool HasParent(int index)
        {
            return GetParentIndex(index) >= 0;
        }

        /** @param index The index of the element whose child you want.
            @return the value in the left child.
        **/
        public int LeftChild(int index)
        {
            return Items[GetLeftChildIndex(index)];
        }

        /** @param index The index of the element whose child you want.
            @return the value in the right child.
        **/
        public int RightChild(int index)
        {
            return Items[GetRightChildIndex(index)];
        }

        /** @param index The index of the element you are checking.
            @return the value in the parent element.
        **/
        public int Parent(int index)
        {
            return Items[GetParentIndex(index)];
        }

        /** @param indexOne The first index for the pair of elements being swapped.
            @param indexTwo The second index for the pair of elements being swapped.
        **/
        protected void Swap(int indexOne, int indexTwo)
        {
            int temp = Items[indexOne];
            Items[indexOne] = Items[indexTwo];
            Items[indexTwo] = temp;
        }

        /** Doubles underlying array if capacity is reached. **/
        protected void EnsureCapacity()
        {
            if (Size == Capacity)
            {
                Capacity = Capacity << 1;
                int[] newArray = new int[Capacity];
                Array.Copy(Items, newArray, Items.Length);
                Items = newArray;
            }
        }

        /** @throws IllegalStateException if Heap is empty.
            @return The value at the top of the Heap.
         **/
        public int Peek()
        {
            ThrowEmptyException("peek");

            return Items[0];
        }

        /** @throws IllegalStateException if Heap is empty. **/
        private void ThrowEmptyException(String methodName)
        {
            if (Size == 0)
            {
                throw new Exception(
                    "You cannot perform '" + methodName + "' on an empty Heap."
                );
            }
        }

        /** Extracts root element from Heap.
            @throws IllegalStateException if Heap is empty.
        **/
        public int Poll()
        {
            // Throws an exception if empty.
            ThrowEmptyException("poll");

            // Else, not empty
            int item = Items[0];
            Items[0] = Items[Size - 1];
            Size--;
            HeapifyDown();
            return item;
        }

        /** @param item The value to be inserted into the Heap. **/
        public void Add(int item)
        {
            // Resize underlying array if it's not large enough for insertion
            EnsureCapacity();

            // Insert value at the next open location in heap
            Items[Size] = item;
            Size++;

            // Correct order property
            HeapifyUp();
        }

        /** Swap values down the Heap. **/
        protected abstract void HeapifyDown();

        /** Swap values up the Heap. **/
        protected abstract void HeapifyUp();
    }

    public class MaxHeap : Heap
    {
        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);

                if (HasRightChild(index)
                    && RightChild(index) > LeftChild(index)
                )
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (Items[index] > Items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }

        protected override void HeapifyUp()
        {
            int index = Size - 1;

            while (HasParent(index)
                 && Parent(index) < Items[index]
                )
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }

    public class MinHeap : Heap
    {
        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);

                if (HasRightChild(index)
                    && RightChild(index) < LeftChild(index)
                )
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (Items[index] < Items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }

        protected override void HeapifyUp()
        {
            int index = Size - 1;

            while (HasParent(index)
                 && Parent(index) > Items[index]
                )
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }
    

}


