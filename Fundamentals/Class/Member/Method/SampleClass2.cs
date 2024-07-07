namespace Fundamentals.Class.Member.Method;

/// <summary>
/// 方法重载
/// </summary>
public class SampleClass2
{
    public static void F() => Console.WriteLine("F()");

    // 方法签名重复
    // internal static void F() => Console.WriteLine("F()");

    // 方法签名重复
    // public static string F() => "SampleClass2";

    public static void F(object x) => Console.WriteLine("F(object)");

    public static void F(int x) => Console.WriteLine("F(int)");

    public static void F(double x) => Console.WriteLine("F(double)");

    public static void F<T>(T x) => Console.WriteLine($"F<T>(T), T is {typeof(T)}");

    public static void F(double x, double y) => Console.WriteLine("F(double, double)");

    public static void F(double x, int y) => Console.WriteLine("F(double, int)");

    public static void F(int x, double y) => Console.WriteLine("F(int, double)");

    public static void F(int x, out double y)
    {
        Console.WriteLine("F(int, out double)");
        y = x;
    }

    // 方法签名重复
    // public static void F(int x, ref double y)
    // {
    //     Console.WriteLine("F(int, ref double)");
    //     y = x;
    // }
}
