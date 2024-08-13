namespace Fundamentals.Reflection.Generic;

/// <summary>
/// 包含两个类型参数的泛型类
/// </summary>
public class GenericClass1<A, B>
{
    private const string TAG = "Generic.GenericClass1<A, B>";

    public A X { get; set; }
    public B? Y { get; set; }

    public GenericClass1()
    {
    }

    public GenericClass1(A x, B y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// 包含一个类型参数的泛型方法
    /// </summary>
    public virtual void Method1<T>(T param)
    {
        Console.Out.WriteLine($"{TAG}: Method1<T>(T), typeof(T) = {typeof(T)}");
    }
}
