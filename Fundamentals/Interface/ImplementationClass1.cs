namespace Fundamentals.Interface;

/// <summary>
/// 接口实现类
/// </summary>
public class ImplementationClass1 : ISampleInterface2, ISampleInterface5, ISampleInterface6
{
    private const string TAG = "ImplementationClass1";

    public ImplementationClass1(string name)
    {
        Name = name;
    }

    /// <summary>
    /// 继承自 <see cref="ISampleInterface1.Method1()"/>
    /// </summary>
    public void Method1()
    {
        Console.Out.WriteLine($"{TAG}: Method1()");
    }

    /// <summary>
    /// 继承自 <see cref="ISampleInterface3.Method1(int)"/>
    /// </summary>
    public void Method1(int n)
    {
        Console.Out.WriteLine($"{TAG}: Method1(int)");
    }

    /// <summary>
    /// 继承自 <see cref="ISampleInterface4.Method1(string[])"/>
    /// 由于类实现的 ISampleInterface4 和 ISampleInterface5 接口包含签名相同的成员, 需要使用显式接口实现语法
    /// 需要注意, 无法显式修改访问修饰符
    /// </summary>
    void ISampleInterface4.Method1(string[] items)
    {
        Console.Out.WriteLine($"{TAG}: ISampleInterface4.Method1(string[])");
    }

    /// <summary>
    /// 继承自 <see cref="ISampleInterface5.Method1(string[])"/>
    /// 由于类实现的 ISampleInterface4 和 ISampleInterface5 接口包含签名相同的成员, 需要使用显式接口实现语法
    /// 需要注意, 无法显式修改访问修饰符
    /// </summary>
    void ISampleInterface5.Method1(string[] items)
    {
        Console.Out.WriteLine($"{TAG}: ISampleInterface5.Method1(string[])");
    }

    /// <summary>
    /// 自动实现的属性
    /// 继承自 <see cref="ISampleInterface6.Name"/>
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 继承自 <see cref="ISampleInterface6.Method1(string)"/>
    /// </summary>
    public void Method1(string tag)
    {
        Console.Out.WriteLine($"{TAG}: Method1(string)");
    }
}
