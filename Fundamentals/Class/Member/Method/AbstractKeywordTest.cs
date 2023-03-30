using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Method;

[TestClass]
public class AbstractKeywordTest
{
    private const string TAG = "AbstractKeywordTest";

    [TestMethod]
    public void TestMethod1()
    {
        Class1 class1 = new Class1();
        class1.Method1(1);
        Console.WriteLine($"{TAG}: TestMethod1, class1.ToString() = {class1.ToString()}");
    }

    [TestMethod]
    public void TestMethod2()
    {
        Class2 class2 = new Class2();
        class2.Method1(1);
        Console.WriteLine($"{TAG}: TestMethod2, class2.ToString() = {class2.ToString()}");
    }

    private class Class1 : AbstractClass
    {
        private const string TAG = "AbstractKeywordTest.Class1";

        public override void Method1(int a)
        {
            Console.WriteLine($"{TAG}: Class1 Method1, a = {a}, getTag() = {getTag()}, getMyTag() = {getMyTag()}");
        }
    }

    private class Class2 : AbstractClass
    {
        private const string TAG = "AbstractKeywordTest.Class2";

        public override void Method1(int a)
        {
            Console.WriteLine($"{TAG}: class2 Method1, a = {a}, getTag() = {getTag()}, getMyTag() = {getMyTag()}");
        }

        public override string ToString()
        {
            return "AbstractKeywordTest.Class2";
        }
    }
}
