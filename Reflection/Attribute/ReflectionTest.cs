using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reflection.Attribute;

[TestClass]
public class ReflectionTest
{
    /// <summary>
    /// 使用反射访问特性
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        var types = new Type[] { typeof(ReflectionTest), typeof(Class1), typeof(Class2), typeof(Class3) };

        foreach (var type in types)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);
            if (attrs.Length == 0)
            {
                Console.WriteLine($"No custom attributes in Type {type}");
                continue;
            }

            Console.WriteLine($"Custom attributes in type {type}:");
            foreach (System.Attribute attr in attrs)
            {
                if (attr is AuthorAttribute a)
                {
                    Console.WriteLine($"   AuthorAttribute: name = {a.GetName()}, version = {a.Version:f}");
                }
                else
                {
                    Console.WriteLine($"   {attr}");
                }
            }
        }
    }

    /// <summary>
    /// 带有自定义特性 AuthorAttribute 的类
    /// </summary>
    [Author("1")]
    class Class1
    {
    }

    /// <summary>
    /// 不带有自定义特性的类
    /// </summary>
    class Class2
    {
    }

    /// <summary>
    /// 带有多个自定义特性 AuthorAttribute 的类
    /// </summary>
    [Author("111111"), Author("222222", Version = 2.0)]
    class Class3
    {
    }
}
