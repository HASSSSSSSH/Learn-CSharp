using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Accessibility;

[TestClass]
public class AccessibilityTest
{
    /// <summary>
    /// 测试同一程序集中的代码对 Class1 成员的可访问性
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Class1 instance = new Class1();

        // 不可访问
        // instance.method1();
        // instance.method2();
        // instance.method3();

        instance.method4();

        // 不可访问
        // instance.method5();

        instance.method6();
        instance.method7();
    }

    /// <summary>
    /// 测试同一程序集的 Class1 派生类中的代码对 Class1 成员的可访问性
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        Class2 instance = new Class2();
        instance.TestAccess();
    }
}
