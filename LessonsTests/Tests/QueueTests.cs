using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;

namespace AlgorithmsDataStructures.Tests
{
    public class QueueTests
    {
        [Test]
        public void SizeIsEmpty()
        {
            Queue<int> queue = new Queue<int>();
            
            Assert.That(queue.Size(), Is.EqualTo(0));
        }

        [Test]
        public void SizeIsNotEmpty()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            
            Assert.That(queue.Size(), Is.EqualTo(1));
            queue.Enqueue(2);
            Assert.That(queue.Size(), Is.EqualTo(2));
        }

        [Test]
        public void EnqueueAndDequeue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            
            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Size(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
            Assert.That(queue.Size(), Is.EqualTo(0));
            Assert.That(queue.Dequeue(), Is.EqualTo(0));
        }

        [Test]
        public void SpinQueue1()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            LinkedList<int> result = new LinkedList<int>();
            result.AddLast(2);
            result.AddLast(3);
            result.AddLast(4);
            result.AddLast(5);
            result.AddLast(1);
            
            Assert.That(queue.SpinQueue(1), Is.EqualTo(result));
        }
        
        [Test]
        public void SpinQueue2()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            
            
            LinkedList<int> result = new LinkedList<int>();
            result.AddLast(5);
            result.AddLast(1);
            result.AddLast(2);
            result.AddLast(3);
            result.AddLast(4);
            
            Assert.That(queue.SpinQueue(4), Is.EqualTo(result));
        }
        
        [Test]
        public void SpinQueue3()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            
            LinkedList<int> result = new LinkedList<int>();
            result.AddLast(4);
            result.AddLast(5);
            result.AddLast(1);
            result.AddLast(2);
            result.AddLast(3);
            
            Assert.That(queue.SpinQueue(3), Is.EqualTo(result));
        }
    }
}