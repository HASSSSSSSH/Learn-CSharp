using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Enum;

[TestClass]
public class EnumTest
{
    private const string TAG = "EnumTest";

    /// <summary>
    /// 测试枚举类型 SampleEnum 与其基础整型类型之间的显式转换
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        SampleEnum enumA = SampleEnum.A;
        SampleEnum enumB = SampleEnum.B;
        SampleEnum enumC = SampleEnum.C;
        int a = (int)enumA;
        int b = (int)enumB;
        int c = (int)enumC;

        Console.WriteLine($"{TAG}: enumA = {enumA}, enumB = {enumB}, enumC = {enumC}");
        Console.WriteLine($"{TAG}: a = {a}, b = {b}, c = {c}");

        // 从整型类型显式转换到枚举类型
        SampleEnum enumA2 = 0;
        Console.WriteLine($"{TAG}: (enumA == enumA2) = {enumA == enumA2}");
    }

    /// <summary>
    /// 测试枚举类型 ErrorCodeEnum 与 ushort 之间的显式转换
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        ErrorCodeEnum enum1 = default(ErrorCodeEnum);
        ErrorCodeEnum enum2 = ErrorCodeEnum.Unknown;
        ErrorCodeEnum enum3 = ErrorCodeEnum.ConnectionLost;
        ErrorCodeEnum enum4 = ErrorCodeEnum.OutlierReading;
        ushort a = (ushort)enum1;
        ushort b = (ushort)enum2;
        ushort c = (ushort)enum3;
        ushort d = (ushort)enum4;

        Console.WriteLine($"{TAG}: enum1 = {enum1}, enum2 = {enum2}, enum3 = {enum3}, enum4 = {enum4}");
        Console.WriteLine($"{TAG}: a = {a}, b = {b}, c = {c}, d = {d}");

        // 从 ushort 显式转换到枚举类型
        ErrorCodeEnum enum5 = (ErrorCodeEnum)200;
        Console.WriteLine($"{TAG}: (enum4 == enum5) = {enum4 == enum5}");
    }

    /// <summary>
    /// 测试作为位标志的枚举类型
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        FlagsEnum enumNone = FlagsEnum.None;
        FlagsEnum enumA = FlagsEnum.A;
        FlagsEnum enumB = FlagsEnum.B;
        FlagsEnum enumC = FlagsEnum.C;
        FlagsEnum enumALL = FlagsEnum.ALL;
        int none = (int)enumNone;
        int a = (int)enumA;
        int b = (int)enumB;
        int c = (int)enumC;
        int all = (int)enumALL;

        Console.WriteLine(
            $"{TAG}: enumNone = {enumNone}, enumA = {enumA}, enumB = {enumB}, enumC = {enumC}, enumALL = {enumALL}");
        Console.WriteLine($"{TAG}: none = {none}, a = {a}, b = {b}, c = {c}, all = {all}");

        Console.WriteLine($"{TAG}: ((enumALL ^ enumC) == (enumA | enumB)) = {(enumALL ^ enumC) == (enumA | enumB)}");
        Console.WriteLine($"{TAG}: ((enumALL ^ enumB ^ enumC) == enumA) = {(enumALL ^ enumB ^ enumC) == enumA}");
        Console.WriteLine(
            $"{TAG}: ((enumALL ^ enumA ^ enumB ^ enumC) == enumNone) = {(enumALL ^ enumA ^ enumB ^ enumC) == enumNone}");
    }

    /// <summary>
    /// 使用 Enum.IsDefined 方法来确定枚举类型是否包含具有特定关联值的枚举成员
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        // SampleEnum 没有递增到 3
        SampleEnum sampleEnum = (SampleEnum)3;
        Console.WriteLine($"{TAG}: sampleEnum = {sampleEnum}");
        Console.WriteLine(
            $"{TAG}: System.Enum.IsDefined(typeof(SampleEnum), 3) = {System.Enum.IsDefined(typeof(SampleEnum), 3)}");
    }
}
