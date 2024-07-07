using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Indexer;

[TestClass]
public class IndexerTest
{
    private const string TAG = "IndexerTest";

    /// <summary>
    /// 使用索引器
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        SampleClass1 instance = new SampleClass1(10)
        {
            [0] = 1,
            [1] = 10,
            [2] = 100,
            [3] = 1000,
        };

        // 调用索引器的 get 访问器
        Console.WriteLine($"{TAG}: instance[1] = {instance[1]}");
        Console.WriteLine($"{TAG}: instance[1.01] = {instance[1.01]}");
        Console.WriteLine($"{TAG}: instance[1.7] = {instance[1.7]}");

        // 调用索引器的 set 访问器
        instance[1.5] = "111";

        Console.WriteLine($"{TAG}: instance[1.6] = {instance[1.6]}");

        // 调用重载索引器
        instance[5, 10] = 222;
        Console.WriteLine($"{TAG}: instance[5, 0] = {instance[5, 0]}");
    }
}
