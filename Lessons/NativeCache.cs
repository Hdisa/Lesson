namespace AlgorithmsDataStructures;

public class NativeCache<T>
{
    private const int step = 1;
    private int size;
    public String [] slots;
    public T [] values;
    public int [] hits;
    
    public NativeCache(int sz)
    {
        size = sz;
        slots = new string[size];
        values = new T[size];
        hits = new int[size];
    }
    
    public T Get(string key)
    {
        int hash = HashFunction(key);
        int stepScale = 0;
        while (stepScale < size)
        {
            if (slots[hash] == null)
                return default(T);

            if (slots[hash] == key)
            {
                hits[hash]++;
                return values[hash];
            }
            
            hash += step;
            hash %= size;
            stepScale += step;
        }

        return default(T);
    }
    
    public void Put(string key, T value)
    {
        if(key == null)
            return;

        int hash = HashFunction(key);
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

        int index = SeekSlot(key);
        
        if (index == -1)
            index = RemoveLeastFrequentlyUsed();
            
        slots[index] = key;
        values[index] = value;
    }
    
    private int HashFunction(string key)
    {
        int hash = 0;
        byte[] data = System.Text.Encoding.UTF8.GetBytes(key);
        for (int i = 0; i < data.Length; i++) hash += data[i];
            
        return hash % size;
    }
    
    private int RemoveLeastFrequentlyUsed()
    {
        int minHit = Int32.MaxValue;
        int index = 0;

        for (int i = 1; i < hits.Length; i++)
        {
            if (hits[i] < minHit)
            {
                minHit = hits[i];
                index = i;
            }
        }

        slots[index] = null;
        values[index] = default(T);
        hits[index] = 0;
        return index;
    }
    
    private int SeekSlot(String value)
    {
        int curSlot = HashFunction(value);
        int localStep = step;

        for(int i = curSlot; localStep > 0; i += localStep)
        {
            if(i >= size)
            {
                localStep--;
                i = 0;
            }
            if(slots[i] == null)
                return i;
        }

        return -1;
    }
}