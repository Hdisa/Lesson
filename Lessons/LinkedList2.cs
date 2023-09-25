using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value) { 
            value = _value; 
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) {
                head = _item;
                head.next = null;
                head.prev = null;
            } else {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            
            Node current = head;
            while (current != null)
            {
                if (current.value == _value)
                    nodes.Add(current);
                current = current.next;
            }
            
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node? current = head;
            Node? previous = null;
            
            while (current != null)
            {
                if (current.value == _value)
                {
                    //if node is in middle or in the end of list
                    if (previous != null)
                    {
                        previous.next = current.next; // removing current node. Now previous node reference to current.next
                        current.prev = previous;
                        
                        //if current node is the last
                        if (current.next == null)
                            tail = previous;
                        
                    }
                    else
                    {
                        //if removing a first node in list
                        head = head.next;
                        head.prev = null;
 
                        //if after removing head a list is empty
                        if (head == null)
                            tail = null;
                    }
                    return true; // the node has been deleted;
                }
 
                previous = current;
                current = current.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            while (Remove(_value))
            {
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                if (head == null)
                {
                    head = _nodeToInsert;
                    head.next = null;
                    head.prev = null;
                    tail = _nodeToInsert;
                }
                else
                {
                    _nodeToInsert.next = head;
                    head.prev = _nodeToInsert;
                    head = _nodeToInsert;
                }
                return;
            }

            Node current = head;

            while (current != null)
            {
                if (current.value != _nodeAfter.value)
                {
                    current = current.next;
                    continue;
                }

                //next is tail
                if (current.next == null)
                {
                    _nodeToInsert.next = null;
                    tail = _nodeToInsert;
                }
                //next not tail
                else
                {
                    _nodeToInsert.next = current.next;
                    _nodeToInsert.next.prev = _nodeToInsert;
                }
                
                _nodeToInsert.prev = current;
                current.next = _nodeToInsert;
                return;
            }

        }

    }
}