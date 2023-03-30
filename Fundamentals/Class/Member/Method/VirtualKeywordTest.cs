using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Method;

[TestClass]
public class VirtualKeywordTest
{
    private const string TAG = "VirtualKeywordTest";

    [TestMethod]
    public void TestMethod1()
    {
        Class1 class1 = new Class1();
        class1.Method1(1);
    }

    private class Class1 : AbstractClass
    {
        private const string TAG = "VirtualKeywordTest.Class1";

        public override void Method1(int a)
        {
            Console.WriteLine($"{TAG}: Class1 Method1, getTag() = {getTag()}, getMyTag() = {getMyTag()}");
        }

        public override string getTag()
        {
            return TAG;
        }

        public string getMyTag()
        {
            return TAG;
        }
    }
}
