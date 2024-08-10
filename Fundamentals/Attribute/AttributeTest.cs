using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Fundamentals.Attribute;

// 将特性应用于类 AttributeTest
[TestClass]
[Help("https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/", Topic = "Attributes")]
public class AttributeTest
{
    private const string TAG = "AttributeTest";

    /// <summary>
    /// 检索存储在特性中的信息
    /// </summary>

    // 将特性应用于方法 TestMethod1
    [TestMethod]

    // 可以应用多个 HelpAttribute
    [Help("https://learn.microsoft.com/en-us/dotnet/standard/attributes/retrieving-information-stored-in-attributes")]
    [Help("https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/accessing-attributes-by-using-reflection")]
    [Help("https://learn.microsoft.com/en-us/dotnet/fundamentals/reflection/accessing-custom-attributes")]
    public void TestMethod1()
    {
        // 获取 AttributeTest 类的所有 Attribute
        var classAttributes = System.Attribute.GetCustomAttributes(typeof(AttributeTest), false);
        Console.WriteLine($"{TAG}: {nameof(AttributeTest)} attributes:");
        foreach (var attribute in classAttributes)
        {
            Console.WriteLine($"  attribute.GetType() = {attribute.GetType()}");
            if (attribute is HelpAttribute attr)
            {
                Console.WriteLine($"    HelpAttribute: Url = {attr.Url}, Topic = {attr.Topic}");
            }
        }

        // 获取 AttributeTest.TestMethod1 方法的所有 HelpAttribute
        Type attributeTest = typeof(AttributeTest);
        MethodInfo? testMethod = attributeTest.GetMethod(nameof(TestMethod1));
        if (testMethod != null)
        {
            object[] methodAttributes = testMethod.GetCustomAttributes(typeof(HelpAttribute), false);
            Console.WriteLine($"{TAG}: {nameof(TestMethod1)} attributes:");
            foreach (var attribute in methodAttributes)
            {
                HelpAttribute attr = (HelpAttribute)attribute;
                Console.WriteLine($"  HelpAttribute: Url = {attr.Url}, Topic = {attr.Topic}");
            }
        }
    }

    /// <summary>
    /// 获取类 HelpAttribute 的所有特性 (包括继承关系)
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        var classAttributes = System.Attribute.GetCustomAttributes(typeof(HelpAttribute), true);
        Console.WriteLine($"{TAG}: {nameof(HelpAttribute)} attributes:");
        foreach (var attr in classAttributes)
        {
            Console.WriteLine($"  attribute.GetType() = {attr.GetType()}");

            switch (attr)
            {
                case HelpAttribute helpAttribute:
                    Console.WriteLine($"    HelpAttribute: Url = {helpAttribute.Url}, Topic = {helpAttribute.Topic}");
                    break;
                case AttributeUsageAttribute usageAttribute:
                    Console.WriteLine(
                        $"    AttributeUsageAttribute: ValidOn = {usageAttribute.ValidOn}, Inherited = {usageAttribute.Inherited}, AllowMultiple = {usageAttribute.AllowMultiple}");
                    break;
            }
        }
    }
}
