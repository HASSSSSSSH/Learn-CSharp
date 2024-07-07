using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Field;

[TestClass]
public class FieldTest
{
    private const string TAG = "FieldTest";

    /// <summary>
    /// 使用类的字段
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        // 直接使用类的 static 字段, 无需实例化
        ++SampleClass.counter;

        // 实例化 SampleClass
        SampleClass instance = new SampleClass();

        // 不能通过类的实例访问 static 字段
        // ++instance.counter;

        // 通过类的实例访问实例字段
        instance.str = instance.str.Substring(0, instance.str.Length - 1);

        Console.WriteLine($"{TAG}: counter = {SampleClass.counter}, instance.str = {instance.str}");
    }
}
