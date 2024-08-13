using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Reflection;

[TestClass]
public class ReflectionTest
{
    private const string TAG = "ReflectionTest";

    /// <summary>
    /// 使用 Assembly
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Assembly objectAssembly = typeof(object).Assembly;
        Console.WriteLine($"{TAG}: objectAssembly.FullName = {objectAssembly.FullName}");
        Console.WriteLine($"{TAG}: objectAssembly.Location = {objectAssembly.Location}");

        if (objectAssembly.FullName != null)
        {
            // 加载程序集
            Assembly assembly = Assembly.Load(objectAssembly.FullName);

            // 比较引用相等性
            Console.WriteLine(
                $"{TAG}: ReferenceEquals(assembly, objectAssembly) = {ReferenceEquals(assembly, objectAssembly)}");
        }

        // 比较引用相等性
        Assembly objectAssembly2 = typeof(object).Module.Assembly;
        Console.WriteLine(
            $"{TAG}: ReferenceEquals(objectAssembly2, objectAssembly) = {ReferenceEquals(objectAssembly2, objectAssembly)}");
    }

    /// <summary>
    /// 使用 Module
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        var modules = typeof(object).Assembly.GetModules(true);

        // 列出程序集的所有模块
        foreach (var module in modules)
        {
            Console.WriteLine($"{TAG}: module.Name = {module.Name}");
            Console.WriteLine($"{TAG}: module.FullyQualifiedName = {module.FullyQualifiedName}");
            Console.WriteLine($"{TAG}: module.ScopeName = {module.ScopeName}");
        }
    }

    /// <summary>
    /// 获取 Type 对象
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        // 通过 Assembly.GetType 方法获取 Type 对象
        Assembly assembly = Assembly.Load("System.Private.CoreLib.dll");
        Type type1 = assembly.GetType("system.object", true, true)!;
        Console.WriteLine($"{TAG}: type1.FullName = {type1.FullName}");

        // 通过 Module.GetType 方法获取 Type 对象
        Module module = assembly.GetModule("System.Private.CoreLib.dll")!;
        Type type2 = module.GetType("system.object", true, true)!;
        Console.WriteLine($"{TAG}: ReferenceEquals(type2, type1) = {ReferenceEquals(type2, type1)}");

        // 通过 Type.GetType 方法获取 Type 对象
        Type type3 = Type.GetType("system.object", true, true)!;
        Console.WriteLine($"{TAG}: ReferenceEquals(type3, type1) = {ReferenceEquals(type3, type1)}");

        // 使用 typeof 运算符获取 Type 对象
        Type type4 = typeof(object);
        Console.WriteLine($"{TAG}: ReferenceEquals(type4, type1) = {ReferenceEquals(type4, type1)}");
    }

    /// <summary>
    /// 列出类 SampleClass 的构造函数
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        Type type = typeof(SampleClass);
        var constructorInfos =
            type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (ConstructorInfo info in constructorInfos)
        {
            Console.WriteLine("{0}: {1}", TAG, info);
        }
    }

    /// <summary>
    /// 反射创建 SampleClass 对象
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        Type type = typeof(SampleClass);

        // 调用私有无参构造函数
        SampleClass? instance1 = Activator.CreateInstance(type, true) as SampleClass;

        // 调用带参构造函数
        SampleClass? instance2 = Activator.CreateInstance(type, 1, "Test") as SampleClass;

        Console.WriteLine($"{TAG}: instance1?.A = {instance1?.A}, instance1?.B = {instance1?.B}");
        Console.WriteLine($"{TAG}: instance2?.A = {instance2?.A}, instance2?.B = {instance2?.B}");
    }

    /// <summary>
    /// 列出类 SampleClass 的成员
    /// </summary>
    [TestMethod]
    public void TestMethod6()
    {
        Type type = typeof(SampleClass);
        var memberInfos =
            type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (MemberInfo info in memberInfos)
        {
            Console.WriteLine($"{TAG}: {info.MemberType}: {info}");
        }
    }

    /// <summary>
    /// 获取和设置类的字段
    /// </summary>
    [TestMethod]
    public void TestMethod7()
    {
        Type type = typeof(SampleClass);
        SampleClass? instance = Activator.CreateInstance(type, true) as SampleClass;

        // 获取私有实例字段 str
        FieldInfo str = type.GetField("str", BindingFlags.NonPublic | BindingFlags.Instance)!;

        // 获取静态字段 counter
        FieldInfo counter = type.GetField("counter", BindingFlags.Public | BindingFlags.Static)!;

        // 获取 readonly 字段 dateTime
        FieldInfo dateTime = type.GetField("dateTime", BindingFlags.Public | BindingFlags.Instance)!;

        // 获取常量字段 TAG
        FieldInfo tag = type.GetField("TAG", BindingFlags.NonPublic | BindingFlags.Static)!;

        // 获取字段的值
        Console.WriteLine($"{TAG}: str = {str.GetValue(instance)}");
        Console.WriteLine($"{TAG}: counter = {counter.GetValue(instance)}");
        Console.WriteLine($"{TAG}: dateTime = {dateTime.GetValue(instance)}");
        Console.WriteLine($"{TAG}: tag = {tag.GetValue(instance)}");

        // 设置字段的值
        str.SetValue(instance, "new string");
        counter.SetValue(instance, 1);
        dateTime.SetValue(instance, DateTime.Today);

        // 不能设置常量字段的值
        // tag.SetValue(instance, "new value");

        // 重新获取字段的值
        Console.WriteLine($"{TAG}: str = {str.GetValue(instance)}");
        Console.WriteLine($"{TAG}: counter = {counter.GetValue(instance)}");
        Console.WriteLine($"{TAG}: dateTime = {dateTime.GetValue(instance)}");
        Console.WriteLine($"{TAG}: tag = {tag.GetValue(instance)}");
    }

    /// <summary>
    /// 获取和设置类的属性
    /// </summary>
    [TestMethod]
    public void TestMethod8()
    {
        Type type = typeof(SampleClass);
        SampleClass? instance = Activator.CreateInstance(type, true) as SampleClass;

        // 获取类的属性
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            // 获取属性的值
            Console.WriteLine($"{TAG}: property = {property.GetValue(instance)}");

            // 设置属性的值
            switch (property.Name)
            {
                case "A":
                    property.SetValue(instance, 1);
                    break;
                case "B":
                    property.SetValue(instance, "new string");
                    break;
            }

            // 重新获取属性的值
            Console.WriteLine($"{TAG}: property = {property.GetValue(instance)}");
        }
    }

    /// <summary>
    /// 获取类的事件, 并进行添加和移除事件处理程序的操作
    /// </summary>
    [TestMethod]
    public void TestMethod9()
    {
        Type type = typeof(SampleClass);
        SampleClass? instance = Activator.CreateInstance(type, true) as SampleClass;

        // 获取事件 eventHandler
        EventInfo eventInfo = type.GetEvent("eventHandler", BindingFlags.Public | BindingFlags.Instance)!;

        // 添加事件处理程序
        eventInfo.AddEventHandler(instance, new EventHandler(handler));
        eventInfo.AddEventHandler(instance, new EventHandler(handler));
        // eventInfo.AddEventHandler(instance, handler);

        // 引发事件
        instance?.InvokeEventHandler();

        // 移除事件处理程序
        eventInfo.RemoveEventHandler(instance, new EventHandler(handler));
        // eventInfo.RemoveEventHandler(instance, new EventHandler(handler));

        // 重新引发事件
        Console.WriteLine("-------------");
        instance?.InvokeEventHandler();

        void handler(object? sender, EventArgs e)
        {
            Console.WriteLine($"{TAG}: handle event");
        }
    }

    /// <summary>
    /// 使用 MethodInfo 和 ParameterInfo, 并调用类的方法
    /// </summary>
    [TestMethod]
    public void TestMethod10()
    {
        Type type = typeof(SampleClass);
        SampleClass? instance = Activator.CreateInstance(type, true) as SampleClass;

        // 获取私有方法 Method1
        MethodInfo method1 = type.GetMethod("Method1", BindingFlags.NonPublic | BindingFlags.Instance)!;

        // 调用私有方法 Method1
        Console.WriteLine($"{TAG}: {method1.Name} return {method1.Invoke(instance, null)}");

        // 获取方法 Method2
        MethodInfo method2 = type.GetMethod("Method2", BindingFlags.Public | BindingFlags.Instance)!;

        // 调用方法 Method2
        Console.WriteLine($"{TAG}: {method2.Name} return {method2.Invoke(instance, new object?[] { "Test Method2" })}");

        // 获取静态方法 Method3
        MethodInfo method3 = type.GetMethod("Method3", BindingFlags.Public | BindingFlags.Static)!;

        // 获取方法 Method3 的参数
        var parameterInfos = method3.GetParameters();
        Console.WriteLine($"{TAG}: Method3 parameters:");
        foreach (var paramInfo in parameterInfos)
        {
            Console.WriteLine($"  {paramInfo.ParameterType}  {paramInfo.Name}");
        }

        // 调用静态方法 Method3
        int add = 0;
        int sub = 0;
        method3.Invoke(instance, new object?[] { 3, 1, add, sub });
        Console.WriteLine($"{TAG}: add = {add}, sub = {sub}");
    }
}
