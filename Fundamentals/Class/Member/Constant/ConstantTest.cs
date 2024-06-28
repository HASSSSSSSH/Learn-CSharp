using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Constant;

[TestClass]
public class ConstantTest
{
    private const string TAG = "ConstantTest";

    /// <summary>
    /// 使用常量
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine($"{TAG}: Constants.Tag = {Constants.Tag}");
        Console.WriteLine($"{TAG}: Math.Sin(Constants.Pi / 2) = {Math.Sin(Constants.Pi / 2)}");
    }

    /// <summary>
    /// 使用 readonly 字段
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        SampleClass instance1 = new SampleClass();
        Console.WriteLine($"{TAG}: instance1.index = {instance1.index}");
        Console.WriteLine($"{TAG}: instance1.dateTime = {instance1.dateTime}");

        // 可以修改字段的实例数据
        instance1.dictionary!.Add("AAA", 1);
        instance1.dictionary.Add("zzz", 2);
        Console.WriteLine($"{TAG}: instance1.dictionary.Count = {instance1.dictionary.Count}");

        // 不能重新赋值
        // instance1.index++;
        // instance1.dateTime = DateTime.Today;
        // instance1.dictionary = null;

        // 在不同的实例, readonly 字段的值可能不同
        SampleClass instance2 = new SampleClass(DateTime.Today);
        Console.WriteLine($"{TAG}: instance2.dateTime = {instance2.dateTime}");
    }
}
