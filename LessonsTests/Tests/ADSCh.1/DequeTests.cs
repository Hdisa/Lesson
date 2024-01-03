namespace AlgorithmsDataStructures.Tests
{
    public class DequeTests
    {
        [Test]
        public void ActLikeFIFO() //Act like Queue
        {
            Deque<int> deque = new Deque<int>();
            deque.AddTail(4);
            deque.AddTail(6);
            Assert.That(deque.RemoveFront(), Is.EqualTo(4));
            
            deque.AddTail(8);
            Assert.That(deque.RemoveFront(), Is.EqualTo(6));
            Assert.That(deque.RemoveFront(), Is.EqualTo(8));
            Assert.That(deque.RemoveFront(), Is.EqualTo(0));
            Assert.That(deque.Size(), Is.EqualTo(0));
        }
        
        [Test]
        public void ActLikeLILO() //Act like Queue, but inverted
        {
            Deque<int> deque = new Deque<int>();
            deque.AddFront(4);
            deque.AddFront(6);
            Assert.That(deque.RemoveTail(), Is.EqualTo(4));
            
            deque.AddFront(8);
            Assert.That(deque.RemoveTail(), Is.EqualTo(6));
            Assert.That(deque.RemoveTail(), Is.EqualTo(8));
            Assert.That(deque.RemoveTail(), Is.EqualTo(0));
            Assert.That(deque.Size(), Is.EqualTo(0));
        }
        
        [Test]
        public void ActLikeLIFO() //Act like Stack
        {
            Deque<int> deque = new Deque<int>();
            deque.AddFront(4);
            deque.AddFront(6);
            Assert.That(deque.RemoveFront(), Is.EqualTo(6));
            
            deque.AddFront(8);
            Assert.That(deque.Size(), Is.EqualTo(2));
            Assert.That(deque.RemoveFront(), Is.EqualTo(8));
            Assert.That(deque.RemoveFront(), Is.EqualTo(4));
            Assert.That(deque.RemoveFront(), Is.EqualTo(0));
        }
        
        [Test]
        public void ActLikeFILO() //Act like Stack, but inverted
        {
            Deque<int> deque = new Deque<int>();
            deque.AddTail(4);
            deque.AddTail(6);
            Assert.That(deque.RemoveTail(), Is.EqualTo(6));
            
            deque.AddTail(8);
            Assert.That(deque.RemoveTail(), Is.EqualTo(8));
            Assert.That(deque.Size(), Is.EqualTo(1));
            Assert.That(deque.RemoveTail(), Is.EqualTo(4));
            Assert.That(deque.RemoveTail(), Is.EqualTo(0));
        }
    }
}