namespace Fundamentals.TypeConversion;

/// <summary>
/// 接口 <see cref="ISampleInterface"/> 的实现类
/// </summary>
public class ImplementationClass : ISampleInterface
{
    private const string TAG = "ImplementationClass";

    public void Method1()
    {
        Console.Out.WriteLine($"{TAG}: Method1()");
    }
}
