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
        int? a = 1;
        int? b = null;
        int c = 2;
        long d = c;
        object obj = c;
        BaseClass instance1 = new BaseClass();
        BaseClass instance2 = new DerivedClass();
        object instance3 = new ImplementationClass();

        // 返回 true, 因为 a 的基础类型为 int 并且不为 null
        Console.Out.WriteLine($"{TAG}: (a is int) = {a is int}");

        // 返回 false, 因为 b 为 null
        Console.Out.WriteLine($"{TAG}: (b is int?) = {b is int?}");

        Console.Out.WriteLine($"{TAG}: (c is int) = {c is int}");

        // is 运算符不会考虑隐式数值转换
        Console.Out.WriteLine($"{TAG}: (d is int) = {d is int}");

        // is 运算符会考虑装箱和取消装箱转换, 但不会考虑隐式数值转换
        Console.Out.WriteLine($"{TAG}: (obj is int) = {obj is int}");
        Console.Out.WriteLine($"{TAG}: (obj is long) = {obj is long}");
        Console.Out.WriteLine($"{TAG}: (obj is IFormattable) = {obj is IFormattable}");

        Console.Out.WriteLine($"{TAG}: (instance1 is object) = {instance1 is object}");
        Console.Out.WriteLine($"{TAG}: (instance1 is BaseClass) = {instance1 is BaseClass}");
        Console.Out.WriteLine($"{TAG}: (instance1 is DerivedClass) = {instance1 is DerivedClass}");
        Console.Out.WriteLine($"{TAG}: (instance2 is BaseClass) = {instance2 is BaseClass}");
        Console.Out.WriteLine($"{TAG}: (instance2 is DerivedClass) = {instance2 is DerivedClass}");
        Console.Out.WriteLine($"{TAG}: (instance3 is ISampleInterface) = {instance3 is ISampleInterface}");
    }

    /// <summary>
    /// is 运算符可以根据某个模式测试表达式结果
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        object[] objects = { new DerivedClass(), new ImplementationClass() };

        foreach (var obj in objects)
        {
            if (obj is BaseClass instance)
            {
                // 当类型测试成功时, 将表达式结果分配给声明的变量 instance
                Console.Out.WriteLine($"{TAG}: instance.GetTag() = {instance.GetTag()}");
            }
            else
            {
                // 此时 instance = null
                Console.WriteLine($"{TAG}: {obj.GetType()} is not compatible with {typeof(BaseClass)}");
            }
        }
    }

    /// <summary>
    /// as 运算符可以将表达式结果显式转换为给定的类型 (如果表达式结果的运行时类型与给定类型兼容)
    /// 如果无法进行转换, 则 as 运算符返回 null
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        object[] objects = { new DerivedClass(), new ImplementationClass() };

        foreach (var obj in objects)
        {
            // ?. 是 Null 条件运算符
            Console.Out.WriteLine($"{TAG}: (obj as BaseClass)?.GetName() = {(obj as BaseClass)?.GetName()}");
        }
    }

    /// <summary>
    /// 通过 typeof 运算符获取某个类型的 System.Type 实例
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        Console.WriteLine($"typeof(int) = {typeof(int)}");
        Console.WriteLine($"typeof(int?) = {PrintType<int?>()}");
        Console.WriteLine($"typeof(object) = {PrintType<object>()}");
        Console.WriteLine($"typeof(string) = {typeof(string)}");

        // typeof 运算符不能用于可为 null 的引用类型
        // Console.WriteLine($"typeof(string?) = {typeof(string?)}");

        Console.WriteLine($"typeof(Dictionary<,>) = {typeof(Dictionary<,>)}");
        Console.WriteLine($"typeof(Dictionary<string, int>) = {typeof(Dictionary<string, int>)}");

        // typeof 运算符的实参可以是类型形参
        string PrintType<T>() => typeof(T).ToString();
    }

    /// <summary>
    /// 使用 typeof 运算符进行类型测试
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        object instance1 = new DerivedClass();
        ISampleInterface instance2 = new ImplementationClass();
        IDictionary<string, int> instance3 = new Dictionary<string, int>();

        // GetType 方法用于获取当前实例的运行时类型
        Console.WriteLine($"(typeof(object) == instance1.GetType()) = {typeof(object) == instance1.GetType()}");
        Console.WriteLine($"(typeof(BaseClass) == instance1.GetType()) = {typeof(BaseClass) == instance1.GetType()}");
        Console.WriteLine(
            $"(typeof(DerivedClass) == instance1.GetType()) = {typeof(DerivedClass) == instance1.GetType()}");
        Console.WriteLine(
            $"(typeof(ISampleInterface) == instance2.GetType()) = {typeof(ISampleInterface) == instance2.GetType()}");
        Console.WriteLine(
            $"(typeof(ImplementationClass) == instance2.GetType()) = {typeof(ImplementationClass) == instance2.GetType()}");
        Console.WriteLine(
            $"(typeof(IDictionary<string, int>) == instance3.GetType()) = {typeof(IDictionary<string, int>) == instance3.GetType()}");
        Console.WriteLine(
            $"(typeof(Dictionary<,>) == instance3.GetType()) = {typeof(Dictionary<,>) == instance3.GetType()}");
        Console.WriteLine(
            $"(typeof(Dictionary<string, int>) == instance3.GetType()) = {typeof(Dictionary<string, int>) == instance3.GetType()}");
    }
}
