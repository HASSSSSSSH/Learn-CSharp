using System.Numerics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Method;

[TestClass]
public class MethodTest
{
    private const string TAG = "MethodTest";

    /// <summary>
    /// 访问方法
    /// 方法中带有各种方法参数类型
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        // 访问无参数静态方法
        SampleClass1.GetClassTag();

        SampleClass1 instance = new SampleClass1();

        // 调用本地函数
        Test1();
        Test2();
        Test3();
        Test4();
        Test5();
        Test6();
        Test7();
        Test8();

        // 调用按值传递参数的方法
        void Test1()
        {
            int i = 1;
            var list = new List<string>() { "zzz" };
            instance.Method1(i, list);
            Console.WriteLine($"{TAG}-{nameof(Test1)}:");
            Console.WriteLine($"i = {i}");
            logList(list);
            Console.WriteLine();
        }

        // 调用按值传递参数的方法
        void Test2()
        {
            int i = 1;
            var list = new List<string>() { "zzz" };
            instance.Method2(i, list);
            Console.WriteLine($"{TAG}-{nameof(Test2)}:");
            Console.WriteLine($"i = {i}");
            logList(list);
            Console.WriteLine();
        }

        // 调用按引用传递参数的方法
        void Test3()
        {
            int i = 1;
            ICollection<string> list = new List<string>() { "zzz" };
            instance.Method3(ref i, ref list);
            Console.WriteLine($"{TAG}-{nameof(Test3)}:");
            Console.WriteLine($"i = {i}");
            logList(list);
            Console.WriteLine($"list.GetType() = {list.GetType()}");
            Console.WriteLine();
        }

        // 调用按引用传递参数的方法
        void Test4()
        {
            int i = 1;
            ICollection<string> list = new List<string>() { "zzz" };
            instance.Method4(ref i, ref list);
            Console.WriteLine($"{TAG}-{nameof(Test4)}:");
            Console.WriteLine($"i = {i}");
            logList(list);
            Console.WriteLine($"list.GetType() = {list.GetType()}");
            Console.WriteLine();
        }

        // 调用带有 out 参数修饰符的方法
        void Test5()
        {
            int add = 0;
            instance.Method5(1, 2, out add, out int sub);
            Console.WriteLine($"{TAG}-{nameof(Test5)}: add = {add}, sub = {sub}");
            Console.WriteLine();
        }

        // 调用带有 in 参数修饰符的方法
        void Test6()
        {
            Vector4 vector4 = new Vector4(1f, 1f, 1f, 0);
            instance.Method6(in vector4);
            Console.WriteLine($"{TAG}-{nameof(Test6)}: vector4 = {vector4}");
            Console.WriteLine();
        }

        // 调用带有 params 参数修饰符的方法
        void Test7()
        {
            DateTime thisDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            instance.Method7(
                $"{TAG}-{nameof(Test7)}:\n" +
                "thisDate:\n" +
                "(d) Short date: . . . . . . . {0:d}\n" +
                "(D) Long date:. . . . . . . . {0:D}\n" +
                "(t) Short time: . . . . . . . {0:t}\n" +
                "(T) Long time:. . . . . . . . {0:T}\n" +
                "(G) General date/long time: . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(M) Month:. . . . . . . . . . {0:M}\n" +
                "(Y) Year: . . . . . . . . . . {0:Y}\n" +
                "utcDate:\n" +
                "(d) Short date: . . . . . . . {1:d}\n" +
                "(D) Long date:. . . . . . . . {1:D}\n" +
                "(t) Short time: . . . . . . . {1:t}\n" +
                "(T) Long time:. . . . . . . . {1:T}\n" +
                "(G) General date/long time: . {1:G}\n" +
                "    (default):. . . . . . . . {1} (default = 'G')\n",
                thisDate, utcDate);
        }

        // 调用使用表达式主体定义声明的方法
        void Test8()
        {
            instance.Print("Test8");
            Console.WriteLine($"{TAG}-{nameof(Test8)}: instance.GetTag() = {instance.GetTag()}");
        }
    }

    /// <summary>
    /// 调用重载方法
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        // 调用 F()
        SampleClass2.F();

        // 调用 F(int)
        SampleClass2.F(1);

        // 调用 F(double)
        SampleClass2.F(1.0);

        // 调用 F(double)
        SampleClass2.F((double)1);

        // 调用 F<T>(T), T 的类型是 System.Int32
        SampleClass2.F<int>(1);

        // 调用 F<T>(T), T 的类型是 System.String
        SampleClass2.F("AAA");

        // 调用 F(object)
        SampleClass2.F((object)1);

        // 调用 F(double, double)
        SampleClass2.F(1.0, 1.0);

        // 调用 F(double, int)
        SampleClass2.F(1.0, 1);

        // 调用 F(int, double)
        SampleClass2.F(1, 1.0);

        // 调用 F(int, out double)
        SampleClass2.F(1, out double y);
    }

    private void logList<T>(IEnumerable<T> enumerable)
    {
        StringBuilder builder = new StringBuilder("list = { ");
        foreach (var item in enumerable)
        {
            builder.Append($"{item?.ToString()}, ");
        }

        builder.Append('}');
        Console.WriteLine(builder.ToString());
    }
}
