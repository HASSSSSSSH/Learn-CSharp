namespace Fundamentals.ObjectOriented;

public interface IInterface
{
    private const string TAG = "IInterface";

    void Method1(int a);

    /// <summary>
    /// 提供默认实现, 派生类可以不需要实现此方法
    /// </summary>
    void Method2(string s)
    {
        Console.WriteLine($"{TAG}: Method2(string), s = {s}");
    }
}
