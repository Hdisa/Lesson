using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;

namespace AlgorithmsDataStructures.Tests
{
    
    public class DynArrayTests
    {
        [Test]
        public void MakeArrayTest()
        {
            DynArray<int> array = new DynArray<int>();

            Assert.AreEqual(16, array.capacity);
            
            array.MakeArray(36);
            Assert.AreEqual(36, array.capacity);
        }
        
        [Test]
        public void GetItemTest()
        {
            DynArray<int> array = new DynArray<int>();
            
            array.Append(16);
            Assert.AreEqual(16, array.GetItem(0));
        }
        
        [Test]
        public void InsertTest()
        {
            DynArray<int> array = new DynArray<int>();
            
            array.Insert(15, 0);
            
            Assert.AreEqual(15, array.GetItem(0));
            Assert.AreEqual(1, array.count);
        }
        
        [Test]
        public void InsertTail()
        {
            DynArray<int> array = new DynArray<int>();
            FillArray(array);
            
            //act
            array.Insert(8, 6);
            
            //assert
            Assert.AreEqual(1, array.GetItem(0));
            Assert.AreEqual(6, array.GetItem(5));
            Assert.AreEqual(8, array.GetItem(6));
            Assert.AreEqual(9, array.count);
            Assert.AreEqual(16, array.capacity);
        }
        
        [Test]
        public void InsertToEmpty()
        {
            DynArray<int> array = new DynArray<int>();
            
            array.Insert(1, 0);
            
            Assert.AreEqual(1, array.GetItem(0));
            Assert.AreEqual(1,array.count);
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(16)]
        public void WrongInsert(int i)
        {
            DynArray<int> array = new DynArray<int>();
            FillArray(array);

            Assert.Throws<IndexOutOfRangeException>(() => array.Insert(1, i));
        }
        
        [Test]
        public void RemoveFromEmpty()
        {
            DynArray<int> array = new DynArray<int>();
            
            Assert.Throws<IndexOutOfRangeException>(() => array.Remove(0));
        }

        private void FillArray(DynArray<int> arr)
        {
            arr.Append(1);
            arr.Append(2);
            arr.Append(3);
            arr.Append(4);
            arr.Append(5);
            arr.Append(6);
            arr.Append(7);
            arr.Append(8);
        }

        private void FullArrayCapacity(DynArray<int> array)
        {
            //Default Capacity is 16
            array.Append(1);
            array.Append(2);
            array.Append(3);
            array.Append(4);
            array.Append(5);
            array.Append(6);
            array.Append(7);
            array.Append(8);
            array.Append(9);
            array.Append(10);
            array.Append(11);
            array.Append(12);
            array.Append(13);
            array.Append(14);
            array.Append(15);
            array.Append(16);
        }
    }
}