using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Fundamentals.Attribute;

[TestClass]
[HelpAttribute("https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/features#attributes")]
public class AttributeTest
{
    private const string TAG = "AttributeTest";

    [TestMethod, Help("https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/features", Topic = "attributes")]
    public void TestMethod1()
    {
        // 获取 AttributeTest 所有的 Attribute
        Type attributeTest = typeof(AttributeTest);
        object[] classAttributes = attributeTest.GetCustomAttributes(typeof(HelpAttribute), false);
        foreach (var attribute in classAttributes)
        {
            Type type = attribute.GetType();
            Console.WriteLine($"{TAG}: TestMethod1(), classAttributes, attribute.GetType() = {type}");
            if (type == typeof(HelpAttribute))
            {
                HelpAttribute attr = (HelpAttribute)attribute;
                Console.WriteLine(
                    $"{TAG}: TestMethod1(), classAttributes, attr.Url = {attr.Url}, attr.Topic = {attr.Topic}");
            }
        }

        // 获取 AttributeTest.TestMethod1 所有的 Attribute
        MethodInfo? testMethod = attributeTest.GetMethod(nameof(TestMethod1));
        if (testMethod != null)
        {
            object[] methodAttributes = testMethod.GetCustomAttributes(typeof(HelpAttribute), false);
            foreach (var attribute in methodAttributes)
            {
                Type type = attribute.GetType();
                Console.WriteLine($"{TAG}: TestMethod1(), methodAttributes, attribute.GetType() = {type}");
                if (type == typeof(HelpAttribute))
                {
                    HelpAttribute attr = (HelpAttribute)attribute;
                    Console.WriteLine(
                        $"{TAG}: TestMethod1(), methodAttributes, attr.Url = {attr.Url}, attr.Topic = {attr.Topic}");
                }
            }
        }
    }
}
