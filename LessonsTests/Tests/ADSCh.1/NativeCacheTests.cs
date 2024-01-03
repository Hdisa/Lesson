namespace AlgorithmsDataStructures.Tests
{
    public class NativeCacheTests
    {
        [Test]
        public void Put()
        {
            NativeCache<int> cache = new NativeCache<int>(5);
            
            cache.Put("Keyblade", 5);
            cache.Put("Oblivion", 8);
            cache.Put("Ulitima", 1);
            cache.Put("WoddenSword", 0);
                
            Assert.That(cache.Get("Keyblade"), Is.EqualTo(5));
            Assert.That(cache.Get("Oblivion"), Is.EqualTo(8));
            Assert.That(cache.Get("Ulitima"), Is.EqualTo(1));
            Assert.That(cache.Get("WoddenSword"), Is.EqualTo(0));
        }
        
        [Test]
        public void Put_RewriteValue()
        {
            NativeCache<int> cache = new NativeCache<int>(5);
            
            cache.Put("Keyblade", 5);
            cache.Put("Oblivion", 8);
            cache.Put("Ulitima", 1);
            cache.Put("WoddenSword", 0);
            
            cache.Put("Keyblade", 13);
            cache.Put("Oblivion", 24);
            cache.Put("Ulitima", 11);
            cache.Put("WoddenSword", 43);
            
            Assert.That(cache.Get("Keyblade"), Is.EqualTo(13));
            Assert.That(cache.Get("Oblivion"), Is.EqualTo(24));
            Assert.That(cache.Get("Ulitima"), Is.EqualTo(11));
            Assert.That(cache.Get("WoddenSword"), Is.EqualTo(43));
        }
        
        [Test]
        public void Put_CacheIsFull()
        {
            NativeCache<int> cache = new NativeCache<int>(5);
            
            cache.Put("Keyblade", 5);
            cache.Put("Oblivion", 8);
            cache.Put("Ulitima", 1);
            cache.Put("WoddenSword", 0);
            cache.Put("Random", 332);

            cache.Get("Keyblade");
            cache.Get("Oblivion");
            cache.Get("Ulitima");
            cache.Get("WoddenSword");
            
            cache.Put("Distance", 21);
            Assert.That(cache.Get("Distance"), Is.EqualTo(21));
            Assert.Zero(cache.Get("Random"));
        }
    }
}