using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.TypeConversion;

[TestClass]
public class TypeConversionExample
{
    private const string TAG = "TypeConversionExample";

    /// <summary>
    /// 隐式数值转换
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        byte a = 0xAA;

        // 从 byte 到 int 的隐式转换
        int b = a;

        // 从 int 到 long 的隐式转换
        long c = b;

        // 从 long 到 float 的隐式转换
        float d = c;

        // 从 float 到 double 的隐式转换
        double e = d;

        Console.Out.WriteLine($"{TAG}: e = {e}");
    }

    /// <summary>
    /// 将类隐式转换为该类的基类或接口
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        DerivedClass instance1 = new DerivedClass();
        ImplementationClass instance2 = new ImplementationClass();

        // 将类隐式转换为其基类或接口
        BaseClass baseClass = instance1;
        ISampleInterface sampleInterface = instance2;

        Console.Out.WriteLine($"{TAG}: baseClass.GetTag() = {baseClass.GetTag()}");
        sampleInterface.Method1();
    }

    /// <summary>
    /// 显式数值转换
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        double a = 12345678900.55555;

        // 从 double 到 long 的显式转换
        long b = (long)a;

        // 从 long 到 int 的显式转换
        int c = (int)b;

        Console.Out.WriteLine($"{TAG}: b = {b}, c = {c}");
    }

    /// <summary>
    /// 将基类型显式强制转换为其派生类型
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        BaseClass baseClass = new BaseClass();

        // 执行强制转换可能会抛出异常
        try
        {
            DerivedClass derivedClass = (DerivedClass)baseClass;
            Console.Out.WriteLine($"{TAG}: derivedClass.GetName() = {derivedClass.GetName()}");
            Console.Out.WriteLine($"{TAG}: derivedClass.GetTag() = {derivedClass.GetTag()}");
        }
        catch (InvalidCastException e)
        {
            Console.Out.WriteLine($"{TAG}: cast throw InvalidCastException, e = {e}");
        }
    }

    /// <summary>
    /// 执行用户定义的显式和隐式转换
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        Digit d1 = default;
        Digit d2 = default;
        Digit d3 = default;
        Digit d4 = default;
        Digit d5 = default;

        try
        {
            int a = 1;
            byte b = 0x09;

            // 调用构造函数实例化
            d1 = new Digit(a);
            d2 = new Digit(b);

            // 使用强制转换表达式来调用用户定义的显式转换
            d3 = (Digit)a;
            d4 = (Digit)b;
            d5 = (Digit)0xA;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Out.WriteLine($"{TAG}: throw InvalidCastException, e = {e}");
        }
        finally
        {
            // 执行用户定义的隐式转换
            int a1 = d1;
            int a2 = d2;
            byte b1 = d3;
            byte b2 = d4;
            byte b3 = d5;

            Console.Out.WriteLine($"{TAG}: d1 = {d1}, d2 = {d2}, d3 = {d3}, d4 = {d4}, d5 = {d5}");
            Console.Out.WriteLine($"{TAG}: a1 = {a1}, a2 = {a2}, b1 = {b1}, b2 = {b2}, b3 = {b3}");
        }
    }
}
