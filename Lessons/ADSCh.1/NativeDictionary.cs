using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public const int step = 1;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            int sum = 0;
            byte[] data = System.Text.Encoding.UTF8.GetBytes(key);
            for (int i = 0; i < data.Length; i++)
                sum += data[i];

            return sum % size;
        }

        public bool IsKey(string key)
        {
            if (key == null)
                return false;
            
            int hash = HashFun(key);
            int stepScale = 0;
            while (stepScale < size)
            {
                if (slots[hash] == null)
                    return false;
                
                if (slots[hash] == key)
                    return true;

                hash += step;
                hash %= size;
                stepScale += step;
            }

            return slots[hash] != null;
        }

        public void Put(string key, T value)
        {
            if(key == null)
                return;

            int hash = HashFun(key);
            int startHash = hash;
            int stepScale = 0;
            while (stepScale < size)
            {
                if (slots[hash] == null)
                {
                    slots[hash] = key;
                    values[hash] = value;
                    return;
                }

                if (slots[hash] == key)
                {
                    values[hash] = value;
                    return;
                }

                hash += step;
                hash %= size;
                stepScale += step;
            }
            
            slots[startHash] = key;
            values[startHash] = value;
        }

        public T Get(string key)
        {
            int hash = HashFun(key);
            int stepScale = 0;
            while (stepScale < size)
            {
                if (slots[hash] == null)
                    return default(T);
                
                if (slots[hash] == key)
                    return values[hash];

                hash += step;
                hash %= size;
                stepScale += step;
            }

            return default(T);
        }

    }
}