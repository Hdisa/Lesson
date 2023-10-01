using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private LinkedList<T> _linkedList;
        
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            _linkedList = new LinkedList<T>();
        } 

        public int Size() 
        {
            //Current size of Stack
            return _linkedList.Count;
        }

        public T Pop()
        {
            if (_linkedList.Count == 0)
            {
                return default(T); // null, if stack is empty
            }

            T result = _linkedList.Last.Value;
            _linkedList.RemoveLast();
            return result;
        }
	  
        public void Push(T val)
        {
            _linkedList.AddLast(val);
        }

        public T Peek()
        {
            if (_linkedList.Count == 0)
            {
                return default(T); // null, if stack is empty
            }
            
            return _linkedList.Last.Value;
            
        }
    }

}