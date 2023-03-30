using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.ObjectOriented;

[TestClass]
public class ObjectOrientedTest
{
    private const string TAG = "ObjectOrientedTest";

    [TestMethod]
    public void TestMethod1()
    {
        AbstractClass class1 = new Class1();

        // 调用的是重写的 Class1.Method1()
        class1.Method1(1);

        if (class1 is IInterface instance)
        {
            // 调用的是 IInterface.Method2(string)
            instance.Method2("S");
        }

        // 调用的是 AbstractClass.getMyTag()
        Console.WriteLine($"{TAG}: TestMethod1, class1.getMyTag() = {class1.getMyTag()}");
    }

    [TestMethod]
    public void TestMethod2()
    {
        AbstractClass class2 = new Class2();

        // 调用的是重写的 Class2.Method1()
        class2.Method1(1);

        if (class2 is IInterface instance)
        {
            // 调用的是 Class2.Method2(string)
            instance.Method2("S");
        }

        // 调用的是 AbstractClass.getMyTag()
        Console.WriteLine($"{TAG}: TestMethod2, class2.getMyTag() = {class2.getMyTag()}");

        if (class2 is Class2 class2Instance)
        {
            // 调用的是 Class2.getMyTag()
            Console.WriteLine($"{TAG}: TestMethod2, class2.getMyTag() = {class2Instance.getMyTag()}");
        }
    }

    [TestMethod]
    public void TestMethod3()
    {
        AbstractClass class3 = new Class3();
        AbstractClass class4 = new Class4();

        // 调用的是 Class3.getTag()
        Console.WriteLine($"{TAG}: TestMethod3, class3.getTag() = {class3.getTag()}");

        // 调用的是 Class3.getTag()
        Console.WriteLine($"{TAG}: TestMethod3, class4.getTag() = {class4.getTag()}");

        if (class4 is Class4 class4Instance)
        {
            // 调用的是 Class4.getTag()
            Console.WriteLine($"{TAG}: TestMethod3, class3Instance.getTag() = {class4Instance.getTag()}");
        }

        if (class4 is Class3 class3Instance)
        {
            // 调用的是 Class3.getTag()
            Console.WriteLine($"{TAG}: TestMethod3, class3Instance.getTag() = {class3Instance.getTag()}");
        }
    }
}
