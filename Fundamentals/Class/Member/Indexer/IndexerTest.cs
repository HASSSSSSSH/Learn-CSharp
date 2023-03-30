using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Indexer;

[TestClass]
public class IndexerTest
{
    private const string TAG = "IndexerTest";

    [TestMethod]
    public void TestMethod1()
    {
        Class1 class1 = new Class1(10)
        {
            [0] = 100
        };
        Console.WriteLine($"{TAG}: TestMethod1, class1[0] = {class1[0]}");
        class1[0, 'b'] = 100;
        Console.WriteLine($"{TAG}: TestMethod1, class1[0, 'a'] = {class1[0, 'a']}");
    }
}
