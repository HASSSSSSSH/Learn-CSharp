using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Method;

[TestClass]
public class OverloadingTest
{
    [TestMethod]
    public void TestMethod1()
    {
        // 调用 F()
        F();

        // 调用 F(int)
        F(1);

        // 调用 F(double)
        F(1.0);

        // 调用 F<T>(T), T 的类型是 System.String
        F("abc");

        // 调用 F(double)
        F((double)1);

        // 调用 F(object)
        F((object)1);

        // 调用 F<T>(T), T 的类型是 System.Int32
        F<int>(1);

        // 调用 F(double, double)
        F(1.0, 1.0);

        // 调用 F(int, double)
        F(1, 1.0);

        // 调用 F(double, int)
        F(1.0, 1);
    }

    static void F() => Console.WriteLine("F()");

    static void F(object x) => Console.WriteLine("F(object)");

    static void F(int x) => Console.WriteLine("F(int)");

    static void F(double x) => Console.WriteLine("F(double)");

    static void F<T>(T x) => Console.WriteLine($"F<T>(T), T is {typeof(T)}");

    static void F(double x, double y) => Console.WriteLine("F(double, double)");

    static void F(int x, double y) => Console.WriteLine("F(int, double)");

    static void F(double x, int y) => Console.WriteLine("F(double, int)");
}
