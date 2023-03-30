using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Accessibility;

[TestClass]
public class AccessibilityTest
{
    private const string TAG = "AccessibilityTest";

    [TestMethod]
    public void TestMethod1()
    {
        // Console.WriteLine($"{TAG}: Class1.TAG = {Class1.TAG}");
        Console.WriteLine($"{TAG}: Class1.CONST_A = {Class1.CONST_A}");
        Console.WriteLine($"{TAG}: Class1.StaticA = {Class1.StaticA}");
        Class1 class1 = new Class1(1);
        Console.WriteLine($"{TAG}: class1.A = {class1.A}");
        // class1.method1();
        // class1.method2();
        class1.method3();
        class1.method4();
        // class1.method5();
        class1.method6();
        // class1.method7();
    }

    [TestMethod]
    public void TestMethod2()
    {
        TempClass instance = new TempClass(2);
        Console.WriteLine($"{TAG}: instance.A = {instance.A}");
        instance.method1();
    }

    private class TempClass : Class1
    {
        private const string TAG = "AccessibilityTest.TempClass";

        public TempClass(int a) : base(a) { }

        /// <summary>
        /// 注意到, 这里没有重写父类的 method1 方法, 该方法带有 private 访问修饰符
        /// </summary>
        public void method1()
        {
            Console.WriteLine($"{TAG}: method1()");
            // Console.WriteLine($"{TAG}: base.TAG = {base.TAG}");
            Console.WriteLine($"{TAG}: base.A = {base.A}");
            // base.method1();
            base.method2();
            base.method3();
            base.method4();
            // base.method5();
            base.method6();
            base.method7();
        }
    }
}
