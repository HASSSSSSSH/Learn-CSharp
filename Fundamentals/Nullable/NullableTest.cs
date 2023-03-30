using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Nullable;

[TestClass]
public class NullableTest
{
    private const string TAG = "NullableTest";

    [TestMethod]
    public void TestMethod1()
    {
        int? optionalInt = default;
        Console.Out.WriteLine(
            $"{TAG}: TestMethod1, {((optionalInt == null) ? "optionalInt is null" : " optionalInt is non-null")}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, optionalInt = {optionalInt}");
        optionalInt = 1;
        Console.Out.WriteLine($"{TAG}: TestMethod1, optionalInt = {optionalInt}");

        string? optionalText = null;
        Console.Out.WriteLine(
            $"{TAG}: TestMethod1, {((optionalText == null) ? "optionalText is null" : " optionalText is non-null")}");
        Console.Out.WriteLine($"{TAG}: TestMethod1, optionalText = {optionalText}");
        optionalText = "text";
        Console.Out.WriteLine($"{TAG}: TestMethod1, optionalText = {optionalText}");
    }
}
