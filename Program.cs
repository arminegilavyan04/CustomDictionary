using System;

public class CustomDictionary<TKey, TValue>
{
    private TKey[] keys;
    private TValue[] values;
    private int size;
    private int capacity;

    public CustomDictionary(int initialCapacity = 20)
    {
        capacity = initialCapacity;
        keys = new TKey[capacity];
        values = new TValue[capacity];
        size = 0;
    }
    public void Add(TKey key, TValue value)
    {
        if (size >= capacity)
        {
            Resize();
        }
        keys[size] = key;
        values[size] = value;
        size++;
    }
    public bool GetValue(TKey key, out TValue value)
    {
        for (int i = 0; i < size; i++)
        {
            if (Equals(keys[i], key))
            {
                value = values[i];
                return true;
            }
        }
        value = default;
        return false;
    }
    public bool Remove(TKey key)
    {
        for (int i = 0; i < size; i++)
        {
            if (Equals(keys[i], key))
            {
                
                for (int j = i; j < size - 1; j++)
                {
                    keys[j] = keys[j + 1];
                    values[j] = values[j + 1];
                }
                size--;
                keys[size] = default; 
                values[size] = default; 
                return true;
            }
        }
        return false;
    }
    public int Count => size;
    private void Resize()
    {
        capacity *= 2;
        Array.Resize(ref keys, capacity);
        Array.Resize(ref values, capacity);
    }
    public void Display()
    {
        Console.WriteLine("Dictionary contents:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"  Key: {keys[i]}, Value: {values[i]}");
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        var dictionary = new CustomDictionary<string, int>();

        dictionary.Add("Anna", 25);
        dictionary.Add("Ani", 30);
        dictionary.Add("Artyom", 35);

        Console.WriteLine($"Dictionary before");
        dictionary.Display();


        dictionary.Remove("Ani");

        Console.WriteLine($"Dictionary after");
        dictionary.Display();
        if (dictionary.GetValue("Anna", out int ageAnna))
        {
            Console.WriteLine($"Anna's age: {ageAnna}");
        }

        Console.WriteLine($"Dictionary count after removal: {dictionary.Count}");
    }
}
