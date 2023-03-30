using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Property;

[TestClass]
public class PropertyTest
{
    private const string TAG = "PropertyTest";

    [TestMethod]
    public void TestMethod1()
    {
        Class1 instance1 = new Class1(10, 100, 1000);
        instance1.Method1();
    }

    [TestMethod]
    public void TestMethod2()
    {
        Class3 instance1 = new Class3();
        instance1.A = 10;
        instance1.B = 100;
        Console.WriteLine($"{TAG}: TestMethod2(), instance1.A = {instance1.A}, instance1.B = {instance1.B}");
    }

    [TestMethod]
    public void TestMethod3()
    {
        Class4 instance1 = new Class4
        {
            A = 10,
            B = 100
        };
        Console.WriteLine($"{TAG}: TestMethod3(), instance1.A = {instance1.A}, instance1.B = {instance1.B}");
    }
}
