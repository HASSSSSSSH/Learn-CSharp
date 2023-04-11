using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reflection.Generic;

[TestClass]
public class ReflectionTest
{
    private const string TAG = "Generic.ReflectionTest";

    /// <summary>
    /// 检查泛型类型和泛型方法
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Type type = typeof(GenericClass1<,>);
        if (type.IsGenericType)
        {
            Console.WriteLine($"{TAG}: Type {type} is generic type");
        }

        MethodInfo[] methodInfos = type.GetMethods();
        foreach (MethodInfo info in methodInfos)
        {
            if (info.IsGenericMethod)
            {
                Console.WriteLine($"{TAG}: Method {info.Name} is generic method");
            }
        }
    }

    /// <summary>
    /// 检查泛型类型定义
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        var types = new Type[]
        {
            typeof(GenericClass1<,>), typeof(GenericClass1<int, char>),
            typeof(GenericClass2), typeof(GenericClass3<>), typeof(GenericClass3<string>)
        };
        foreach (var type in types)
        {
            Console.WriteLine(type.IsGenericTypeDefinition
                ? $"{TAG}: Type {type} is generic type definition"
                : $"{TAG}: Type {type} is not generic type definition");
        }
    }

    /// <summary>
    /// 检查泛型类型参数
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        var types = new Type[]
        {
            typeof(GenericClass1<,>), typeof(GenericClass1<int, char>), typeof(GenericClass2),
            typeof(GenericClass3<>), typeof(GenericClass3<string>)
        };

        foreach (var type in types)
        {
            Type[] typeParameters = type.GetGenericArguments();

            // 如果不是泛型, 则没有泛型类型参数
            if (typeParameters.Length == 0)
            {
                Console.WriteLine($"Type {type} is not a generic type");
                continue;
            }

            Console.WriteLine($"Type {type}: ");

            // 检查类型参数是类型形参还是类型实参
            foreach (Type typeParam in typeParameters)
            {
                if (typeParam.IsGenericParameter)
                {
                    Console.WriteLine("      Type parameter {0} position {1}",
                        typeParam.Name, typeParam.GenericParameterPosition);
                }
                else
                {
                    Console.WriteLine("      Type argument: {0}", typeParam);
                }
            }
        }
    }
}
