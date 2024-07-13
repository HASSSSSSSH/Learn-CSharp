namespace Fundamentals.Class.Accessibility;

/// <summary>
/// 可访问性的测试
/// </summary>
public class Class1
{
    private const string TAG = "Class1";

    /// <summary>
    /// 使用 private 修饰符
    /// 只有在同一 class 或 struct 中声明的代码才能访问此成员
    /// </summary>
    private void method1()
    {
        Console.WriteLine($"{TAG}: private void method1()");
    }

    /// <summary>
    /// 默认情况下, 类成员和结构成员 (包括嵌套的类和结构) 的访问级别为 private
    /// </summary>
    void method2()
    {
        Console.WriteLine($"{TAG}: void method2()");
    }

    /// <summary>
    /// 使用 private protected 修饰符
    /// 只有同一程序集和同一个类或派生类中的代码才能访问此类型或成员
    /// </summary>
    private protected void method3()
    {
        Console.WriteLine($"{TAG}: private protected void method3()");
    }

    /// <summary>
    /// 使用 internal 修饰符
    /// 只有同一程序集中的代码才能访问此类型或成员
    /// </summary>
    internal void method4()
    {
        Console.WriteLine($"{TAG}: internal void method4()");
    }

    /// <summary>
    /// 使用 protected 修饰符
    /// 只有同一 class 或派生的 class 中的代码才能访问此类型或成员
    /// </summary>
    protected void method5()
    {
        Console.WriteLine($"{TAG}: protected void method5()");
    }

    /// <summary>
    /// 使用 protected internal 修饰符
    /// 只有同一程序集中的代码或另一个程序集的派生类中的代码才能访问此类型或成员
    /// </summary>
    protected internal void method6()
    {
        Console.WriteLine($"{TAG}: protected internal void method6()");
    }

    /// <summary>
    /// 使用 public 修饰符
    /// 任何程序集中的代码都可以访问此类型或成员
    /// </summary>
    public void method7()
    {
        Console.WriteLine($"{TAG}: public void method7()");
    }
}
