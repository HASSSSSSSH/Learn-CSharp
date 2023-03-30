using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Tuple;

[TestClass]
public class TupleTest
{
    private const string TAG = "TupleTest";

    [TestMethod]
    public void TestMethod1()
    {
        (double a, int b) tuple1 = (0, 1);
        Console.WriteLine($"{TAG}: a = {tuple1.a}, b = {tuple1.b}");
    }

    [TestMethod]
    public void TestMethod2()
    {
        TempClass instance = new TempClass(0, 1);
        Console.WriteLine($"{TAG}: TestMethod2, instance.X = {instance.X}, instance.Y = {instance.Y}");
    }

    class TempClass
    {
        public int X { get; }
        public int Y { get; }

        public TempClass(int x, int y)
        {
            (X, Y) = (x, y);
        }
    }
}
