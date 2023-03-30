namespace Fundamentals.Interface;

public class InterfaceImplementClass : IInterface5, IInterface4
{
    private const string TAG = "InterfaceImplementClass";

    /// <summary>
    /// Implement from <see cref="IInterface1.Method1()"/>
    /// </summary>
    public void Method1()
    {
        Console.Out.WriteLine($"{TAG}: Method1()");
    }

    /// <summary>
    /// Implement from <see cref="IInterface2.Method1(string)"/>
    /// </summary>
    public void Method1(string s)
    {
        Console.Out.WriteLine($"{TAG}: Method1(string)");
    }

    /// <summary>
    /// Implement from <see cref="IInterface3.Method1(string[])"/>
    /// 需要注意的是, 无法显式修改访问修饰符
    /// </summary>
    void IInterface3.Method1(string[] items)
    {
        Console.Out.WriteLine($"{TAG}: IInterface3.Method1(string[])");
    }

    /// <summary>
    /// Implement from <see cref="IInterface4.Method1(string[])"/>
    /// 需要注意的是, 无法显式修改访问修饰符
    /// </summary>
    void IInterface4.Method1(string[] items)
    {
        Console.Out.WriteLine($"{TAG}: IInterface4.Method1(string[])");
    }

    /// <summary>
    /// Implement from <see cref="IInterface5.Method1(int)"/>
    /// </summary>
    public void Method1(int a)
    {
        Console.Out.WriteLine($"{TAG}: Method1(int)");
    }

    /// <summary>
    /// Implement from <see cref="IInterface5.Method1(int?)"/>
    /// </summary>
    public void Method1(int? a)
    {
        Console.Out.WriteLine($"{TAG}: Method1(int?)");
    }

    /// <summary>
    /// Implement from <see cref="IInterface5.Method2(int[])"/>
    /// </summary>
    public void Method2(int[] array)
    {
        Console.Out.WriteLine($"{TAG}: Method2(int[])");
    }
}
