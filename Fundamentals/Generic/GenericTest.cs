using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Generic;

[TestClass]
public class GenericTest
{
    private const string TAG = "GenericTest";

    /// <summary>
    /// 泛型类和泛型方法的使用
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Class1<int, string> class1 = new Class1<int, string>(100, "ZZZ");
        Console.Out.WriteLine($"{TAG}: class1.X.GetType() = {class1.X.GetType()}");
        Console.Out.WriteLine($"{TAG}: class1.Y!.GetType() = {class1.Y!.GetType()}");
        class1.Method1<char>('a');
        class1.Method1(10);
        class1.Method1("AAA");
    }

    /// <summary>
    /// 泛型类和泛型方法的使用
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        Class2<int, string> class2 = new Class2<int, string>();
        class2.Add(100, "ZZZ");
        class2.Method1<char>('c');
        class2.Method1(1);
    }

    /// <summary>
    /// 泛型类的使用
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        Class3<string> class3 = new Class3<string>();
        class3.Method1("AAA");
    }

    /// <summary>
    /// 泛型类和泛型方法的使用
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        Class4 class4 = new Class4();
        class4.Method1<char>('c');
    }

    /// <summary>
    /// 泛型的类型检查
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {
        var instance1 = new Class1<int, string>();
        var instance2 = new Class1<string, string>();
        var instance3 = new Class2<int, string>();
        var instance4 = new Class2<string, int>();
        var instance5 = new Class3<string>();
        var instance6 = new Class4();

        Console.Out.WriteLine($"instance1.GetType() = {instance1.GetType()}");
        Console.Out.WriteLine($"instance2.GetType() = {instance2.GetType()}");
        Console.Out.WriteLine($"instance3.GetType() = {instance3.GetType()}");
        Console.Out.WriteLine($"instance4.GetType() = {instance4.GetType()}");
        Console.Out.WriteLine($"instance5.GetType() = {instance5.GetType()}");
        Console.Out.WriteLine($"instance6.GetType() = {instance6.GetType()}");
        Console.Out.WriteLine($"instance1.GetType().Name = {instance1.GetType().Name}");
        Console.Out.WriteLine($"instance2.GetType().Name = {instance2.GetType().Name}");
        Console.Out.WriteLine($"instance3.GetType().Name = {instance3.GetType().Name}");
        Console.Out.WriteLine($"instance4.GetType().Name = {instance4.GetType().Name}");
        Console.Out.WriteLine($"instance5.GetType().Name = {instance5.GetType().Name}");
        Console.Out.WriteLine($"instance6.GetType().Name = {instance6.GetType().Name}");

        // 将 typeof(Class1<,>) 与 instance1 的类型进行比较
        Console.Out.WriteLine(
            $"(instance1.GetType() == typeof(Class1<,>)) = {instance1.GetType() == typeof(Class1<,>)}");

        // 将 typeof(Class1<int, string>) 与 instance1 的类型进行比较
        Console.Out.WriteLine(
            $"(instance1.GetType() == typeof(Class1<int, string>)) = {instance1.GetType() == typeof(Class1<int, string>)}");

        // 比较 instance1 和 instance2 的类型
        Console.Out.WriteLine(
            $"(instance1.GetType() == instance2.GetType()) = {instance1.GetType() == instance2.GetType()}");
        Console.Out.WriteLine(
            $"(instance1.GetType().Name == instance2.GetType().Name) = {instance1.GetType().Name == instance2.GetType().Name}");

        // 使用 is 运算符来执行类型检查
        Console.Out.WriteLine($"instance3 is Class2<int, string> = {instance3 is Class2<int, string>}");
        Console.Out.WriteLine($"instance3 is Class1<int, string> = {instance3 is Class1<int, string>}");
        Console.Out.WriteLine($"instance4 is Class1<int, string> = {instance4 is Class1<int, string>}");
        Console.Out.WriteLine($"instance5 is Class1<string, string> = {instance5 is Class1<string, string>}");
        Console.Out.WriteLine($"instance6 is Class1<int, string> = {instance6 is Class1<int, string>}");
    }

    /// <summary>
    /// 泛型的类型转换
    /// </summary>
    [TestMethod]
    public void TestMethod6()
    {
        Class3<string> class3 = new Class3<string>();
        Class4 class4 = new Class4();

        // class3, class4 隐式转换为基类型
        Class1<Class1<string, string>, Class1<int, string>> class1 =
            new Class1<Class1<string, string>, Class1<int, string>>(class3, class4);

        // 调用 Class1`2[A, B].Method1[A](A) 并将 Class2 隐式转换为 Class1
        class1.Method1<Class1<char, char>>(new Class2<char, char>());
        Console.Out.WriteLine();

        // 使用 is 运算符对 class1.X 执行类型检查
        if (class1.X is Class3<string> _class3)
        {
            // 调用 Class3`1[T].Method1(T)
            _class3.Method1("AAA");
            Console.Out.WriteLine();
        }

        // 调用的是 Class4.Method1[T](T)
        class1.Y!.Method1<char>('c');
    }
}
