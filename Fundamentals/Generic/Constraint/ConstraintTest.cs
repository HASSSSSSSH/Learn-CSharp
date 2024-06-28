using System.Numerics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Generic.Constraint;

[TestClass]
public class ConstraintTest
{
    private const string TAG = "ConstraintTest";

    /// <summary>
    /// 测试各种类型参数约束
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Class1 class1 = new Class1();
        Class2 class2 = new Class2("Class2");

        // 测试约束 where T : struct
        SampleClass1.Method1<int>(111);
        Console.WriteLine("");

        // 测试约束 where T : class
        SampleClass1.Method2<string>("AAA");
        Console.WriteLine("");

        // 测试约束 where T : class?
        SampleClass1.Method3<string?>(null);
        Console.WriteLine("");

        // 约束 where T : notnull
        SampleClass1.Method4<int?>(null);
        SampleClass1.Method4<string>(null);
        SampleClass1.Method4<string>("zzz");
        Console.WriteLine("");

        // 测试约束 where T : unmanaged
        SampleClass1.Method5<Vector2>(new Vector2(1f, 2f));
        Console.WriteLine("");
        // string 不是非托管类型
        // SampleClass1.Method5<string>("AAA");

        // 测试约束 where T : new()
        SampleClass1.Method6<Class1>(class1);
        Console.WriteLine("");
        // Class2 没有公共无参数构造函数
        // SampleClass1.Method6<Class2>(class2);

        // 测试约束 where T : Class1
        SampleClass1.Method7<Class1>(class1);
        SampleClass1.Method7<Class2>(class2);
        Console.WriteLine("");

        // 测试约束 where T : IEquatable<T>
        SampleClass1.Method8<Class2>(class2);
        Console.WriteLine("");
        // Class1 没有实现指定的接口
        // SampleClass1.Method8<Class1>(class1);

        // 测试约束 where T : U
        SampleClass1.Method9<Class2, Class1>(class2, class1);
        // T 必须是为 U 提供的参数或派生自为 U 提供的参数
        // SampleClass1.Method9<Class1, Class2>(class1, class2);
    }

    /// <summary>
    /// 在使用 where T : class 约束时, 应避免对类型参数使用 == 和 != 运算符
    /// 即使 string 类重载了 == 运算符, 运算符也仅测试引用标识而不测试值相等性
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        string s1 = "target";
        string s2 = new StringBuilder("target").ToString();

        SampleClass2<string>.OpEqualsTest<string>(s1, s2);
        SampleClass2<string>.EqualsTest<string>(s1, s2);
    }
}
