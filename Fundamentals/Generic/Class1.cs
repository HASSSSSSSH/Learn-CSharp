namespace Fundamentals.Generic;

/// <summary>
/// 包含两个类型参数的泛型类
/// </summary>
public class Class1<A, B>
{
    private const string TAG = "Class1<A, B>";

    public A X { get; set; }
    public B? Y { get; set; }

    public Class1()
    {
    }

    public Class1(A x, B y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// 定义一个泛型方法
    /// 方法的类型参数 A 与类的类型参数 A 是不同的
    /// </summary>
    public virtual void Method1<A>(A param)
    {
        Console.Out.WriteLine(param != null
            ? $"{TAG}: Method1[A](A), param.GetType() = {param.GetType()}"
            : $"{TAG}: Method1[A](A), param = null");
    }
}
