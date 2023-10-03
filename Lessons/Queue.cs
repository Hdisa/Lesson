using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private LinkedList<T> _linkedList;
        
        public Queue()
        {
            // инициализация внутреннего хранилища очереди
            _linkedList = new LinkedList<T>();
        } 

        public void Enqueue(T item)
        {
            // input to tail
            _linkedList.AddLast(item);
        }

        public T Dequeue()
        {
            // giving from head
            if (_linkedList.Count == 0) return default(T); // if Queue is empty

            T result = _linkedList.First.Value;
            _linkedList.RemoveFirst();
            return result;
        }

        public int Size()
        {
            return _linkedList.Count; // Queue size
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