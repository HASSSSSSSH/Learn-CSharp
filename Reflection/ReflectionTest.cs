#pragma warning disable CS8632

using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reflection;

[TestClass]
public class ReflectionTest
{
    private const string TAG = "ReflectionTest";

    /// <summary>
    /// 获取 Assembly
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Assembly objectAssembly = typeof(Object).Module.Assembly;
        Console.WriteLine($"{TAG}: objectAssembly.FullName = {objectAssembly.FullName}");
        Console.WriteLine($"{TAG}: objectAssembly.Location = {objectAssembly.Location}");

        if (objectAssembly.FullName != null)
        {
            Assembly assembly = Assembly.Load(objectAssembly.FullName);
            Console.WriteLine($"{TAG}: assembly.Equals(objectAssembly) = {assembly.Equals(objectAssembly)}");
        }
    }

    /// <summary>
    /// 获取 Module
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        Module module = typeof(Object).Module;
        Console.WriteLine($"{TAG}: module.FullyQualifiedName = {module.FullyQualifiedName}");
        Console.WriteLine($"{TAG}: module.Name = {module.Name}");
        Console.WriteLine($"{TAG}: module.ScopeName = {module.ScopeName}");
    }

    /// <summary>
    /// 获取 Type
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        Type type1 = typeof(Object);
        Console.WriteLine($"{TAG}: type.FullName = {type1.FullName}");

        // 通过 Type.GetType 方法获取 Type, 参数 ignoreCase 表示类型名称是否需要区分大小写
        Type type2 = Type.GetType("system.object", true, true);
        Console.WriteLine($"{TAG}: (type2 == type1) = {type2 == type1}");

        // 从 Assembly 获取 Type
        Assembly assembly = Assembly.Load("System.Private.CoreLib.dll");
        Type type3 = assembly.GetType("system.object", true, true);
        Console.WriteLine($"{TAG}: (type3 == type1) = {type3 == type1}");
    }

    /// <summary>
    /// 反射创建对象
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        Assembly assembly = Assembly.Load("System.Private.CoreLib.dll");
        Type type = assembly.GetType("System.Object", true, false);
        if (type != null)
        {
            object obj = Activator.CreateInstance(type);
            if (obj != null)
            {
                Console.WriteLine($"{TAG}: obj.GetHashCode() = {obj.GetHashCode()}");
            }
        }
    }

    /// <summary>
    /// 列出类的成员
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        Type type = typeof(Class1);
        if (type.IsPublic)
        {
            Console.WriteLine($"{TAG}: Type {type.Name} is Public");
        }

        MemberInfo[] memberInfos = type.GetMembers();
        foreach (MemberInfo info in memberInfos)
        {
            Console.WriteLine($"{TAG}: info = {info}, info.MemberType = {info.MemberType}");
        }
    }

    /// <summary>
    /// 列出类的构造函数
    /// </summary>
    [TestMethod]
    public void TestMethod6()
    {
        Type type = typeof(Class1);
        ConstructorInfo[] constructorInfos =
            type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (ConstructorInfo info in constructorInfos)
        {
            Console.WriteLine("{0}: {1}", TAG, info);
        }
    }

    /// <summary>
    /// 列出类的私有字段
    /// </summary>
    [TestMethod]
    public void TestMethod7()
    {
        Type type = typeof(Class1);
        FieldInfo[] fieldInfos =
            type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (FieldInfo info in fieldInfos)
        {
            Console.WriteLine("{0}: {1}", TAG, info);
        }
    }

    /// <summary>
    /// 获取和设置类的私有字段
    /// </summary>
    [TestMethod]
    public void TestMethod8()
    {
        Type type = typeof(Class1);

        // 获取私有字段 b
        FieldInfo fieldInfo = type.GetField("b", BindingFlags.NonPublic | BindingFlags.Instance);

        if (fieldInfo != null)
        {
            // 调用构造函数 Class1(int, string)
            Class1 instance = (Class1)Activator.CreateInstance(type, 1, "AAA");

            Console.WriteLine($"{TAG}: fieldInfo.GetValue(instance) = {fieldInfo.GetValue(instance)}");
            fieldInfo.SetValue(instance, "CCC");
            Console.WriteLine($"{TAG}: fieldInfo.GetValue(instance) = {fieldInfo.GetValue(instance)}");
        }
    }

    /// <summary>
    /// 列出类的私有方法
    /// </summary>
    [TestMethod]
    public void TestMethod9()
    {
        Type type = typeof(Class1);
        MethodInfo[] methodInfos =
            type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (MethodInfo info in methodInfos)
        {
            Console.WriteLine("{0}: {1}", TAG, info);
        }
    }

    /// <summary>
    /// 调用类的私有方法
    /// </summary>
    [TestMethod]
    public void TestMethod10()
    {
        Type type = typeof(Class1);

        // 获取私有方法 Method2
        MethodInfo methodInfo = type.GetMethod("Method2", BindingFlags.NonPublic | BindingFlags.Instance);

        if (methodInfo != null)
        {
            // 调用私有构造函数 Class1()
            Class1 instance = (Class1)Activator.CreateInstance(type, true);

            // 获取方法的参数列表
            StringBuilder builder = new StringBuilder($"{TAG}: {methodInfo.Name} ParameterType = [");
            ParameterInfo[] parameterInfos = methodInfo.GetParameters();
            foreach (var paramInfo in parameterInfos)
            {
                builder.Append($"{paramInfo.ParameterType}, ");
            }

            Console.WriteLine(builder.ToString() + "]");

            Console.WriteLine(
                $"{TAG}: {methodInfo.Name} return {methodInfo.Invoke(instance, new object[] { 11, 100 })}");
        }
    }

    /// <summary>
    /// 获取并调用类的事件
    /// </summary>
    [TestMethod]
    public void TestMethod11()
    {
        Type type = typeof(Class1);

        // 获取事件 eventHandler
        EventInfo eventInfo = type.GetEvent("eventHandler", BindingFlags.Public | BindingFlags.Instance);

        if (eventInfo != null)
        {
            // 调用私有构造函数 Class1()
            Class1 instance = (Class1)Activator.CreateInstance(type, true);

            void handler(object? sender, EventArgs e)
            {
                Console.WriteLine($"{TAG}: Invoke eventHandler");
            }

            eventInfo.AddEventHandler(instance, new EventHandler(handler));
            eventInfo.AddEventHandler(instance, new EventHandler(handler));
            instance!.InvokeEventHandler();
        }
    }
}
