using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Method;

[TestClass]
public class RefKeywordTest
{
    private const string TAG = "RefKeywordTest";

    [TestMethod]
    public void TestMethod1()
    {
        int i = 0, j = 1;
        Swap(ref i, ref j);
        Console.WriteLine($"{TAG}: i = {i}, j = {j}");
    }

    private void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
}
