using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.ObjectOriented;

[TestClass]
public class NewKeywordTest
{
    private const string TAG = "NewKeywordTest";

    [TestMethod]
    public void TestMethod1()
    {
        Class1 class1 = new Class1();
        class1.Method1(1);

        // 调用的是 AbstractClass.getMyTag()
        Console.WriteLine($"{TAG}: TestMethod1, class1.getMyTag() = {class1.getMyTag()}");
    }

    [TestMethod]
    public void TestMethod2()
    {
        Class2 class2 = new Class2();
        class2.Method1(1);

        // 调用的是 Class2.getMyTag()
        Console.WriteLine($"{TAG}: TestMethod2, class2.getMyTag() = {class2.getMyTag()}");
    }

    private class Class1 : AbstractClass
    {
        private const string TAG = "NewKeywordTest.Class1";

        public override void Method1(int a)
        {
            // 分别调用自身和基类的 getMyTag 方法
            Console.WriteLine($"{TAG}: Class1 Method1, getMyTag() = {getMyTag()}, base.getMyTag() = {base.getMyTag()}");
        }

        /// <summary>
        /// 注意到, 此方法带有 private 访问修饰符
        /// </summary>
        private new string getMyTag()
        {
            return TAG;
        }
    }

    private class Class2 : AbstractClass
    {
        private const string TAG = "NewKeywordTest.Class2";

        public override void Method1(int a)
        {
            Console.WriteLine($"{TAG}: Class2 Method1, getMyTag() = {getMyTag()}, base.getMyTag() = {base.getMyTag()}");
        }

        /// <summary>
        /// 注意到, 此方法带有 public 访问修饰符
        /// </summary>
        public new string getMyTag()
        {
            return TAG;
        }
    }
}
