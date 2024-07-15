namespace Fundamentals.ObjectOriented;

/// <summary>
/// interface 示例
/// </summary>
public interface ISampleInterface
{
    private const string TAG = "ISampleInterface";

    /// <summary>
    /// 接口方法
    /// </summary>
    void Method1();

    /// <summary>
    /// 接口方法
    /// 由于此方法提供默认实现, 接口实现类可以不实现此方法
    /// </summary>
    void Method2(string s)
    {
        Console.WriteLine($"{TAG}: Method2(string)");
    }
}
