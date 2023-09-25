using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;

namespace AlgorithmsDataStructures.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FindAllTest()
        {
            LinkedList list = new LinkedList();
            
            list.AddInTail(new Node(32));
            list.AddInTail(new Node(32));
            list.AddInTail(new Node(16));
            list.AddInTail(new Node(32));
            var result = list.FindAll(32);
            
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void Remove()
        {
            LinkedList list = new LinkedList();
            
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(3));
            list.AddInTail(new Node(8));
            list.AddInTail(new Node(3));
            
            list.Remove(3);
            
            Assert.AreEqual(3, list.Count());
        }
        
        [Test]
        public void RemoveEmpty()
        {
            LinkedList list = new LinkedList();
            list.Remove(3);
            
            Assert.AreEqual(false, list.Remove(3));
        }
        
        [Test]
        public void RemoveUnexist()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(0));
            list.AddInTail(new Node(8));
            
            Assert.AreEqual(false, list.Remove(6));
        }
        
        [Test]
        public void RemoveHead()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(0));
            list.AddInTail(new Node(8));
            
            
            Assert.AreEqual(true, list.Remove(61));
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(0, list.head.value);
        }
        
        [Test]
        public void RemoveTail()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(0));
            list.AddInTail(new Node(8));
            
            
            Assert.AreEqual(true, list.Remove(8));
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(0, list.tail.value);
        }
        
        [Test]
        public void RemoveAll()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(0));
            list.AddInTail(new Node(8));
            list.AddInTail(new Node(11));
            list.AddInTail(new Node(8));

            list.RemoveAll(8);
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(null, list.Find(8));
        }
        
        [Test]
        public void InsertAfter()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(9));
            list.AddInTail(new Node(66));
            list.AddInTail(new Node(8));

            list.InsertAfter(new Node(66), new Node(77));
            
            Assert.AreEqual(5, list.Count());
            Assert.AreEqual(8, list.tail.value);
        }
        
        [Test]
        public void InsertAfterEndOfList()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(9));
            list.AddInTail(new Node(66));

            list.InsertAfter(new Node(66), new Node(77));
            
            Assert.AreEqual(4, list.Count());
            Assert.AreEqual(77, list.tail.value);
        }
        
        [Test]
        public void InsertAfterEmpty()
        {
            LinkedList list = new LinkedList();

            list.InsertAfter(null ,new Node(77));
            
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(77, list.tail.value);
            Assert.AreEqual(77, list.head.value);
        }
        
        [Test]
        public void InsertAfterStartList()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(96));
            list.AddInTail(new Node(66));

            list.InsertAfter(null ,new Node(77));
            
            Assert.AreEqual(4, list.Count());
            Assert.AreEqual(77, list.head.value);
        }
        
        [Test]
        public void InsertAfterTail()
        {
            LinkedList list = new LinkedList();
            list.AddInTail(new Node(61));
            list.AddInTail(new Node(96));
            list.AddInTail(new Node(66));

            list.InsertAfter(new Node(66) ,new Node(77));
            
            Assert.AreEqual(4, list.Count());
            Assert.AreEqual(77, list.tail.value);
        }
    }
}
