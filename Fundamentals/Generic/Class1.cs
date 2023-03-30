namespace Fundamentals.Generic;

public class Class1<A, B>
{
    private const string TAG = "Class1<A, B>";

    private A x;
    public A X { get; set; }
    private B? y;
    public B? Y { get; set; }

    public Class1() { }

    public Class1(A x, B y)
    {
        this.x = x;
        X = x;
        this.y = y;
        Y = y;
    }

    /// <summary>
    /// 方法的类型参数 A 与类的类型参数 A 不同
    /// </summary>
    public virtual void Method1<A>(A param)
    {
        Console.Out.WriteLine(param != null
            ? $"{TAG}: Method1<A>(A), param.GetType().Name = {param.GetType().Name}"
            : $"{TAG}: Method1<A>(A), param = null");
    }
}
