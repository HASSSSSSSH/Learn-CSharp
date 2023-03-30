using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class;

[TestClass]
public class ClassTest
{
    private const string TAG = "ClassTest";

    [TestMethod]
    public void TestMethod1()
    {
        TempClass instance1 = new TempClass(1, "S");
        Console.WriteLine($"{TAG}: TestMethod1, instance1.ToString() = {instance1.ToString()}");

        TempClass instance2 = instance1;
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
        TempClass instance1 = new TempClass(1, "S");
        TempClass instance2 = instance1;
        Console.WriteLine($"{TAG}: TestMethod2, instance1 == instance2 = {instance1 == instance2}");
        Console.WriteLine($"{TAG}: TestMethod2, instance1.Equals(instance2) = {instance1.Equals(instance2)}");

        TempClass instance3 = new TempClass(100, "AAA");
        Console.WriteLine($"{TAG}: TestMethod2, instance1 == instance3 = {instance1 == instance3}");
        Console.WriteLine($"{TAG}: TestMethod2, instance1.Equals(instance3) = {instance1.Equals(instance3)}");

        instance3.X = 1;
        instance3.Y = "S";
        Console.WriteLine($"{TAG}: TestMethod2, instance1 == instance3 = {instance1 == instance3}");
        Console.WriteLine($"{TAG}: TestMethod2, instance1.Equals(instance3) = {instance1.Equals(instance3)}");
    }

    class TempClass
    {
        private const string TAG = "TempClass";

        public int X { get; set; }
        public string Y { get; set; }

        public TempClass(int x, string y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{TAG}: X = {X}, Y = {Y}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj is TempClass tempClass)
            {
                if (tempClass.X != this.X || tempClass.Y != this.Y)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
