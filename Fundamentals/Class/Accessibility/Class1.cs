namespace Fundamentals.Class.Accessibility;

public class Class1
{
    private const string TAG = "Class1";
    public const string CONST_A = "CONST_A";
    public static string StaticA = "StaticA";
    private int a;
    public int A { get; set; }

    public Class1(int a)
    {
        A = a;
    }

    private void method1()
    {
        Console.WriteLine($"{TAG}: method1()");
    }

    protected void method2()
    {
        Console.WriteLine($"{TAG}: method2()");
    }

    public void method3()
    {
        Console.WriteLine($"{TAG}: method3()");
    }

    internal void method4()
    {
        Console.WriteLine($"{TAG}: method4()");
    }

    void method5()
    {
        Console.WriteLine($"{TAG}: method5()");
    }

    protected internal void method6()
    {
        Console.WriteLine($"{TAG}: method6()");
    }

    private protected void method7()
    {
        Console.WriteLine($"{TAG}: method7()");
    }
}
