namespace Fundamentals.Class.Member.Constructor;

/// <summary>
/// 构造函数示例
/// </summary>
public class Class1
{
    private const string TAG = "Class1";

    /// <summary>
    /// 静态构造函数
    /// 没有访问修饰符, 没有参数
    /// </summary>
    static Class1()
    {
        Console.WriteLine($"{TAG}: static Class1()");
    }

    // 不提供无参数构造函数
    // public Class1()
    // {
    // }

    /// <summary>
    /// 实例构造函数
    /// </summary>
    public Class1(string name)
    {
        Console.WriteLine($"{TAG}: Class1(string), name = {name}");
    }
}
