namespace Fundamentals.Generic.Constraint;

/// <summary>
/// 测试使用类型参数约束时的相等性
/// </summary>
public class SampleClass2<T> where T : IEquatable<T>
{
    private const string TAG = "SampleClass2<T>";

    /// <summary>
    /// 在使用 where T : class 约束时, 应避免对类型参数使用 == 和 != 运算符
    /// 因为这些运算符仅测试引用标识而不测试值相等性
    /// 即使在用作参数的类型中重载这些运算符也会发生此行为
    /// </summary>
    public static void OpEqualsTest<U>(U a, U b) where U : class
    {
        Console.Out.WriteLine($"{TAG}: OpEqualsTest, (a == b) = {a == b}");
    }

    /// <summary>
    /// 使用 Equals 方法来测试相等性
    /// 注意, 类的类型参数 T 也可以用作约束
    /// </summary>
    public static void EqualsTest<U>(U a, U b) where U : T
    {
        Console.Out.WriteLine($"{TAG}: EqualsTest, (a.Equals(b)) = {a.Equals(b)}");
    }
}
