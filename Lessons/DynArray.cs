using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        private const int MinimumCapacity = 16;
        public T [] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            Array.Resize(ref array, new_capacity);
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            CheckIndexRange(index);
            return array[index];
        }

        public void Append(T itm)
        {
            CheckforExpandArray();

            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            CheckIndexRange(index);
            CheckforExpandArray();

            for (int i = index; i < capacity; i++)
            {
                T tmp = array[i];
                array[i] = itm;
                itm = tmp;
            }
            count++;
        }

        public void Remove(int index)
        {
            if (count == 0)
                throw new IndexOutOfRangeException();

            CheckIndexRange(index);
            
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            
            count--;

            CheckForShrinkArray();
        }

        /// <summary>
        /// Resized Array if it is refilled
        /// </summary>
        private void CheckforExpandArray()
        {
            if (count == capacity) // check filled array
            {
                MakeArray(capacity * 2);
            }
        }

        private void CheckForShrinkArray()
        {
            double result = (double)count / capacity;
            if(result >= 0.5)
                return;
            
            int newCapacity = (int)(capacity / 1.5);
            if (newCapacity <= MinimumCapacity)
                MakeArray(MinimumCapacity);
            else
                MakeArray(newCapacity);
        }
        private void CheckIndexRange(int index)
        {
            if (index > count || index < 0)
                throw new IndexOutOfRangeException();
        }
    }
}