using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Struct;

[TestClass]
public class StructTest
{
    private const string TAG = "StructTest";

    /// <summary>
    /// 结构的初始化和默认值
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        SampleStruct struct1 = new SampleStruct();
        Console.WriteLine($"{TAG}: struct1.ToString() = {struct1.ToString()}");

        SampleStruct struct2 = default(SampleStruct);
        Console.WriteLine($"{TAG}: struct2.ToString() = {struct2.ToString()}");

        SampleStruct struct3 = new SampleStruct(1, "SS");
        Console.WriteLine($"{TAG}: struct3.ToString() = {struct3.ToString()}");

        SampleStruct struct4 = struct3;
        struct2.X = 100;
        struct2.Y = "AAA";
        Console.WriteLine($"{TAG}: struct3.ToString() = {struct3.ToString()}");
        Console.WriteLine($"{TAG}: struct4.ToString() = {struct4.ToString()}");
    }

    /// <summary>
    /// 相等性比较
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        SampleStruct struct1 = new SampleStruct(1, "S");
        SampleStruct struct2 = new SampleStruct(100, "AAA");
        Console.WriteLine($"{TAG}: struct1.Equals(struct2) = {struct1.Equals(struct2)}");

        struct1.X = 100;
        struct1.Y = "AAA";
        Console.WriteLine($"{TAG}: struct1.Equals(struct2) = {struct1.Equals(struct2)}");
    }

    /// <summary>
    /// readonly 结构
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        ReadonlyStruct struct1 = new ReadonlyStruct(1, "SS");

        // 不能修改 readonly 结构的成员
        // struct1.Y = "";

        Console.WriteLine($"{TAG}: struct1.ToString() = {struct1.ToString()}");
    }
}
