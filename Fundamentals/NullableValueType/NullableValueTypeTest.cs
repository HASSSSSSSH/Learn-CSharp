using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.NullableValueType;

[TestClass]
public class NullableValueTypeTest
{
    private const string TAG = "NullableValueTypeTest";

    /// <summary>
    /// 声明可为 null 值类型
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        int n1 = 1;
        int? n2 = n1;
        int? n3 = null;
        Console.Out.WriteLine($"{TAG}: n1 = {n1}, n2 = {n2}, n3 = {n3}");

        int?[] arr = { n1, n2, n3 };
        Console.Out.WriteLine($"{TAG}: arr[0] = {arr[0]}, arr[1] = {arr[1]}, arr[2] = {arr[2]}");
    }

    /// <summary>
    /// 检查可为 null 值类型的实例
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        int n1 = 1;
        int? n2 = n1;
        int? n3 = default;

        if (n1 is int valueOfN1)
        {
            Console.WriteLine($"n1 = {valueOfN1}");
        }

        if (n2 is int valueOfN2)
        {
            Console.WriteLine($"n2 = {valueOfN2}");
        }

        if (!(n3 is int))
        {
            Console.WriteLine("n3 = null");
        }

        if (n2.HasValue)
        {
            Console.WriteLine($"n2 = {n2.Value}");
        }

        if (!n3.HasValue)
        {
            Console.WriteLine("n3 = null");
        }

        if (n3 == null)
        {
            Console.WriteLine("n3 = null");
        }
    }

    /// <summary>
    /// 从可为 null 的值类型转换为基础类型
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        int? a = 1;
        int b = a ?? -1;
        Console.WriteLine($"b = {b}");

        int? c = null;
        int d = c ?? -1;
        int e = c.GetValueOrDefault(int.MinValue);
        int f = c.GetValueOrDefault();
        Console.WriteLine($"d = {d}");
        Console.WriteLine($"e = {e}");
        Console.WriteLine($"f = {f}");
    }

    /// <summary>
    /// 对可为 null 的值类型进行装箱和取消装箱
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        int a = 10;
        object aBoxed = a;
        int? aNullable = (int?)aBoxed;
        int? b = null;
        object? bBoxed = b;
        int? bNullable = (int?)bBoxed;

        Console.WriteLine($"aNullable = {aNullable}");
        Console.WriteLine($"bNullable = {bNullable}");

        object aNullableBoxed = aNullable;
        if (aNullableBoxed is int valueOfA)
        {
            Console.WriteLine($"aNullableBoxed = {aNullableBoxed}, valueOfA = {valueOfA}");
        }

        object? bNullableBoxed = bNullable;
        if (bNullableBoxed == null)
        {
            Console.WriteLine("bNullableBoxed = null");
        }
    }

    /// <summary>
    /// 确定 System.Type 实例是否表示已构造的可为 null 值类型
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        int? a = 1;
        int? b = null;
        int n = 10;

        // 不能通过 GetType 方法来判断是否是可为 null 值类型
        Type typeOfA = a.GetType();
        Console.WriteLine(typeOfA.FullName);

        // 不能通过 is 运算符来判断是否是可为 null 值类型
        if (a is int)
        {
            Console.WriteLine("int? instance is compatible with int");
        }

        if (n is int?)
        {
            Console.WriteLine("int instance is compatible with int?");
        }

        // 使用 System.Nullable.GetUnderlyingType 方法
        bool IsNullable(object? obj)
        {
            return obj == null || System.Nullable.GetUnderlyingType(obj.GetType()) != null;
        }

        Console.WriteLine($"b is {(IsNullable(b) ? "nullable" : "non nullable")} value type");
        Console.WriteLine($"n is {(IsNullable(n) ? "nullable" : "non-nullable")} value type");
    }
}
