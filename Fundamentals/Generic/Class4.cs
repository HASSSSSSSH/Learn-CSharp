namespace Fundamentals.Generic;

/// <summary>
/// Class4 继承自 Class1
/// 在类的声明中直接指定 Class1 的类型参数
/// </summary>
public class Class4 : Class1<int, string>
{
    private const string TAG = "Class4";

    /// <summary>
    /// Method1[T](T) 是泛型方法, 继承自 Class1`2[K,V]
    /// </summary>
    public override void Method1<T>(T param)
    {
        base.X = 10;
        base.Y = "AAA";

        Console.Out.WriteLine($"{TAG}: Method1<T>(T), typeof(T) = {typeof(T)}");
        Console.Out.WriteLine($"{TAG}: Method1<T>(T), base.X.GetType() = {base.X.GetType()}");
        Console.Out.WriteLine($"{TAG}: Method1<T>(T), base.Y.GetType() = {base.Y.GetType()}");
    }
}
