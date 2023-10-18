using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        private List<T> _list;
        
    public PowerSet()
    {
        _list = new List<T>();
    }

    public int Size()
    {
        return _list.Count;
    }

    public void Put(T value)
    {
        if(!_list.Contains(value))
            _list.Add(value);
    }

    public bool Get(T value)
    {
        if (_list.Contains(value))
            return true;
        
        return false;
    }

    public bool Remove(T value)
    {
        return _list.Remove(value);
    }

    public PowerSet<T> Intersection(PowerSet<T> set2)
    {
        PowerSet<T> intersection = new PowerSet<T>();
        
        for (int i = 0; i < _list.Count; i++)
        {
            if (set2.Get(_list[i]))
                intersection.Put(_list[i]);
        }
        
        return intersection;
    }

    public PowerSet<T> Union(PowerSet<T> set2)
    {
        PowerSet<T> union = new PowerSet<T>();
        
        for (int i = 0; i < _list.Count; i++)
            union.Put(_list[i]);
        
        for (int i = 0; i < set2._list.Count; i++)
            union.Put(set2._list[i]);
        
        return union;
    }

    public PowerSet<T> Difference(PowerSet<T> set2)
    {
        PowerSet<T> difference = new PowerSet<T>();
        
        for (int i = 0; i < _list.Count; i++)
        {
            if (!set2.Get(_list[i]))
                difference.Put(_list[i]);
        }
        
        return difference;
    }

    public bool IsSubset(PowerSet<T> set2)
    {
        foreach (var value in set2._list)
        {
            if (!_list.Contains(value))
                return false;
        }
        
        return true;
    }
    }
}