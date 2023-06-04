namespace Fundamentals.Generic.Constraint;

public class GenericClass2<T> where T : IEquatable<T>
{
    private const string TAG = "GenericClass2<T>";

    /// <summary>
    /// 类型参数 T 可以用作约束
    /// </summary>
    public static void OpEqualsTest1<U>(U a, U b) where U : T
    {
        Console.Out.WriteLine($"{TAG}: OpEqualsTest1, a.Equals(b) = {a.Equals(b)}");
    }

    /// <summary>
    /// 在使用 where T : class 约束时, 应避免对类型参数使用 == 和 != 运算符
    /// 因为这些运算符仅测试引用标识而不测试值相等性
    /// </summary>
    public static void OpEqualsTest2<U>(U a, U b) where U : class
    {
        Console.Out.WriteLine($"{TAG}: OpEqualsTest2, a == b = {a == b}");
    }
}
