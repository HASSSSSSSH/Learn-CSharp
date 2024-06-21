using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class;

[TestClass]
public class ClassTest
{
    private const string TAG = "ClassTest";

    /// <summary>
    /// 创建类的实例
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        // 使用 new 运算符创建 SampleClass 的实例
        SampleClass instance1 = new SampleClass(1, "ss");
        Console.WriteLine($"{TAG}: instance1.ToString() = {instance1.ToString()}");

        // 为变量 instance2 分配对象
        SampleClass instance2 = instance1;
        instance2.X = 10;
        instance2.Y = "AAA";
        Console.WriteLine($"{TAG}: instance1.ToString() = {instance1.ToString()}");
        Console.WriteLine($"{TAG}: instance2.ToString() = {instance2.ToString()}");

        // 向方法传入引用
        LocalFunction(instance2);

        void LocalFunction(SampleClass instance)
        {
            // 为变量 instance 分配新的对象
            instance = new SampleClass(100, "ZZZ");

            Console.WriteLine($"{TAG}: instance.ToString() = {instance.ToString()}");
            Console.WriteLine($"{TAG}: instance1.ToString() = {instance1.ToString()}");
            Console.WriteLine($"{TAG}: instance2.ToString() = {instance2.ToString()}");
        }
    }

    /// <summary>
    /// 类的相等性比较
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        SampleClass instance1 = new SampleClass(1, "AAA");
        SampleClass instance2 = instance1;
        Console.WriteLine($"{TAG}: (instance1 == instance2) = {instance1 == instance2}");
        Console.WriteLine($"{TAG}: instance1.Equals(instance2) = {instance1.Equals(instance2)}");

        SampleClass instance3 = new SampleClass(10, "ZZZ");
        Console.WriteLine($"{TAG}: (instance1 == instance3) = {instance1 == instance3}");
        Console.WriteLine($"{TAG}: instance1.Equals(instance3) = {instance1.Equals(instance3)}");

        instance3.X = 1;
        instance3.Y = "AAA";
        Console.WriteLine($"{TAG}: (instance1 == instance3) = {instance1 == instance3}");
        Console.WriteLine($"{TAG}: instance1.Equals(instance3) = {instance1.Equals(instance3)}");
    }
}
