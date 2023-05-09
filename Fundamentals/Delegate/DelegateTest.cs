using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Delegate;

[TestClass]
public class DelegateTest
{
    private const string TAG = "DelegateTest";

    [TestMethod]
    public void TestMethod1()
    {
        double a = 2.0;

        Class1.Function f1 = new Class1.Function(delegate(double x)
        {
            x += 0.1;
            return x;
        });
        Class1.Function f2 = delegate(double x)
        {
            x += 0.2;
            return x;
        };
        Class1.Function f3 = new Class1.Function((x) =>
        {
            x += 0.3;
            return x;
        });
        Class1.Function f4 = (x) =>
        {
            x += 0.4;
            return x;
        };
        Class1.Function f5 = x =>
        {
            x += 0.5;
            return x;
        };

        string apply1 = Class1.Apply(a, f1);
        string apply2 = Class1.Apply(a, f2);
        string apply3 = Class1.Apply(a, f3);
        string apply4 = Class1.Apply(a, f4);
        string apply5 = Class1.Apply(a, f5);

        // 使用 Lambda 表达式来创建匿名函数
        string squares = Class1.Apply(a, x => x * x);

        Console.Out.WriteLine($"{TAG}: TestMethod1, apply1 = \"{apply1}\"");
        Console.Out.WriteLine($"{TAG}: TestMethod1, apply2 = \"{apply2}\"");
        Console.Out.WriteLine($"{TAG}: TestMethod1, apply3 = \"{apply3}\"");
        Console.Out.WriteLine($"{TAG}: TestMethod1, apply4 = \"{apply4}\"");
        Console.Out.WriteLine($"{TAG}: TestMethod1, apply5 = \"{apply5}\"");
        Console.Out.WriteLine($"{TAG}: TestMethod1, apply6 = \"{squares}\"");
    }

    [TestMethod]
    public void TestMethod2()
    {
        double a = 2.0;

        Class1.Function f1 = new Class1.Function(TempFunction);
        Class1.Function f2 = new Class1.Function(new Class1.Function(TempFunction));
        Class1.Function f3 = new Class1.Function(new Class1.Function(new Class1.Function(TempFunction)));

        string apply1 = Class1.Apply(a, f1);
        string apply2 = Class1.Apply(a, f2);
        string apply3 = Class1.Apply(a, f3);

        Console.Out.WriteLine($"{TAG}: TestMethod2, apply1 = \"{apply1}\"");
        Console.Out.WriteLine($"{TAG}: TestMethod2, apply2 = \"{apply2}\"");
        Console.Out.WriteLine($"{TAG}: TestMethod2, apply3 = \"{apply3}\"");
    }

    [TestMethod]
    public void TestMethod3()
    {
        double a = 2.0;

        double temp(double x)
        {
            return x * x * x;
        }

        string apply = Class1.Apply(a, temp);

        Console.Out.WriteLine($"{TAG}: TestMethod3, apply = \"{apply}\"");
    }

    [TestMethod]
    public void TestMethod4()
    {
        double a = 3.14 / 2;
        string sines = Class1.Apply(a, Math.Sin);
        Console.Out.WriteLine($"{TAG}: TestMethod4, apply = \"{sines}\"");
    }

    [TestMethod]
    public void TestMethod5()
    {
        double a = 2.0;
        TempClass instance = new TempClass(1.1);
        string multiply = Class1.Apply(a, instance.Multiply);
        Console.Out.WriteLine($"{TAG}: TestMethod5, apply = \"{multiply}\"");
    }

    [TestMethod]
    public void TestMethod6()
    {
        double Addition(double d)
        {
            Console.WriteLine("Addition");
            return d + d;
        }

        double Multiplication(double d)
        {
            Console.WriteLine("Multiplication");
            return d * d;
        }

        // 测试 += 操作符
        Class2.Functions += Addition;
        Class2.Functions += Multiplication;
        Class2.Apply(3f);

        // 测试 -= 操作符
        Class2.Functions -= Multiplication;
        Class2.Apply(4f);

        // 测试 = 操作符
        Class2.Functions = delegate(double d)
        {
            Console.WriteLine("Division");
            return d / 2;
        };
        Class2.Apply(5f);
        Class2.Functions += Addition;
        Class2.Apply(6f);

        // 令 Class2.Functions = null
        Class2.Functions = null;
        Class2.Apply(7f);
    }

    private static double TempFunction(double x)
    {
        return x * x;
    }

    class TempClass
    {
        double factor;

        public TempClass(double factor) => this.factor = factor;

        public double Multiply(double x) => x * factor;
    }
}
