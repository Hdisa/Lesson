using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else              tail.next = _item;
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
                        
                        //if current node is the last
                        if (current.next == null)
                            tail = previous;
                    }
                    else
                    {
                        //if removing a first node in list
                        head = head.next;
 
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
            Node current = head;
            
            if (_nodeAfter == null)
            {
                if (head == null)
                {
                    head = _nodeToInsert;
                    tail = _nodeToInsert;
                    return;
                }

                _nodeToInsert.next = head;
                head = _nodeToInsert;
                return;
            }
            
            while (current != null)
            {
                if (_nodeAfter.value == current.value)
                {
                    Node afterInsert = current.next;
                    
                    if (afterInsert == null)
                        tail = _nodeToInsert;
                    
                    current.next = _nodeToInsert;
                    _nodeToInsert.next = afterInsert;
                    break;
                }
                
                current = current.next;
            }
        }

    }
}