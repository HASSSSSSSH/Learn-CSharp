namespace Fundamentals.Class.Member.Constructor;

/// <summary>
/// 单例模式
/// </summary>
public sealed class Singleton
{
    private const string TAG = "Singleton";
    private static readonly Singleton instance = new Singleton();

    /// <summary>
    /// 显式定义静态构造函数可以防止添加 BeforeFieldInit 类型特性
    /// </summary>
    static Singleton()
    {
        Console.WriteLine($"{TAG}: static Singleton()");
    }

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private Singleton()
    {
        Console.WriteLine($"{TAG}: Singleton()");
    }

    public static Singleton Instance
    {
        get { return instance; }
    }
}
