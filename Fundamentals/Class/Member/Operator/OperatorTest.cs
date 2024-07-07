using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Operator;

[TestClass]
public class OperatorTest
{
    private const string TAG = "OperatorTest";

    /// <summary>
    /// 使用重载运算符
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        SampleClass instance1 = new SampleClass(3)
        {
            [0] = 100,
            [1] = 1000,
            [2] = 10000,
        };
        SampleClass instance2 = new SampleClass(3)
        {
            [0] = 100,
            [1] = 1000,
        };

        Console.WriteLine($"{TAG}: (instance1 == instance2) = {instance1 == instance2}");
        Console.WriteLine($"{TAG}: (instance1 != instance2) = {instance1 != instance2}");

        // 赋值, 使得两个实例相等
        instance2[2] = 10000;

        Console.WriteLine($"{TAG}: (instance1 == instance2) = {instance1 == instance2}");
        Console.WriteLine($"{TAG}: (instance1.Equals(instance2)) = {instance1.Equals(instance2)}");

        // 令 instance1 为 null, 判断与 null 的相等性
        instance1 = null;
        Console.WriteLine($"{TAG}: (instance1 == null) = {instance1 == null}");
    }
}
