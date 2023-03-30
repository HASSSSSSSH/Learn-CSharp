using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Method;

[TestClass]
public class OutKeywordTest
{
    private const string TAG = "OutKeywordTest";

    [TestMethod]
    public void TestMethod1()
    {
        Divide(1, 1, out int i, out int j);
        Console.WriteLine($"{TAG}: i = {i}, j = {j}");
    }

    private void Divide(int x, int y, out int addition, out int subtraction)
    {
        addition = x + y;
        subtraction = x - y;
    }
}
