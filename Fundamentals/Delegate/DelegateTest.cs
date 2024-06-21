using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Delegate;

[TestClass]
public class DelegateTest
{
    private const string TAG = "DelegateTest";

    /// <summary>
    /// 实例化和使用委托
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        double a = 2.0;

        // 使用 new 运算符实例化委托
        Class1.Function f1 = new Class1.Function(delegate(double x)
        {
            x += 0.1;
            return x;
        });

        // 使用匿名函数实例化委托
        Class1.Function f2 = delegate(double x)
        {
            x += 0.2;
            return x;
        };

        // 使用 new 运算符和 Lambda 表达式实例化委托
        Class1.Function f3 = new Class1.Function((x) =>
        {
            x += 0.3;
            return x;
        });

        // 使用 Lambda 表达式实例化委托
        Class1.Function f4 = (x) =>
        {
            x += 0.4;
            return x;
        };

        // 使用 Lambda 表达式实例化委托
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
        Console.Out.WriteLine($"{TAG}: apply1 = \"{apply1}\"");
        Console.Out.WriteLine($"{TAG}: apply2 = \"{apply2}\"");
        Console.Out.WriteLine($"{TAG}: apply3 = \"{apply3}\"");
        Console.Out.WriteLine($"{TAG}: apply4 = \"{apply4}\"");
        Console.Out.WriteLine($"{TAG}: apply5 = \"{apply5}\"");

        // 使用 Lambda 表达式来创建匿名函数
        string apply6 = Class1.Apply(a, x => x * x);
        Console.Out.WriteLine($"{TAG}: apply6 = \"{apply6}\"");

        // 使用静态方法
        string apply7 = Class1.Apply(a, Class1.Sqrt);
        Console.Out.WriteLine($"{TAG}: apply7 = \"{apply7}\"");

        // 使用实例方法
        Class1 instance = new Class1(10);
        string apply8 = Class1.Apply(a, instance.SampleFunction);
        Console.Out.WriteLine($"{TAG}: apply8 = \"{apply8}\"");

        // 使用本地函数
        string apply9 = Class1.Apply(a, LocalFunction);
        Console.Out.WriteLine($"{TAG}: apply9 = \"{apply9}\"");

        // 本地函数
        double LocalFunction(double x)
        {
            return x * x * x;
        }
    }

    /// <summary>
    /// 通过 new 运算符的嵌套来实例化委托
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        double a = 3.14 / 2;

        Class1.Function f1 = new Class1.Function(Math.Sin);
        Class1.Function f2 = new Class1.Function(new Class1.Function(Math.Sin));
        Class1.Function f3 = new Class1.Function(new Class1.Function(new Class1.Function(Math.Sin)));

        string apply1 = Class1.Apply(a, f1);
        string apply2 = Class1.Apply(a, f2);
        string apply3 = Class1.Apply(a, f3);

        Console.Out.WriteLine($"{TAG}: apply1 = \"{apply1}\"");
        Console.Out.WriteLine($"{TAG}: apply2 = \"{apply2}\"");
        Console.Out.WriteLine($"{TAG}: apply3 = \"{apply3}\"");
    }

    /// <summary>
    /// 使用多播委托
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        int Addition(int x, int y)
        {
            int result = x + y;
            Console.WriteLine($"Addition, result = {result}");
            return result;
        }

        int Multiplication(int x, int y)
        {
            int result = x * y;
            Console.WriteLine($"Multiplication, result = {result}");
            return result;
        }

        // 使用 += 操作符
        Class2.Functions += Addition;
        Class2.Functions += Multiplication;
        Apply(20, 2);

        // 使用 -= 操作符
        Class2.Functions -= Multiplication;
        Apply(20, 2);

        // 使用 = 操作符
        Class2.Functions = (int x, int y) =>
        {
            if (y == 0)
            {
                return 0;
            }

            int result = x / y;
            Console.WriteLine($"Division, result = {result}");
            return result;
        };
        Apply(20, 2);
        Class2.Functions += Addition;
        Apply(20, 2);

        // 令 Class2.Functions = null
        Class2.Functions = null;
        Apply(20, 2);

        void Apply(int x, int y)
        {
            Class2.Apply(x, y);
            Console.WriteLine();
        }
    }
}
