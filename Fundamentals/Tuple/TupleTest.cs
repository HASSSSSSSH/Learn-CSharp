using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Tuple;

[TestClass]
public class TupleTest
{
    private const string TAG = "TupleTest";

    /// <summary>
    /// 声明元组
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        (double, int) tuple1 = (0.1, 1);
        Console.WriteLine($"{TAG}: tuple1 = ({tuple1.Item1}, {tuple1.Item2})");

        (double a, int b) tuple2 = (0.1, 1);
        Console.WriteLine($"{TAG}: tuple2 = ({tuple2.a}, {tuple2.b})");
    }

    /// <summary>
    /// 使用元组自身的方法
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        (string, int) tuple1 = ("ss", 1);
        Console.WriteLine($"{TAG}: tuple1.ToString() = {tuple1.ToString()}");
        Console.WriteLine($"{TAG}: tuple1.GetHashCode() = {tuple1.GetHashCode()}");
    }

    /// <summary>
    /// 始终可以使用字段的默认名称
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        var a = 1;
        var t = (a, b: 2, 3);
        Console.WriteLine($"{TAG}: The 1st element is {t.Item1} (same as {t.a}).");
        Console.WriteLine($"{TAG}: The 2nd element is {t.Item2} (same as {t.b}).");
        Console.WriteLine($"{TAG}: The 3rd element is {t.Item3}.");
    }

    /// <summary>
    /// 使用元组初始化类的属性
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        TempClass instance = new TempClass(0, 1);
        Console.WriteLine($"{TAG}: instance.X = {instance.X}, instance.Y = {instance.Y}");
    }

    /// <summary>
    /// 元组的相等性比较
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        (int, double) tuple1 = (10, 3.14);
        (double First, double Second) tuple2 = (0.1, 1.0);
        (int, int, (double, double)) tuple3 = (1, 2, (1.1, 2.2));

        var temp = tuple2;
        tuple2 = tuple1;
        Console.WriteLine($"{TAG}: (tuple1 == tuple2) = {tuple1 == tuple2}");

        tuple2 = temp;
        tuple1 = ((int, double))tuple2;
        Console.WriteLine($"{TAG}: (tuple1 == tuple2) = {tuple1 == tuple2}");

        // 不能通过编译
        // Console.WriteLine($"{TAG}: (tuple2 == tuple3) = {tuple2 == tuple3}");
    }

    private class TempClass
    {
        public int X { get; }
        public int Y { get; }

        public TempClass(int x, int y)
        {
            (X, Y) = (x, y);
        }
    }
}
