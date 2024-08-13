using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Reflection.Generic;

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
        // 检查类型是否为泛型类型
        Type type = typeof(GenericClass1<,>);
        if (type.IsGenericType)
        {
            Console.WriteLine($"{TAG}: Type \"{type}\" is generic type");
        }

        // 检查方法是否为泛型方法
        var methodInfos = type.GetMethods();
        foreach (MethodInfo methodInfo in methodInfos)
        {
            if (methodInfo.IsGenericMethod)
            {
                Console.WriteLine($"{TAG}: Method \"{methodInfo.Name}\" is generic method");
            }
        }
    }

    /// <summary>
    /// 检查 Type 对象是否表示泛型类型定义
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        var types = new Type[]
        {
            typeof(GenericClass1<,>), typeof(GenericClass1<int, char>),
            typeof(GenericClass2<>), typeof(GenericClass2<string>), typeof(GenericClass3),
            typeof(GenericClass2<>).BaseType!
        };
        foreach (var type in types)
        {
            Console.WriteLine(type.IsGenericTypeDefinition
                ? $"{TAG}: Type \"{type}\" is generic type definition"
                : $"{TAG}: Type \"{type}\" is not generic type definition");
        }
    }

    /// <summary>
    /// 检查泛型类型是开放式还是封闭式
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        var types = new Type[]
        {
            typeof(GenericClass1<,>), typeof(GenericClass1<int, char>),
            typeof(GenericClass2<>), typeof(GenericClass2<string>), typeof(GenericClass3),
            typeof(GenericClass2<>).BaseType!
        };
        foreach (var type in types)
        {
            Console.WriteLine(type.ContainsGenericParameters
                ? $"{TAG}: Type \"{type}\" is open"
                : $"{TAG}: Type \"{type}\" is closed");
        }
    }

    /// <summary>
    /// 创建封闭式泛型类型
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        Type generic = typeof(GenericClass1<,>);

        // MakeGenericType 方法用于创建封闭式泛型类型
        Type constructed = generic.MakeGenericType(typeof(int), typeof(string));

        DisplayTypeInfo(generic);
        DisplayTypeInfo(constructed);

        Type type = typeof(GenericClass1<int, string>);
        Console.WriteLine("\r\nconstructed types equal: {0}", type == constructed);

        // GetGenericTypeDefinition 方法用于获取泛型类型定义
        Console.WriteLine("generic types equal: {0}", type.GetGenericTypeDefinition() == generic);

        void DisplayTypeInfo(Type t)
        {
            Console.WriteLine("\r\n{0}", t);
            Console.WriteLine("\tIsGenericTypeDefinition: {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("\tIsGenericType: {0}", t.IsGenericType);

            var typeArguments = t.GetGenericArguments();
            Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
            foreach (Type argument in typeArguments)
            {
                Console.WriteLine("\t\t{0}", argument);
            }
        }
    }

    /// <summary>
    /// 检查类型实参和类型形参
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        var types = new Type[]
        {
            typeof(GenericClass1<,>), typeof(GenericClass1<int, char>),
            typeof(GenericClass2<>), typeof(GenericClass2<string>), typeof(GenericClass3),
            typeof(GenericClass2<>).BaseType!
        };

        foreach (var type in types)
        {
            var arguments = type.GetGenericArguments();

            // 如果不是泛型, 则没有泛型类型参数
            if (!type.IsGenericType)
            {
                Console.WriteLine($"\r\nType \"{type}\" is not a generic type");
                Console.WriteLine($"\t\targuments.Length = {arguments.Length}");
                continue;
            }

            Console.WriteLine("\r\n{0}", type);

            // 使用 IsGenericParameter 检查类型参数是类型形参还是类型实参
            foreach (Type t in arguments)
            {
                if (t.IsGenericParameter)
                {
                    Console.WriteLine("\t\t{0}\t(unassigned - parameter position {1})",
                        t,
                        t.GenericParameterPosition);
                }
                else
                {
                    Console.WriteLine("\t\t{0}", t);
                }
            }
        }
    }
}
