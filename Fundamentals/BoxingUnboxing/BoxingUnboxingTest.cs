using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.BoxingUnboxing;

[TestClass]
public class BoxingUnboxingTest
{
    private const string TAG = "BoxingUnboxingTest";

    [TestMethod]
    public void TestMethod1()
    {
        // 值类型
        int i = 123;

        // 装箱
        object obj = i;

        // 不会改变包装在 obj 中的 int 类型的值
        i = 321;

        // 取消装箱
        int j = (int)obj;

        Console.Out.WriteLine($"{TAG}: TestMethod1, i = {i}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, j = {j}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, concat string = \"{String.Concat("Answer", 42, true)}\"");
    }

    /// <summary>
    /// 尝试对 null 进行取消装箱会导致 NullReferenceException
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        int? i = default;
        object obj = i;

        try
        {
            int j = (int)obj;
            Console.Out.WriteLine($"{TAG}: TestMethod2, j = {j}");
        }
        catch (NullReferenceException e)
        {
            Console.Out.WriteLine($"{TAG}: TestMethod2 throw NullReferenceException, e = {e}");
        }
    }

    /// <summary>
    /// 尝试对不兼容值类型的引用进行取消装箱会导致 InvalidCastException
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        int i = 123;
        object obj = i;

        try
        {
            long j = (long)obj;
            Console.Out.WriteLine($"{TAG}: TestMethod3, j = {j}");
        }
        catch (InvalidCastException e)
        {
            Console.Out.WriteLine($"{TAG}: TestMethod3 throw InvalidCastException, e = {e}");
        }

        try
        {
            int k = (short)obj;
            Console.Out.WriteLine($"{TAG}: TestMethod3, k = {k}");
        }
        catch (InvalidCastException e)
        {
            Console.Out.WriteLine($"{TAG}: TestMethod3 throw InvalidCastException, e = {e}");
        }
    }
}
