namespace AlgorithmsDataStructures.Tests
{
    public class OrderedListTests
    {
        #region AddAsc

        [Test]
        public void StringAddTest()
        {
            var list = new OrderedList<string>(true);
            list.Add("124");
            list.Add("123");
            list.Add("3");
            list.Add("099999");

            var expected = new List<string>()
            {
                "099999", "123", "124", "3"
            };
            var result = list.GetAll();
            
            CollectionAssert.AreEqual(expected, result.Select(x => x.value).ToList());
            Assert.That(list.head.value, Is.EqualTo("099999"));
            Assert.That(list.tail.value, Is.EqualTo("3"));
        }
        
        [Test]
        public void AddHeadEmpty()
        {
            var list = new OrderedList<int>(true);
            
            list.Add(1);
            
            Assert.That(list.Count(), Is.EqualTo(1));
        }

        [Test]
        public void AddHead()
        {
            var list = new OrderedList<int>(true);
            list.Add(2);
            list.Add(1);
            list.Add(3);

            var listFromOrdered = list.GetAll();
            Assert.That(listFromOrdered[0].value, Is.EqualTo(1));
            Assert.That(list.Count(), Is.EqualTo(3));
            Assert.That(listFromOrdered[2].value, Is.EqualTo(3));
            Assert.That(list.head.value, Is.EqualTo(1));
            Assert.That(list.tail.value, Is.EqualTo(3));
        }

        [Test]
        public void AddMiddleTest()
        {
            var list = new OrderedList<int>(true);
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.Add(4);
            list.Add(6);
            list.Add(5);

            var result = list.GetAll();
            var values = result.Select(x => x.value).ToList();

            var expected = new List<int>()
            {
                1, 2, 3, 4, 5, 6
            };
            
            CollectionAssert.AreEqual(expected, values);
            Assert.That(list.head.value, Is.EqualTo(1));
            Assert.That(list.Count(), Is.EqualTo(6));
            Assert.That(list.tail.value, Is.EqualTo(6));
            Assert.That(result.Last().value, Is.EqualTo(6));
            Assert.That(result.First().value, Is.EqualTo(1));
        }

        [Test]
        public void AddTail()
        {
            var list = new OrderedList<int>(true);
            list.Add(2);
            list.Add(5);

            var result = list.GetAll();
            Assert.That(result[0].value, Is.EqualTo(2));
            Assert.That(result[1].value, Is.EqualTo(5));
            Assert.That(list.tail.value, Is.EqualTo(5));
            Assert.That(list.head.value, Is.EqualTo(2));
        }

        [Test]
        public void AddMiddleEqual()
        {
            // 1 1 2 3 4, insert 1
            var list = new OrderedList<int>(true);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            list.Add(1);
            list.Add(1);

            var result = list.GetAll();
            var values = result.Select(x => x.value).ToList();

            var expected = new List<int>()
            {
                1, 1, 1, 2, 3
            };
            
            CollectionAssert.AreEqual(expected, values);
            Assert.That(list.head.value, Is.EqualTo(1));
            Assert.That(list.Count(), Is.EqualTo(5));
            Assert.That(list.tail.value, Is.EqualTo(3));
            Assert.That(result.Last().value, Is.EqualTo(3));
            Assert.That(result.First().value, Is.EqualTo(1));
        }

        #endregion

        #region AddDesc

        [Test]
        public void AddDescHeadEmpty()
        {
            var list = new OrderedList<int>(false);
            
            list.Add(1);
            
            Assert.That(list.Count(), Is.EqualTo(1));
        }

        [Test]
        public void AddDescHead()
        {
            var list = new OrderedList<int>(false);
            list.Add(2);
            list.Add(1);
            list.Add(3);

            var listFromOrdered = list.GetAll();
            Assert.That(listFromOrdered[0].value, Is.EqualTo(3));
            Assert.That(list.Count(), Is.EqualTo(3));
            Assert.That(listFromOrdered[2].value, Is.EqualTo(1));
            Assert.That(list.head.value, Is.EqualTo(3));
            Assert.That(list.tail.value, Is.EqualTo(1));
        }

        [Test]
        public void AddDescMiddleTest()
        {
            var list = new OrderedList<int>(false);
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.Add(4);
            list.Add(6);
            list.Add(5);

            var result = list.GetAll();
            var values = result.Select(x => x.value).ToList();

            var expected = new List<int>()
            {
                6,5,4,3,2,1
            };
            
            CollectionAssert.AreEqual(expected, values);
            Assert.That(list.head.value, Is.EqualTo(6));
            Assert.That(list.Count(), Is.EqualTo(6));
            Assert.That(list.tail.value, Is.EqualTo(1));
            Assert.That(result.Last().value, Is.EqualTo(1));
            Assert.That(result.First().value, Is.EqualTo(6));
        }

        [Test]
        public void AddDescTail()
        {
            var list = new OrderedList<int>(false);
            list.Add(2);
            list.Add(5);

            var result = list.GetAll();
            Assert.That(result[0].value, Is.EqualTo(5));
            Assert.That(result[1].value, Is.EqualTo(2));
            Assert.That(list.tail.value, Is.EqualTo(2));
            Assert.That(list.head.value, Is.EqualTo(5));
        }
        
        #endregion
        
        #region Delete

        [Test]
        public void DeleteEmptyList()
        {
            var list = new OrderedList<int>(true);

            list.Delete(2);
            var result = list.GetAll();
            
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }
        
        [Test]
        public void DeleteOneElementListDeleted()
        {
            var list = new OrderedList<int>(false);
            list.Add(2);

            list.Delete(2);
            var result = list.GetAll();
            
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }
        
        [Test]
        public void DeleteTwoElementListRemoveFirstDeleted()
        {
            var list = new OrderedList<int>(true);
            list.Add(3);
            list.Add(2);

            list.Delete(2);
            var result = list.GetAll();
            
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(3, list.head.value);
            Assert.AreEqual(3, list.tail.value);
            Assert.AreEqual(null, list.head.next);
            Assert.AreEqual(null, list.tail.next);
            Assert.IsNull(list.head.prev);
            Assert.IsNull(list.tail.prev);
        }

        [Test]
        public void DeleteValueInHeadDeleted()
        {
            var list = new OrderedList<int>(true);
            list.Add(2);
            list.Add(3);
            list.Add(2);

            list.Delete(2);
            var result = list.GetAll();
            
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, list.head.value);
            Assert.AreEqual(3, list.tail.value);
            Assert.IsNull(list.head.prev);
        }
        
        [Test]
        public void DeleteValueInTailDeleted()
        {
            var list = new OrderedList<int>(true);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Delete(4);
            var result = list.GetAll();
            
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, list.head.value);
            Assert.AreEqual(3, list.tail.value);
            Assert.AreEqual(null, list.tail.next);
        }

        [Test]
        public void DeleteMiddleDeleted()
        {
            var list = new OrderedList<int>(true);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Delete(3);
            var result = list.GetAll();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, list.head.value);
            Assert.AreEqual(4, list.tail.value);
            Assert.AreEqual(null, list.tail.next);
            Assert.AreEqual(2, list.tail.prev.value);
        }
        
        #endregion

        #region Find

        [Test]
        public void FindEmpty()
        {
            var list = new OrderedList<int>(true);

            var res = list.Find(5);
            
            Assert.IsNull(res);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void FindSingle(bool asc)
        {
            var list = new OrderedList<int>(asc);
            list.Add(1);

            var res = list.Find(1);
            Assert.That(res.value, Is.EqualTo(1));
            
            Assert.IsNull(list.Find(5));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Find(bool asc)
        {
            var list = new OrderedList<int>(asc);
            list.Add(5);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            list.Add(4);

            var res = list.Find(2);
            
            Assert.That(res.value, Is.EqualTo(2));
            Assert.IsNull(list.Find(6));
        }
        
        [Test]
        [TestCase(true, 5, 5)]
        [TestCase(false, 5, 5)]
        [TestCase(true, 2, 2)]
        [TestCase(true, 3, 3)]
        [TestCase(true, 7, 7)]
        [TestCase(true, 9, 9)]
        [TestCase(true, 11, 11)]
        [TestCase(true, 15, 15)]
        [TestCase(true, 1, 1)]
        [TestCase(false, 20, null)]
        [TestCase(false, 8, null)]
        [TestCase(true, 8, null)]
        public void Find2(bool asc, int val, int? expected)
        {
            var list = new OrderedList<int>(asc);
            list.Add(5);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            list.Add(4);
            list.Add(15);
            list.Add(7);
            list.Add(14);
            list.Add(9);
            list.Add(12);
            list.Add(13);
            list.Add(10);
            list.Add(11);

            var res = list.Find(val);

            if (res == null)
            {
                Assert.IsNull(expected);
            }
            else
            {
                Assert.That(res.value, Is.EqualTo(expected.Value));
            }
        }
        
        #endregion
    }
}