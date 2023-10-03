using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private LinkedList<T> _linkedList;
        
        public Queue()
        {
            _linkedList = new LinkedList<T>();
        } 

        public void Enqueue(T item)
        {
            _linkedList.AddLast(item);
        }

        public T Dequeue()
        {
            if (_linkedList.Count == 0) return default(T);

            T result = _linkedList.First.Value;
            _linkedList.RemoveFirst();
            return result;
        }

        public int Size()
        {
            return _linkedList.Count;
        }

        public LinkedList<T> SpinQueue(int iteration)
        {
            for (int i = 0; i < iteration; i++)
            {
                T item = Dequeue();
                Enqueue(item);
            }

            return _linkedList;
        }
    }
}
