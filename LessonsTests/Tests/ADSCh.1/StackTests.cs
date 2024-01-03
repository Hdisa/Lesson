using AlgorithmsDataStructures;

namespace AlgorithmsDataStructures.Tests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void SizeEmptyTest()
        {
            Stack<int> stack = new Stack<int>();

            var result = stack.Size();
            
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void SizePushNotEmptyCorrectTest()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);stack.Push(1);stack.Push(1);

            Assert.That(stack.Size(), Is.EqualTo(3));
            stack.Pop();
            Assert.That(stack.Size(), Is.EqualTo(2));
        }

        [Test]
        public void PopEmptyTest()
        {
            Stack<int> stack = new Stack<int>();
            var result = stack.Pop();
            
            Assert.That(result, Is.EqualTo(0));
        }
        
        [Test]
        public void PopNotEmptyTest()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            var result = stack.Pop();
            
            Assert.That(result, Is.EqualTo(1));
            Assert.That(stack.Size(), Is.EqualTo(0));
        }

        [Test]
        public void PeekEmptyTest()
        {
            Stack<int> stack = new Stack<int>();
            var result = stack.Peek();
            
            Assert.That(result, Is.EqualTo(0));
        }
        
        [Test]
        public void PeekNotEmptyResultAndSizeDontChanged()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            var result = stack.Peek();
            
            Assert.That(result, Is.EqualTo(1));
            Assert.That(stack.Size(), Is.EqualTo(1));
        }
    }
}