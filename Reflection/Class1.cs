namespace Reflection;

public class Class1
{
    private const string TAG = "Class1";

    public static string TAG2 = "Class1";

    public string tag = "Class1";

    public event EventHandler? eventHandler;

    private int a;

    private string b;

    public int A
    {
        get => a;
        set => a = value;
    }

    public string B
    {
        get => b;
        set => b = value;
    }

    private Class1()
    {
        Console.WriteLine($"{TAG}: Class1()");
    }

    public Class1(int a)
    {
        Console.WriteLine($"{TAG}: Class1(int)");
        A = a;
    }

    public Class1(string b)
    {
        Console.WriteLine($"{TAG}: Class1(string)");
        B = b;
    }

    public Class1(int a, string b)
    {
        Console.WriteLine($"{TAG}: Class1(int, string)");
        A = a;
        B = b;
    }

    public void Method1()
    {
        Console.WriteLine($"{TAG}: Method1()");
    }

    private int Method2(int i, int j)
    {
        Console.WriteLine($"{TAG}: Method2(int, int)");
        return i + j;
    }

    public static string Method3(string s)
    {
        Console.WriteLine($"{TAG}: Method3(string)");
        return s;
    }

    public void InvokeEventHandler()
    {
        eventHandler?.Invoke(this, EventArgs.Empty);
    }
}
