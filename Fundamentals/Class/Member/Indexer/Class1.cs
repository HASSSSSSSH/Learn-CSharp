namespace Fundamentals.Class.Member.Indexer;

public class Class1
{
    private const string TAG = "Class1";

    private int[] items;

    public Class1(int capacity)
    {
        items = new int[capacity];
        for (int i = 0; i < capacity; i++)
        {
            items[i] = i;
        }
    }

    public int this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public int this[int index, char s]
    {
        get
        {
            Console.WriteLine($"{TAG}: Class1.this[int, char].get, s = {s}");
            return items[index];
        }
        set
        {
            Console.WriteLine($"{TAG}: Class1.this[int, char].set, value = {value}");
            items[index] = s - 'a';
        }
    }
}
