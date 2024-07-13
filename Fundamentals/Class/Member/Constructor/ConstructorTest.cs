using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Constructor;

[TestClass]
public class ConstructorTest
{
    private const string TAG = "ConstructorTest";

    /// <summary>
    /// 调用不同的构造函数
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Class2 instance1 = new Class2();
        Console.WriteLine();

        Class2 instance2 = new Class2("instance2");
        Console.WriteLine();

        Class2 instance3 = new Class2(0, 1);
        Console.WriteLine();

        Class2 instance4 = new Class2(0, 1, default);
        Console.WriteLine();
    }

    /// <summary>
    /// 单例模式
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        Console.WriteLine($"{TAG}: Singleton.Instance.GetHashCode() = {Singleton.Instance.GetHashCode()}");
    }
}
