using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.BoxingUnboxing;

[TestClass]
public class BoxingUnboxingTest
{
    private const string TAG = "BoxingUnboxingTest";

    /// <summary>
    /// 装箱和取消装箱 int 类型
    /// </summary>
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

        Console.Out.WriteLine($"{TAG}: i = {i}, j = {j}");
    }

    /// <summary>
    /// 隐式对值类型进行装箱
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        Console.Out.WriteLine($"{TAG}: concat string = \"{string.Concat("Answer", new Vector2(1, 1), true)}\"");
    }

    /// <summary>
    /// 尝试对 null 进行取消装箱会导致 NullReferenceException
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        int? i = null;
        object obj = i;

        try
        {
            int j = (int)obj;
            Console.Out.WriteLine($"{TAG}: j = {j}");
        }
        catch (NullReferenceException e)
        {
            Console.Out.WriteLine($"{TAG}: throw NullReferenceException, e = {e}");
        }
    }

    /// <summary>
    /// 尝试对不兼容值类型的引用进行取消装箱会导致 InvalidCastException
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        int i = 123;
        object obj = i;

        try
        {
            long j = (long)obj;
            Console.Out.WriteLine($"{TAG}: j = {j}");
        }
        catch (InvalidCastException e)
        {
            Console.Out.WriteLine($"{TAG}: throw InvalidCastException, e = {e}");
        }

        try
        {
            int k = (short)obj;
            Console.Out.WriteLine($"{TAG}: k = {k}");
        }
        catch (InvalidCastException e)
        {
            Console.Out.WriteLine($"{TAG}: throw InvalidCastException, e = {e}");
        }
    }
}
