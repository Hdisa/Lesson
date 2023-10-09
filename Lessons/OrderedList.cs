using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if(typeof(T) == typeof(String))
            {
                result = CompareString(v1, v2);
            }
            else 
            {
                result = CompareAny(v1, v2);
            }
      
            return result;
            // -1 if v1 < v2
            // 0 if v1 == v2
            // +1 if v1 > v2
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            //insert first
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            Node<T> node = head;

            while (node.next != null)
            {
                if (GetCompareResult(value, node.value) || (Compare(node.value, node.next.value)) == 0 && Compare(value, node.value) == 0)
                {
                    node = node.next;
                    continue;
                }
                //insert before
                if (node.prev == null)
                {
                    newNode.next = head;
                    head.prev = newNode;
                    head = newNode;
                    return;
                }
                var tmp = node.prev;
                node.prev = newNode;
                newNode.prev = tmp;
                tmp.next = newNode;
                newNode.next = node;
                return;
            }
            InsertHeadOrTail(node, newNode);
        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;
            
            while (node != null)
            {
                if (node.value.Equals(val)) return node;
                node = node.next;
            }
            
            return null;
        }

        public void Delete(T val)
        {
            Node<T> node = head;

            while (node != null)
            {
                if (!node.value.Equals(val))
                {
                    node = node.next;
                    continue;
                }
                //if head is null
                if (node.prev == null)
                {
                    RemoveHead(node);
                    return;
                }

                //if tail is null
                if (node.next == null)
                {
                    tail = node.prev;
                    tail.next = null;
                    return;
                }

                //pointers >> to next Node
                node.prev.next = node.next;
                node.next.prev = node.prev;
                return;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node<T> node = head;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }

        public List<Node<T>> GetAll()
        {
            var r = new List<Node<T>>();
            var node = head;
            while(node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
        
        //Additional Methods
        
        //Methods for Compare();
        private int CompareString(T v1, T v2)
        {
            string s1 = v1.ToString().Trim();
            string s2 = v2.ToString().Trim();

            return String.Compare(s1, s2, StringComparison.Ordinal);
        }

        private int CompareAny(T v1, T v2)
        {
            if (typeof(T) != typeof(int))
                return 0;

            int i1 = (int)(object) v1;
            int i2 = (int)(object) v2;

            return i1.CompareTo(i2);
        }
        
        //Methods for Add();
        private bool GetCompareResult(T value, T node)
        {
            int result = Compare(value, node);
            return _ascending ? result > 0 : result < 0;
        }
        
        private void InsertHeadOrTail(Node<T> node, Node<T> newNode)
        {
            if (GetCompareResult(newNode.value,node.value))
            {
                node.next = newNode;
                newNode.prev = node;
                tail = newNode;
                return;
            }

            var tmp = node.prev;
            if (tmp == null)
            {
                InsertBeforeHead(newNode);
                return;                
            }
            
            newNode.next = node;
            node.prev = newNode;
            newNode.prev = tmp;
            tmp.next = newNode;
        }
        
        private void InsertBeforeHead(Node<T> newNode)
        {
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }
        
        //Method for Delete();
        private void RemoveHead(Node<T> node)
        {
            head = node.next;

            if (head == null)
            {
                tail = null;
                return;
            }

            head.prev = null;

            if (head.next == null)
                tail.prev = null;
        }
    }
}
