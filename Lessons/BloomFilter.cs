using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public int bit;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            bit = 0;
        }
        
        public int Hash1(string str1)
        {
            int randNum = 17;
            int hash = 0;
            
            for(int i=0; i<str1.Length; i++)
            {
                int code = (int)str1[i];
                hash = Math.Abs(hash * randNum + code);
            }
            
            return hash % filter_len;
        }
        public int Hash2(string str1)
        {
            int randNum = 223;
            int hash = 0;
            
            for(int i=0; i<str1.Length; i++)
            {
                int code = (int)str1[i];
                hash = Math.Abs(hash * randNum + code);
            }
            
            return hash % filter_len;
        }

        public void Add(string str1)
        {
            int bitHash1 = Hash1(str1);
            int bitHash2 = Hash2(str1);
            
            bit |= 1 << bitHash1;
            bit |= 1 << bitHash2;
        }

        public bool IsValue(string str1)
        {
            int bitHash1 = Hash1(str1);
            int bitHash2 = Hash2(str1);
            
            return (bit & (1 << bitHash1)) != 0 && (bit & (1 << bitHash2)) != 0;
        }
    }
}