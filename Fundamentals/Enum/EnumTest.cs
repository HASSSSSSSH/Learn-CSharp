using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Enum;

[TestClass]
public class EnumTest
{
    private const string TAG = "EnumTest";

    /// <summary>
    /// 测试枚举类型与其基础整型类型之间的显式转换
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Enum1 enumA = Enum1.A;
        Enum1 enumB = Enum1.B;
        Enum1 enumC = Enum1.C;
        int a = (int)enumA;
        int b = (int)enumB;
        int c = (int)enumC;
        Console.WriteLine($"{TAG}: enumA = {enumA}, enumB = {enumB}, enumC = {enumC}");
        Console.WriteLine($"{TAG}: a = {a}, b = {b}, c = {c}");

        Enum1 enumA2 = 0;
        Console.WriteLine($"{TAG}: (enumA == enumA2) = {enumA == enumA2}");

        // Enum1 没有递增到 3
        Enum1 enum1 = (Enum1)3;
        Console.WriteLine($"{TAG}: enum1 = {enum1}");
        Console.WriteLine(
            $"{TAG}: System.Enum.IsDefined(typeof(Enum1), 3) = {System.Enum.IsDefined(typeof(Enum1), 3)}");
    }

    [TestMethod]
    public void TestMethod2()
    {
        Enum2 enumNone = Enum2.None;
        Enum2 enumA = Enum2.A;
        Enum2 enumB = Enum2.B;
        Enum2 enumC = Enum2.C;
        Enum2 enumALL = Enum2.ALL;
        int none = (int)enumNone;
        int a = (int)enumA;
        int b = (int)enumB;
        int c = (int)enumC;
        int all = (int)enumALL;
        Console.WriteLine(
            $"{TAG}: enumNone = {enumNone}, enumA = {enumA}, enumB = {enumB}, enumC = {enumC}, enumALL = {enumALL}");
        Console.WriteLine($"{TAG}: none = {none}, a = {a}, b = {b}, c = {c}, all = {all}");

        Console.WriteLine($"{TAG}: ((enumALL ^ enumB ^ enumC) == enumA) = {(enumALL ^ enumB ^ enumC) == enumA}");
        Console.WriteLine(
            $"{TAG}: ((enumALL ^ enumA ^ enumB ^ enumC) == enumNone) = {(enumALL ^ enumA ^ enumB ^ enumC) == enumNone}");
    }
}
