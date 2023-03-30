using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Operator;

[TestClass]
public class OperatorTest
{
    private const string TAG = "OperatorTest";

    [TestMethod]
    public void TestMethod1()
    {
        Class1 instance1 = new Class1(3)
        {
            [0] = 100,
            [1] = 1000,
            [2] = 10000,
        };
        Class1 instance2 = new Class1(3)
        {
            [0] = 100,
            [1] = 1000,
        };

        Console.WriteLine($"{TAG}: TestMethod1, (instance1 == instance2) = {instance1 == instance2}");
        instance2[2] = 10000;
        Console.WriteLine($"{TAG}: TestMethod1, (instance1 == instance2) = {instance1 == instance2}");
        Console.WriteLine($"{TAG}: TestMethod1, (instance1.Equals(instance2)) = {instance1.Equals(instance2)}");
        Console.WriteLine($"{TAG}: TestMethod1, (instance1 != instance2) = {instance1 != instance2}");
        Console.WriteLine($"{TAG}: TestMethod1, (instance1.Equals(null)) = {instance1.Equals(null)}");
    }
}
