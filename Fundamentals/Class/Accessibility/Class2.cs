namespace Fundamentals.Class.Accessibility;

/// <summary>
/// 可访问性的测试
/// Class2 继承自 <see cref="Class1"/>
/// </summary>
public class Class2 : Class1
{
    /// <summary>
    /// 测试同一程序集的 Class1 派生类中的代码对 Class1 成员的可访问性
    /// </summary>
    public void TestAccess()
    {
        // 不可访问
        // base.method1();
        // base.method2();

        base.method3();
        base.method4();
        base.method5();
        base.method6();
        base.method7();
    }
}
