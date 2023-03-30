using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Interface;

[TestClass]
public class InterfaceTest
{
    private const string TAG = "InterfaceTest";

    [TestMethod]
    public void TestMethod1()
    {
        int? a = default;

        InterfaceImplementClass instance = new InterfaceImplementClass();
        instance.Method1();
        instance.Method1("S");
        // instance.Method1(new string[] { "A", "B", "C" });
        instance.Method1(1);
        instance.Method1(a);
        instance.Method2(new int[] { 1, 2, 3 });
    }
}
