using System.Numerics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Equality;

[TestClass]
public class EqualityTest
{
    private const string TAG = "EqualityTest";

    /// <summary>
    /// 比较引用类型的引用相等性
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        SampleClass instance1 = new SampleClass(1, "AAA");
        SampleClass instance2 = instance1;
        Console.WriteLine($"{TAG}: ReferenceEquals(instance1, instance2) = {ReferenceEquals(instance1, instance2)}");

        // 令 instance2 引用新的对象
        instance2 = new SampleClass(1, "AAA");
        Console.WriteLine($"{TAG}: ReferenceEquals(instance1, instance2) = {ReferenceEquals(instance1, instance2)}");

        // 令 instance1 和 instance2 同时为 null
        instance1 = instance2 = null;
        Console.WriteLine($"{TAG}: ReferenceEquals(instance1, instance2) = {ReferenceEquals(instance1, instance2)}");
    }

    /// <summary>
    /// 比较 string 的引用相等性
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        string str1 = "Equality Test!";
        string str2 = "Equality Test!";
        string str3 = "Equality" + " Test!";

        // 运行时始终暂存同一程序集内的常量字符串, 因此一个文本字符串只有一个实例
        Console.WriteLine($"{TAG}: ReferenceEquals(str1, str2) = {ReferenceEquals(str1, str2)}");
        Console.WriteLine($"{TAG}: ReferenceEquals(str1, str3) = {ReferenceEquals(str1, str3)}");

        string s = "Equality";
        string str4 = s + " Test!";
        Console.WriteLine($"{TAG}: ReferenceEquals(str1, str4) = {ReferenceEquals(str1, str4)}");

        StringBuilder builder = new StringBuilder("Equality Test!");
        string str5 = builder.ToString();

        // 运行时不能保证会暂存在运行时创建的字符串, 也不保证会暂存不同程序集中两个相等的常量字符串
        Console.WriteLine($"{TAG}: ReferenceEquals(str1, str5) = {ReferenceEquals(str1, str5)}");
    }

    /// <summary>
    /// 测试值类型的引用相等性
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        Vector2 point1 = new Vector2(0, 1);
        Vector2 point2 = point1;

        // 值类型对象无法具有引用相等性
        Console.WriteLine($"{TAG}: ReferenceEquals(point1, point2) = {ReferenceEquals(point1, point2)}");
    }

    /// <summary>
    /// 比较引用类型的值相等性
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        SampleClass instance1 = new SampleClass(1, "AAA");
        SampleClass instance2 = new SampleClass(1, "AAA");
        Console.WriteLine($"{TAG}: (instance1 == instance2) = {instance1 == instance2}");

        // 令 instance1 和 instance2 同时为 null
        instance1 = instance2 = null;
        Console.WriteLine($"{TAG}: (instance1 == instance2) = {instance1 == instance2}");
    }

    /// <summary>
    /// 比较值类型的值相等性
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        Vector2 point1 = new Vector2(0, 1);
        Vector2 point2 = point1;

        // Vector2 重写了 Equals 方法, 可用于比较值相等性
        Console.WriteLine($"{TAG}: point1.Equals(point2) = {point1.Equals(point2)}");
    }

    /// <summary>
    /// 比较 float 的值相等性
    /// </summary>
    [TestMethod]
    public void TestMethod6()
    {
        const float epsilon = 1E-6f;

        float a = 1f;
        float b = 3 - 0.9f - 1.1f;

        Console.WriteLine($"{TAG}: a = {a}, b = {b}");

        // 使用 == 运算符比较浮点数在舍入值时可能会损失精度
        Console.WriteLine($"{TAG}: (a == b) = {a == b}");

        // 应通过两个浮点数的差值的绝对值是否小于某个可以接受的值来判断是否相等
        Console.WriteLine($"{TAG}: (Math.Abs(a - b) < float.Epsilon) = {Math.Abs(a - b) < float.Epsilon}");
        Console.WriteLine($"{TAG}: (Math.Abs(a - b) < epsilon) = {Math.Abs(a - b) < epsilon}");
    }

    /// <summary>
    /// 比较 double 的值相等性
    /// </summary>
    [TestMethod]
    public void TestMethod7()
    {
        const double epsilon = 1E-9f;

        double a = 1.0000000001;
        double b = 3 - 0.9 - 1.1;

        Console.WriteLine($"{TAG}: a = {a}, b = {b}");

        // 使用 == 运算符比较浮点数在舍入值时可能会损失精度
        Console.WriteLine($"{TAG}: (a == b) = {a == b}");

        // 应通过两个浮点数的差值的绝对值是否小于某个可以接受的值来判断是否相等
        Console.WriteLine($"{TAG}: (Math.Abs(a - b) < double.Epsilon) = {Math.Abs(a - b) < double.Epsilon}");
        Console.WriteLine($"{TAG}: (Math.Abs(a - b) < epsilon) = {Math.Abs(a - b) < epsilon}");
    }
}
