namespace Fundamentals.TypeConversion;

public class Class2 : Class1, IInterface
{
    private const string TAG = "Class2";

    int b = Int32.MinValue;
    public int B => b;

    public void Method1()
    {
        Console.Out.WriteLine($"{TAG}: Method1()");
    }
}
