using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Interface;

[TestClass]
public class InterfaceTest
{
    private const string TAG = "InterfaceTest";

    /// <summary>
    /// 使用接口实现类 ImplementationClass1
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        ImplementationClass1 instance = new ImplementationClass1(TAG);

        // 继承自 ISampleInterface1.Method1()
        instance.Method1();

        // 继承自 ISampleInterface3.Method1(int)
        instance.Method1(100);

        // 继承自 ISampleInterface1.Method1()
        ((ISampleInterface4)instance).Method1();

        // 继承自 ISampleInterface4.Method1(string[])
        ((ISampleInterface4)instance).Method1(new[] { "AAA", "B", "ZZZ" });

        // 继承自 ISampleInterface5.Method1(string[])
        ((ISampleInterface5)instance).Method1(new[] { "a", "b", "c" });

        // 继承自 ISampleInterface6.Name
        Console.Out.WriteLine($"{TAG}: instance.Name = {instance.Name}");

        // 继承自 ISampleInterface6.Method1(string)
        instance.Method1("AAA");

        // 直接使用 ISampleInterface2 的默认实现
        Console.Out.WriteLine($"{TAG}: ISampleInterface2.InterfaceName = {ISampleInterface2.InterfaceName}");
        Console.Out.WriteLine($"{TAG}: ISampleInterface2.GetPi() = {ISampleInterface2.GetPi()}");
    }
}
