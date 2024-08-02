using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.PatternMatching;

[TestClass]
public class PatternMatchingExample
{
    private const string TAG = "PatternMatchingExample";

    /// <summary>
    /// 使用模式匹配进行 null 检查
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        int? a = 1;
        string? time = $"{DateTime.Now:T}";

        // 使用声明模式检查表达式的运行时类型
        // 如果匹配成功, 则将表达式结果分配给声明的变量
        if (a is int number)
        {
            Console.WriteLine($"{TAG}: number = {number}");
        }

        // 将常量模式和逻辑模式结合使用, 测试表达式结果是否不为 null
        if (time is not null)
        {
            Console.WriteLine($"{TAG}: time = {time}");
        }
    }

    /// <summary>
    /// 使用模式匹配进行类型测试
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        object point = new Vector2(1, 1);

        if (point is Vector2)
        {
            Console.WriteLine($"{TAG}: point.X = {((Vector2)point).X}, point.Y = {((Vector2)point).Y}");
        }
    }

    /// <summary>
    /// 使用模式匹配比较离散值
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        Console.WriteLine($"{TAG}: GetModeString(FileMode.Create) = {GetModeString(FileMode.Create)}");
        Console.WriteLine($"{TAG}: GetModeString(FileMode.Open) = {GetModeString(FileMode.Open)}");
        Console.WriteLine($"{TAG}: GetModeString((FileMode)6) = {GetModeString((FileMode)6)}");
        Console.WriteLine($"{TAG}: GetModeString((FileMode)10) = {GetModeString((FileMode)10)}");
        Console.WriteLine($"{TAG}: GetModeString(null) = {GetModeString(null)}");

        string GetModeString(FileMode? code) =>
            code switch
            {
                FileMode.CreateNew => "ConnectionLost",
                FileMode.Create => "Create",
                FileMode.Open => "Open",
                FileMode.OpenOrCreate => "OpenOrCreate",
                (FileMode)5 => "Truncate",
                (FileMode)6 => "Append",

                // 使用弃元模式 _ 来匹配任何表达式
                _ => "Unknown",
            };
    }

    /// <summary>
    /// 常量模式和关系模式结合使用, 将表达式结果与常量进行比较
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        Console.WriteLine($"{TAG}: Classify(1.2) = {Classify(1.2)}");
        Console.WriteLine($"{TAG}: Classify(double.MaxValue) = {Classify(double.MaxValue)}");
        Console.WriteLine($"{TAG}: Classify(double.NaN) = {Classify(double.NaN)}");
        Console.WriteLine($"{TAG}: Classify(2.9) = {Classify(2.9)}");
        Console.WriteLine($"{TAG}: Classify(6) = {Classify(6)}");

        string Classify(double measurement) =>
            measurement switch
            {
                6 => "Perfect",
                < 2.0 => "Too low",
                > 10.0 => "Too high",
                double.NaN => "Unknown",

                // 使用弃元模式 _ 来匹配任何表达式
                _ => "Acceptable",
            };
    }
}
