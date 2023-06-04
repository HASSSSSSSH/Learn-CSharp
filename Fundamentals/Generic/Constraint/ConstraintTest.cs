using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Generic.Constraint;

[TestClass]
public class ConstraintTest
{
    private const string TAG = "ConstraintTest";

    [TestMethod]
    public void TestMethod1()
    {
        DerivedClass derivedClass = new DerivedClass("TestMethod1");
        var genericClass1 = new GenericClass1<DerivedClass>();
        Console.Out.WriteLine($"{TAG}: genericClass1.Method1(derivedClass) = {genericClass1.Method1(derivedClass)}");
    }

    [TestMethod]
    public void TestMethod2()
    {
        string s1 = "target";
        string s2 = new StringBuilder("target").ToString();

        GenericClass2<string>.OpEqualsTest1<string>(s1, s2);
        GenericClass2<string>.OpEqualsTest2<string>(s1, s2);
        GenericClass2<string>.OpEqualsTest2<string>(s1, s1);
    }
}
