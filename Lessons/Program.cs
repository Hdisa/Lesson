using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(32);
            Node n2 = new Node(16);
            n1.next = n2;

            LinkedList sList = new LinkedList();
            sList.AddInTail(n1);
            sList.AddInTail(n2);
            sList.AddInTail(new Node(256));
            sList.AddInTail(new Node(16));
        }
    }
}