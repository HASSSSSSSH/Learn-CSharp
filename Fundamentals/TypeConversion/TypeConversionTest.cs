using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.TypeConversion;

[TestClass]
public class TypeConversionTest
{
    private const string TAG = "TypeConversionTest";

    /// <summary>
    /// 将 int 类型隐式转换为 long 类型
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        int num = Int32.MaxValue;
        long bigNum = num;
        Console.Out.WriteLine($"{TAG}: TestMethod1, bigNum = {bigNum}");
    }

    /// <summary>
    /// 将类隐式转换为该类的基类和接口
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        Class2 class2 = new Class2();

        Class1 class1 = class2;
        Console.Out.WriteLine($"{TAG}: TestMethod2, class1.A = {class1.A}");

        IInterface instance = class2;
        instance.Method1();
    }

    /// <summary>
    /// 将 double 类型显式转换为 int 类型
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        double x = 1234.5;
        int a = (int)x;
        Console.Out.WriteLine($"{TAG}: TestMethod3, a = {a}");
    }

    /// <summary>
    /// 将基类型显式转换为派生类型
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        Class1 class1 = new Class1();

        // 执行强制转换将会抛出 InvalidCastException
        try
        {
            Class2 class2 = (Class2)class1;
            Console.Out.WriteLine($"{TAG}: TestMethod4, class2.A = {class2.A}");
            Console.Out.WriteLine($"{TAG}: TestMethod4, class2.B = {class2.B}");
            class2.Method1();
        }
        catch (InvalidCastException e)
        {
            Console.Out.WriteLine($"{TAG}: TestMethod4 throw InvalidCastException, e = {e}");
        }
    }
}
