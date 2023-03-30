#pragma warning disable CS0659
#pragma warning disable CS0660, CS0661
namespace Fundamentals.Class.Member.Operator;

public class Class1
{
    private const string TAG = "Class1";

    public int[] items;

    public Class1(int capacity)
    {
        items = new int[capacity];
    }

    public int this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public static bool operator ==(Class1 a, Class1 b)
    {
        return Equals(a, b);
    }

    public static bool operator !=(Class1 a, Class1 b)
    {
        return !Equals(a, b);
    }

    public override bool Equals(object? obj)
    {
        return Equals(this, obj as Class1);
    }

    private static bool Equals(Class1 a, Class1 b)
    {
        if (ReferenceEquals(a, null))
        {
            return ReferenceEquals(b, null);
        }

        if (ReferenceEquals(b, null) || a.items.Length != b.items.Length)
        {
            return false;
        }

        for (int i = 0; i < a.items.Length; i++)
        {
            if (!Equals(a.items[i], b.items[i]))
            {
                return false;
            }
        }

        return true;
    }
}
