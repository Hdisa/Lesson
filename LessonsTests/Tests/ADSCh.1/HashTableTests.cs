namespace AlgorithmsDataStructures.Tests
{
    public class HashTableTests
    {
        [Test]
        public void HashFunSameString()
        {
            HashTable hashTable = new HashTable(19, 3);
            string s1 = "Hello World";
            string s2 = "Hello World";
            Assert.IsTrue(hashTable.HashFun(s1) == hashTable.HashFun(s2));
        }

        [Test]
        public void HashFunRegisterDependency()
        {
            HashTable hashTable = new HashTable(19, 3);
            string s1 = "Hello World";
            string s2 = "hello world";
            Assert.IsFalse(hashTable.HashFun(s1) == hashTable.HashFun(s2));
        }
        
        [Test]
        public void HashFunDifferentString()
        {
            HashTable hashTable = new HashTable(19, 3);
            string s1 = "Hello World";
            string s2 = "Bye World";
            
            Assert.IsFalse(hashTable.HashFun(s1) == hashTable.HashFun(s2));
        }
        
        [Test]
        public void SeekSlotHashIndexEqualSeekSlotIndex()
        {
            HashTable hashTable = new HashTable(19, 3);
            string s1 = "hello, my!";
            
            Assert.IsTrue(hashTable.HashFun(s1) == hashTable.SeekSlot(s1));
        }
        
        [Test]
        public void SeekSlotStringWithSameHashCorrectlySlots()
        {
            HashTable hashTable = new HashTable(19, 3);
            string s1 = "hello, my!";
            int hash = hashTable.HashFun(s1);
            hashTable.slots[hash] = "no-no-no, it is my slot";
            
            Assert.That(hashTable.SeekSlot(s1), Is.EqualTo((hash + hashTable.step) % hashTable.size));
        }

        [Test]
        public void SeekSlotAllSlotsBusy()
        {
            HashTable hashTable = new HashTable(19, 3);
            for (int i = 0; i < hashTable.slots.Length; ++i)
            {
                hashTable.slots[i] = "against slot busy";
            }
            
            Assert.That(hashTable.SeekSlot("give me slot"), Is.EqualTo(-1));
        }

        [Test]
        public void PutHashIndexEqualPuttedIndex()
        {
            HashTable hashTable = new HashTable(19, 3);
            
            Assert.IsTrue(hashTable.HashFun("give me slot") == hashTable.Put("give me slot"));
        }
        
        [Test]
        public void FindEmptyTable()
        {
            HashTable hashTable = new HashTable(19, 3);
            
            Assert.That(hashTable.Find("give me slot"), Is.EqualTo(-1));
        }

        [Test]
        public void FindHashIndexEqualWithFindingIndex()
        {
            HashTable hashTable = new HashTable(19, 3);
            string adding = "give me slot";
            
            Assert.IsTrue(hashTable.HashFun(adding) == hashTable.Put(adding));
            Assert.IsTrue(hashTable.Put(adding) == hashTable.Find(adding));
        }

        [Test]
        public void FindValueTableNotContains()
        {
            HashTable hashTable = new HashTable(19, 3);
            string adding = "give me slot";
            int hashIndex = hashTable.HashFun(adding);
            hashTable.slots[hashIndex] = "busy slot";
            
            Assert.That(hashTable.Find("give me slot"), Is.EqualTo(-1));
        }
    }
}