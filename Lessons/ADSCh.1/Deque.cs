using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class Deque<T>
    {
        private LinkedList<T> _linkedList;
        
        public Deque()
        {
            _linkedList = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            _linkedList.AddFirst(item);
        }

        public void AddTail(T item)
        {
            _linkedList.AddLast(item);
        }

        public T RemoveFront()
        {
            if (_linkedList.Count == 0) return default(T);

            T result = _linkedList.First.Value;
            _linkedList.RemoveFirst();
            return result;
        }

        public T RemoveTail()
        {
            if (_linkedList.Count == 0) return default(T);

            T result = _linkedList.Last.Value;
            _linkedList.RemoveLast();
            return result;
        }
        
        public int Size()
        {
            return _linkedList.Count;
        }
    }
}