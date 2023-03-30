namespace Fundamentals.Class.Member.Constructor;

public class Class1
{
    private const string TAG = "Class1";
    const int Default = 1;

    static Class1()
    {
        Console.WriteLine($"{TAG}: static Class1()");
    }

    // public Class1() { }

    public Class1(int a = Default)
    {
        Console.WriteLine($"{TAG}: Class1(int), a = {a}");
    }

    public Class1(int a, int b = Default)
    {
        Console.WriteLine($"{TAG}: Class1(int, int), a = {a}, b = {b}");
    }
}
