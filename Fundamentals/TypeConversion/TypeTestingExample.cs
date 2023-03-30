#pragma warning disable CS0184 CS0183
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.TypeConversion;

[TestClass]
public class TypeTestingExample
{
    private const string TAG = "TypeTestingExample";

    /// <summary>
    /// 通过 is 运算符检查表达式结果的运行时类型是否与给定类型兼容
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        int a = 1;
        int? b = default;
        double? c = 3.14;
        double d = a;
        object obj = a;
        Class2 instance1 = new Class2();
        Class3 instance2 = new Class3();

        Console.Out.WriteLine($"{TAG}: TestMethod1, a is int = {a is int}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, b is null = {b is null}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, c is not null = {c is not null}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, d is int = {d is int}");

        // is 运算符会考虑装箱和取消装箱转换, 但不会考虑数值转换
        Console.Out.WriteLine($"{TAG}: TestMethod1, obj is Int32 = {obj is Int32}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, obj is long = {obj is long}");

        Console.Out.WriteLine($"{TAG}: TestMethod1, instance1 is Class1 = {instance1 is Class1}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, instance1 is IInterface = {instance1 is IInterface}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, instance2 is Class1 = {instance2 is Class1}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, instance2 is IInterface = {instance2 is IInterface}");
    }

    /// <summary>
    /// is 运算符还会对照某个模式测试表达式结果
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        Class2 instance1 = new Class2();
        Class3 instance2 = new Class3();
        object[] objects = { instance1, instance2 };

        foreach (var obj in objects)
        {
            // 只有当类型测试成功时才会进行赋值给 instance
            if (obj is Class1 instance)
            {
                // 此时 instance 必定不等于 null
                Console.Out.WriteLine($"{TAG}: TestMethod2, instance.A = {instance.A}");
            }
            else
            {
                // 此时 instance = null
                Console.WriteLine($"{TAG}: TestMethod2, {obj.GetType().Name} is not Class1");
            }
        }
    }

    /// <summary>
    /// 通过 as 运算符可以将表达式结果显式转换为给定类型 (如果表达式结果的运行时类型与给定类型兼容)
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        int a = 1;
        double? b = default;
        object obj1 = a;
        object obj2 = b;
        object instance1 = new Class2();
        Class3 instance2 = new Class3();

        // 测试 obj1
        var a1 = obj1 as int?;
        if (a1 != null)
        {
            Console.Out.WriteLine($"{TAG}: TestMethod3, obj1 is int = {a1}");
        }
        else
        {
            Console.WriteLine($"{TAG}: TestMethod3, obj1 as int? = null");
        }

        // 测试 obj1
        var a2 = obj1 as long?;
        if (a2 != null)
        {
            Console.Out.WriteLine($"{TAG}: TestMethod3, obj1 is long = {a2}");
        }
        else
        {
            Console.WriteLine($"{TAG}: TestMethod3, obj1 as long? = null");
        }

        // 测试 obj2
        var b1 = obj2 as double?;
        if (b1 != null)
        {
            Console.Out.WriteLine($"{TAG}: TestMethod3, obj2 is double = {b1}");
        }
        else
        {
            Console.WriteLine($"{TAG}: TestMethod3, obj2 as double? = null");
        }

        // 测试 instance1, instance2
        object[] objects = { instance1, instance2 };
        foreach (var obj in objects)
        {
            var instance = obj as Class1;
            if (instance != null)
            {
                Console.Out.WriteLine($"{TAG}: TestMethod3, instance.A = {instance.A}");
            }
            else
            {
                Console.WriteLine($"{TAG}: TestMethod3, {obj.GetType().Name} is not Class1");
            }
        }
    }

    /// <summary>
    /// 通过 typeof 运算符获取某个类型的 System.Type 实例
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        void PrintType<T>() => Console.WriteLine(typeof(T));

        PrintType<int>();
        PrintType<Int32>();
        PrintType<Dictionary<int, char>>();

        Console.WriteLine(typeof(int?));
        // Console.WriteLine(typeof(string?));
        Console.WriteLine(typeof(Dictionary<,>));
        Console.WriteLine(typeof(List<string>));
    }

    /// <summary>
    /// 通过 typeof 运算符进行类型检测
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        object instance1 = new Class2();
        Class3 instance2 = new Class3();

        // 给定 Class1 类型
        Console.Out.WriteLine($"{TAG}: TestMethod5, instance1 is Class1 = {instance1 is Class1}");
        Console.Out.WriteLine(
            $"{TAG}: TestMethod5, (instance1.GetType() == typeof(Class1)) = {instance1.GetType() == typeof(Class1)}");

        // 给定 IInterface 类型
        Console.Out.WriteLine($"{TAG}: TestMethod5, instance1 is IInterface = {instance1 is IInterface}");
        Console.Out.WriteLine(
            $"{TAG}: TestMethod5, (instance1.GetType() == typeof(IInterface)) = {instance1.GetType() == typeof(IInterface)}");

        // 给定 Class2 类型
        Console.Out.WriteLine($"{TAG}: TestMethod5, instance1 is Class2 = {instance1 is Class2}");
        Console.Out.WriteLine(
            $"{TAG}: TestMethod5, (instance1.GetType() == typeof(Class2)) = {instance1.GetType() == typeof(Class2)}");

        // 给定 Class3 类型
        Console.Out.WriteLine($"{TAG}: TestMethod5, instance2 is Class3 = {instance2 is Class3}");
        Console.Out.WriteLine(
            $"{TAG}: TestMethod5, (instance2.GetType() == typeof(Class3)) = {instance2.GetType() == typeof(Class3)}");
    }
}
