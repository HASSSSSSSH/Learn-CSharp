using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.NullableRefType;

[TestClass]
public class NullableRefTypeTest
{
    private const string TAG = "NullableRefTypeTest";

    /// <summary>
    /// 使用可为 null 的引用类型
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        string a;
        string? b = null;
        string? c = default;

        a = b;
        if (a == null)
        {
            Console.Out.WriteLine($"{TAG}: a = null");
        }

        // 使用 null 包容运算符, 取消编译器警告
        a = c!;
        if (a == null)
        {
            Console.Out.WriteLine($"{TAG}: a = null");
        }

        c = "Test";
        Console.Out.WriteLine($"{TAG}: c = {c}");
    }

    /// <summary>
    /// 控制可为 null 的上下文
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
#nullable disable

        // 出现编译器警告
        string? a = null;

        if (a == null)
        {
            Console.Out.WriteLine($"{TAG}: a = null");
        }

#nullable enable
        string? b = default;
        if (b == null)
        {
            Console.Out.WriteLine($"{TAG}: b = null");
        }
    }
}
