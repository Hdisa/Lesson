using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public int[] filterArray;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            filterArray = new int[filter_len];
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

            filterArray[bitHash1] = 1;
            filterArray[bitHash2] = 1;
        }

        public bool IsValue(string str1)
        {
            int bitHash1 = Hash1(str1);
            int bitHash2 = Hash2(str1);
            
            return filterArray[bitHash1] == 1 && filterArray[bitHash2] == 1;
        }
    }
}