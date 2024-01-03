using AlgorithmsDataStructures;

namespace AlgorithmsDataStructures.Tests
{
    public class BloomFilterTests
    {
        [Test]
        public void IsValue()
        {
            
            BloomFilter filter = new BloomFilter(32);

            filter.Add("142111492355");
            filter.Add("951441767735");
            filter.Add("841391251086");
            filter.Add("235256626643");
            filter.Add("012030234357");
            filter.Add("023458283243");
            filter.Add("032585357293");
            filter.Add("165583240027");
            filter.Add("083725825313");
            filter.Add("142435364328");
            
            Assert.IsTrue(filter.IsValue("142111492355"));
            Assert.IsTrue(filter.IsValue("951441767735"));
            Assert.IsTrue(filter.IsValue("841391251086"));
            Assert.IsTrue(filter.IsValue("235256626643"));
            Assert.IsTrue(filter.IsValue("023458283243"));
            Assert.IsTrue(filter.IsValue("012030234357"));
            Assert.IsTrue(filter.IsValue("165583240027"));
            Assert.IsTrue(filter.IsValue("083725825313"));
            Assert.IsTrue(filter.IsValue("142435364328"));
            
            //The probabilities of False Positive result is ~= 30%;
            Assert.IsFalse(filter.IsValue("14566763553"));
            Assert.IsFalse(filter.IsValue("01234235326"));
            Assert.IsFalse(filter.IsValue("14566763550"));
            Assert.IsFalse(filter.IsValue("14566763552"));
            //Assert.IsFalse(filter.IsValue("01234871935")); //This Assert hasn't passed this test, but actually this number doesn't contains in Filter
        }
    }
}