using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Constructor;

[TestClass]
public class ConstructorTest
{
    private const string TAG = "ConstructorTest";

    [TestMethod]
    public void TestMethod1()
    {
        Class1 instance1 = new Class1();
        Class1 instance2 = new Class1(0);
        Class1 instance3 = new Class1(0, 5);
    }
}
