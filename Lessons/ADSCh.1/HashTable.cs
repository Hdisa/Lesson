using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string [] slots; 

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for(int i=0; i<size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            int hash = 0;
            byte[] data = System.Text.Encoding.UTF8.GetBytes(value);
            for (int i = 0; i < data.Length; i++) hash += data[i];
            
            return hash % size;
        }

        public int SeekSlot(string value)
        {
            int hash = HashFun(value);

            if (slots[hash] == null)
                return hash;
            
            int stepScale = 0;
            
            do
            {
                hash += step;
                stepScale += step;
                hash %= size;

                if (slots[hash] == null)
                    return hash;
                
            } while (stepScale < size);
            
            return -1;
        }

        public int Put(string value)
        {
            int hash = SeekSlot(value);
            
            if(hash != -1)
                slots[hash] = value;
            
            return hash;
        }

        public int Find(string value)
        {
            int hash = HashFun(value);
            int stepScale = 0;
            
            if (slots[hash] == null)
                return -1;
            
            while (stepScale < size)
            {
                if (slots[hash] == value)
                    return hash;
                
                hash += step;
                hash %= size;
                stepScale += step;
            }
            
            return -1;
        }
    }
}