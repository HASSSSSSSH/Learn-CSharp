namespace Fundamentals.Generic;

/// <summary>
/// Class3 继承自 Class1
/// 将 Class3 的类型参数 T 指定给 Class1 的类型参数 A 和 B
/// </summary>
public class Class3<T> : Class1<T, T>
{
    private const string TAG = "Class3<T>";

    /// <summary>
    /// 此方法直接使用类的类型参数 T
    /// </summary>
    public void Method1(T param)
    {
        base.X = param!;
        base.Y = param!;

        Console.Out.WriteLine($"{TAG}: Method1(T), typeof(T) = {typeof(T)}");
        Console.Out.WriteLine($"{TAG}: Method1(T), base.X.GetType() = {base.X.GetType()}");
        Console.Out.WriteLine($"{TAG}: Method1(T), base.Y.GetType() = {base.Y.GetType()}");
    }
}
