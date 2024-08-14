namespace Async;

public class MainClass
{
    private static async Task Main()
    {
        AsyncTest asyncTest = new AsyncTest();

        // Test1
        // asyncTest.TestMethod1();

        // Test2
        // await asyncTest.TestMethod2();

        // Test3
        // await asyncTest.TestMethod3();

        // Test4
        await asyncTest.TestMethod4();

        // Test5: 需要添加延时, 使进程存活一段时间
        // asyncTest.TestMethod5();
        // await Task.Delay(5000);
    }

    /// <summary>
    /// 输出带有时间的日志
    /// </summary>
    public static void Log(string log)
    {
        DateTime dateTime = DateTime.Now;
        Console.WriteLine($"{dateTime:HH:mm:ss.fff}: {log}");
    }
}
