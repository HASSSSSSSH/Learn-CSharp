using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Exception;

[TestClass]
public class ExceptionTest
{
    /// <summary>
    /// 引发和捕获异常
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        try
        {
            TestThrow();
        }
        catch (CustomException e)
        {
            Console.WriteLine($"throw CustomException: {e}");

            // 使用 throw 关键字可以再次抛出该异常
            // throw;
        }
    }

    /// <summary>
    /// 测试 finally
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        try
        {
            Console.WriteLine("Test1:");
            int value1 = TestFinally1();
            Console.WriteLine($"TestFinally1() return {value1}\n");
        }
        catch (System.Exception e)
        {
            Console.WriteLine($"TestFinally1() throw exception: {e}\n");
        }

        Console.WriteLine("Test2:");
        int value2 = TestFinally2();
        Console.WriteLine($"TestFinally2() return {value2}\n");

        Console.WriteLine("Test3:");
        int value3 = TestFinally3();
        Console.WriteLine($"TestFinally3() return {value3}");
    }

    private void TestThrow()
    {
        throw new CustomException("Test");
    }

    private int TestFinally1()
    {
        try
        {
            Console.WriteLine("In the try block");
            TestThrow();
            return 0;
        }
        finally
        {
            Console.WriteLine("In the finally block");

            // 在 finally 块中不能 return
            // return 1;
        }

        // 永远不会执行到这段代码
        return 1;
    }

    private int TestFinally2()
    {
        try
        {
            Console.WriteLine("In the try block");
            return 0;
        }
        finally
        {
            Console.WriteLine("In the finally block");
        }

        // 永远不会执行到这段代码
        return 1;
    }

    private int TestFinally3()
    {
        try
        {
            Console.WriteLine("In the try block");
        }
        finally
        {
            Console.WriteLine("In the finally block");
        }

        return 1;
    }
}
