using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Struct;

[TestClass]
public class StructTest
{
    private const string TAG = "StructTest";

    [TestMethod]
    public void TestMethod1()
    {
        TempStruct instance1 = new TempStruct(1, "S");
        Console.WriteLine($"{TAG}: TestMethod1, instance1.ToString() = {instance1.ToString()}");

        TempStruct instance2 = instance1;
        instance2.X = 100;
        instance2.Y = "AAA";
        Console.WriteLine($"{TAG}: TestMethod1, instance1.ToString() = {instance1.ToString()}");
        Console.WriteLine($"{TAG}: TestMethod1, instance2.ToString() = {instance2.ToString()}");
    }

    /// <summary>
    /// 相等性比较
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        TempStruct instance1 = new TempStruct(1, "S");
        TempStruct instance2 = new TempStruct(100, "AAA");
        Console.WriteLine($"{TAG}: TestMethod2, instance1.Equals(instance2) = {instance1.Equals(instance2)}");

        instance1.X = 100;
        instance1.Y = "AAA";
        Console.WriteLine($"{TAG}: TestMethod2, instance1.Equals(instance2) = {instance1.Equals(instance2)}");
    }

    struct TempStruct
    {
        private const string TAG = "TempStruct";

        public int X { get; set; }
        public string Y { get; set; }

        public TempStruct(int x, string y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{TAG}: X = {X}, Y = {Y}";
        }
    }
}
