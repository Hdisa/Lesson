namespace AlgorithmsDataStructures.Tests;

public class PowerSetTests
{
    [Test]
    public void Size()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        powerSet.Put("ac");
        powerSet.Put("dc");
        
        Assert.That(powerSet.Size(), Is.EqualTo(5));
    }
    
    [Test]
    public void Put_PutIsSuccess()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        Assert.That(powerSet.Size(), Is.EqualTo(3));
    }
    
    [Test]
    public void Put_PutIsFailed()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("b");
        powerSet.Put("b");
        powerSet.Put("c");
        powerSet.Put("c");
        
        Assert.IsFalse(powerSet.Size() == 6);
    }
    
    [Test]
    public void Get_True()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        Assert.That(powerSet.Get("a"), Is.EqualTo(true));
        Assert.That(powerSet.Get("b"), Is.EqualTo(true));
        Assert.That(powerSet.Get("c"), Is.EqualTo(true));
    }
    
    [Test]
    public void Get_False()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        Assert.That(powerSet.Get("ac-dc"), Is.EqualTo(false));
        Assert.That(powerSet.Get("The Fox"), Is.EqualTo(false));
        Assert.That(powerSet.Get("z"), Is.EqualTo(false));
    }
    
    [Test]
    public void Remove_True()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        Assert.That(powerSet.Size(), Is.EqualTo(3));
        Assert.That(powerSet.Remove("a"), Is.EqualTo(true));
        Assert.That(powerSet.Size(), Is.EqualTo(2));
        Assert.That(powerSet.Remove("b"), Is.EqualTo(true));
        Assert.That(powerSet.Size(), Is.EqualTo(1));
    }
    
    [Test]
    public void Remove_False()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        Assert.That(powerSet.Size(), Is.EqualTo(3));
        Assert.That(powerSet.Remove("a"), Is.EqualTo(true));
        Assert.That(powerSet.Size(), Is.EqualTo(2));
        Assert.That(powerSet.Remove("ac-dc"), Is.EqualTo(false));
        Assert.That(powerSet.Size(), Is.EqualTo(2));
    }
    
    [Test, MaxTime(7000)]
    public void Intersection_HasCommonElements()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        powerSet2.Put("a");
        powerSet2.Put("c");
        powerSet2.Put("d");

        var result = powerSet.Intersection(powerSet2);
        
        Assert.That(result.Size(), Is.EqualTo(2));
        Assert.That(result.Get("a"), Is.EqualTo(true));
        Assert.That(result.Get("c"), Is.EqualTo(true));
    }
    
    [Test, MaxTime(7000)]
    public void Intersection_IsEmpty()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        powerSet2.Put("d");
        powerSet2.Put("e");
        powerSet2.Put("f");

        var result = powerSet.Intersection(powerSet2);
        Assert.That(result.Size(), Is.EqualTo(0));
        Assert.That(result.Get("a"), Is.EqualTo(false));
        Assert.That(result.Get("c"), Is.EqualTo(false));
    }
    
    [Test, MaxTime(7000)]
    public void Union_SetsAreNotEmpty()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        powerSet.Put("d");
        
        powerSet2.Put("a");
        powerSet2.Put("c");
        powerSet2.Put("d");
        powerSet2.Put("e");
        powerSet2.Put("f");

        var result = powerSet.Union(powerSet2);
        
        Assert.That(result.Size(), Is.EqualTo(6));
        Assert.That(result.Get("a"), Is.EqualTo(true));
        Assert.That(result.Get("b"), Is.EqualTo(true));
        Assert.That(result.Get("c"), Is.EqualTo(true));
        Assert.That(result.Get("d"), Is.EqualTo(true));
        Assert.That(result.Get("e"), Is.EqualTo(true));
        Assert.That(result.Get("f"), Is.EqualTo(true));
    }
    
    [Test, MaxTime(7000)]
    public void Union_SetIsEmpty()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");

        var result = powerSet.Union(powerSet2);
        
        Assert.That(result.Size(), Is.EqualTo(3));
        Assert.That(result.Get("a"), Is.EqualTo(true));
        Assert.That(result.Get("b"), Is.EqualTo(true));
        Assert.That(result.Get("c"), Is.EqualTo(true));
        Assert.That(result.Get("d"), Is.EqualTo(false));
    }
    
    [Test, MaxTime(7000)]
    public void Difference_IsEmpty1()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        powerSet2.Put("a");
        powerSet2.Put("b");
        powerSet2.Put("c");
        powerSet2.Put("d");
        powerSet2.Put("e");
        powerSet2.Put("f");

        var result = powerSet.Difference(powerSet2);
        
        Assert.That(result.Size(), Is.EqualTo(0));
    }
    
    [Test, MaxTime(7000)]
    public void Difference_IsEmpty2()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        powerSet2.Put("a");
        powerSet2.Put("b");
        powerSet2.Put("c");

        var result = powerSet.Difference(powerSet2);
        
        Assert.That(result.Size(), Is.EqualTo(0));
    }
    
    [Test, MaxTime(7000)]
    public void Difference_IsNotEmpty1()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        powerSet.Put("d");
        powerSet.Put("e");
        powerSet.Put("f");
        
        powerSet2.Put("a");
        powerSet2.Put("b");
        powerSet2.Put("c");

        var result = powerSet.Difference(powerSet2);
        
        Assert.That(result.Size(), Is.EqualTo(3));
        Assert.IsTrue(result.Get("d"));
        Assert.IsTrue(result.Get("e"));
        Assert.IsTrue(result.Get("f"));
        Assert.IsFalse(result.Get("a"));
        Assert.IsFalse(result.Get("b"));
        Assert.IsFalse(result.Get("c"));
    }
    
    [Test, MaxTime(7000)]
    public void Difference_IsNotEmpty2()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        
        powerSet2.Put("d");
        powerSet2.Put("e");
        powerSet2.Put("f");

        var result = powerSet.Difference(powerSet2);
        
        Assert.That(result.Size(), Is.EqualTo(3));
        Assert.IsTrue(result.Get("a"));
        Assert.IsTrue(result.Get("b"));
        Assert.IsTrue(result.Get("c"));
    }
    
    [Test, MaxTime(7000)]
    public void IsSubset_Set2IsSubset()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        powerSet.Put("d");
        powerSet.Put("e");
        powerSet.Put("f");
        
        powerSet2.Put("d");
        powerSet2.Put("e");
        powerSet2.Put("f");
        
        Assert.That(powerSet.IsSubset(powerSet2), Is.EqualTo(true));
    }
    
    [Test, MaxTime(7000)]
    public void IsSubset_Set2PartiallySubset()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        powerSet.Put("d");
        powerSet.Put("e");
        powerSet.Put("f");
        
        powerSet2.Put("d");
        powerSet2.Put("e");
        powerSet2.Put("f");
        powerSet2.Put("g");
        powerSet2.Put("h");
        
        Assert.That(powerSet.IsSubset(powerSet2), Is.EqualTo(false));
    }
    
    [Test, MaxTime(7000)]
    public void IsSubset_Set2IsNotSubset()
    {
        PowerSet<string> powerSet = new PowerSet<string>();
        PowerSet<string> powerSet2 = new PowerSet<string>();
        
        powerSet.Put("a");
        powerSet.Put("b");
        powerSet.Put("c");
        powerSet.Put("d");
        powerSet.Put("e");
        powerSet.Put("f");
        
        powerSet2.Put("x");
        powerSet2.Put("y");
        powerSet2.Put("z");
        
        Assert.That(powerSet.IsSubset(powerSet2), Is.EqualTo(false));
    }
}