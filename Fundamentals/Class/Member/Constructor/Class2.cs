namespace Fundamentals.Class.Member.Constructor;

/// <summary>
/// 构造函数示例
/// Class2 继承自 <see cref="Class1"/>
/// </summary>
public class Class2 : Class1
{
    private const string TAG = "Class2";

    /// <summary>
    /// 静态构造函数
    /// </summary>
    static Class2()
    {
        Console.WriteLine($"{TAG}: static Class2()");
    }

    /// <summary>
    /// 提供无参数构造函数
    /// 由于基类没有提供无参数构造函数, 派生类必须使用 base 显式调用基类构造函数
    /// </summary>
    public Class2() : base(TAG)
    {
        Console.WriteLine($"{TAG}: Class2()");
    }

    /// <summary>
    /// 实例构造函数
    /// 由于基类没有提供无参数构造函数, 派生类必须使用 base 显式调用基类构造函数
    /// </summary>
    public Class2(string name) : base(name)
    {
        Console.WriteLine($"{TAG}: Class2(string)");
    }

    /// <summary>
    /// 可以定义多个实例构造函数
    /// 可以使用 this 关键字调用同一对象中的另一构造函数
    /// </summary>
    public Class2(int a, int b) : this(a, b, default)
    {
        Console.WriteLine($"{TAG}: Class1(int, int)");
    }

    /// <summary>
    /// 可以定义多个实例构造函数
    /// </summary>
    public Class2(int a, int b, int c = 1) : base(TAG)
    {
        Console.WriteLine($"{TAG}: Class1(int, int, int)");
    }
}
