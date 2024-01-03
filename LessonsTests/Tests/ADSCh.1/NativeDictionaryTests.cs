namespace AlgorithmsDataStructures.Tests
{
    public class NativeDictionaryTests
    {
        [Test]
        public void KeysAreExists()
        {
            var dictionary = new NativeDictionary<string>(3);
            
            dictionary.Put("keyblade1", "Kingdom Key");
            dictionary.Put("keyblade2", "Oblivion");
            
            Assert.That(dictionary.IsKey("keyblade2"), Is.EqualTo(true));
            Assert.That(dictionary.IsKey("keyblade1"), Is.EqualTo(true));
            Assert.That(dictionary.IsKey("keyblade3"), Is.EqualTo(false));
            
        }

        [Test]
        public void PutFilled()
        {
            var dictionary = new NativeDictionary<string>(4);
            
            dictionary.Put("first", "Kingdom Key");
            dictionary.Put("second", "Oblivion");
            dictionary.Put("third", "Aether Key");
            dictionary.Put("fourth", "Pirate");
            
            Assert.That(dictionary.Get("first"), Is.EqualTo("Kingdom Key"));
            Assert.That(dictionary.Get("second"), Is.EqualTo("Oblivion"));
            Assert.That(dictionary.Get("third"), Is.EqualTo("Aether Key"));
            Assert.That(dictionary.Get("fourth"), Is.EqualTo("Pirate"));
        }

        [Test]
        public void Get()
        {
            var dictionary = new NativeDictionary<string>(4);

            dictionary.Put("keyblade1", "Kingdom Key");
            dictionary.Put("keyblade2", "Oblivion");
            dictionary.Put("keyblade3", "Aether Key");
            dictionary.Put("keyblade4", "Pirate");

            Assert.That(dictionary.Get("keyblade4"), Is.EqualTo("Pirate"));
            Assert.That(dictionary.Get("keyblade1"), Is.EqualTo("Kingdom Key"));
        }
        
        [Test]
        public void GetEmpty()
        {
            var dictionary = new NativeDictionary<string>(4);

            dictionary.Put("keyblade1", "Kingdom Key");
            dictionary.Put("keyblade2", "Oblivion");
            dictionary.Put("keyblade3", "Aether Key");
            dictionary.Put("keyblade4", "Pirate");

            Assert.That(dictionary.Get("keyblade6"), Is.EqualTo(null));
            Assert.That(dictionary.Get("bfsdsa"), Is.EqualTo(null));
        }

        [Test]
        public void RewriteValues()
        {
            var dictionary = new NativeDictionary<string>(4);
            dictionary.Put("keyblade1", "Kingdom Key");
            dictionary.Put("keyblade2", "Oblivion");
            dictionary.Put("keyblade3", "Aether Key");
            dictionary.Put("keyblade4", "Pirate");
            
            dictionary.Put("keyblade3", "Inferno Key");
            dictionary.Put("keyblade4", "Seasalt Key");
            
            Assert.That(dictionary.Get("keyblade3"), Is.EqualTo("Inferno Key"));
            Assert.That(dictionary.Get("keyblade4"), Is.EqualTo("Seasalt Key"));
        }
        
        [Test]
        public void IsKeySlotIsEmpty()
        {
            var dictionary = new NativeDictionary<string>(4);
            dictionary.Put("keyblade1", "Kingdom Key");
            dictionary.Put("keyblade2", "Oblivion");
            dictionary.Put("keyblade3", "Aether Key");
            
            Assert.That(dictionary.IsKey("keyblade5"), Is.EqualTo(false));
            Assert.That(dictionary.IsKey("rand"), Is.EqualTo(false));
        }
        
        [Test]
        public void IsKeySlotIsBusy()
        {
            var dictionary = new NativeDictionary<string>(4);
            dictionary.Put("keyblade1", "Kingdom Key");
            dictionary.Put("keyblade2", "Oblivion");
            dictionary.Put("keyblade3", "Aether Key");
            
            Assert.That(dictionary.IsKey("keyblade1"), Is.EqualTo(true));
            Assert.That(dictionary.IsKey("keyblade3"), Is.EqualTo(true));
        }
    }
}