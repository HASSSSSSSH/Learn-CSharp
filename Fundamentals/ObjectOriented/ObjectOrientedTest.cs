using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.ObjectOriented;

[TestClass]
public class ObjectOrientedTest
{
    private const string TAG = "ObjectOrientedTest";

    /// <summary>
    /// 测试面向对象的继承和多态性
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        // Class1 是 AbstractClass 的派生类
        AbstractClass class1 = new Class1();

        // 调用的是 Class1.Method1()
        class1.Method1();

        // 调用的是 Class1.Method2()
        class1.Method2();

        if (class1 is ISampleInterface sampleInterface)
        {
            // 调用的是 Class1.Method2(string)
            sampleInterface.Method2("zzz");
        }

        // 调用的是 AbstractClass.GetTag()
        Console.WriteLine($"{TAG}: class1.GetTag() = {class1.GetTag()}");

        // 调用的是 Class1.GetName()
        Console.WriteLine($"{TAG}: class1.GetName() = {class1.GetName()}");
    }

    /// <summary>
    /// 测试面向对象的继承和多态性
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        // Class2 是 AbstractClass 的派生类
        AbstractClass class2 = new Class2();

        // 调用的是 Class2.Method1()
        class2.Method1();

        if (class2 is ISampleInterface sampleInterface)
        {
            // 调用的是 ISampleInterface.Method2(string)
            sampleInterface.Method2("zzz");
        }

        // 调用的是 AbstractClass.GetTag()
        Console.WriteLine($"{TAG}: class1.GetTag() = {class2.GetTag()}");

        // 调用的是 AbstractClass.GetName()
        Console.WriteLine($"{TAG}: class1.GetName() = {class2.GetName()}");
    }

    /// <summary>
    /// 测试面向对象的继承和多态性
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        // Class3 是 AbstractClass 的派生类
        AbstractClass class3 = new Class3();

        // 调用的是 Class3.Method1()
        class3.Method1();

        // 调用的是 Class2.Method2()
        class3.Method2();

        // 调用的是 AbstractClass.GetTag()
        Console.WriteLine($"{TAG}: class1.GetTag() = {class3.GetTag()}");

        // 调用的是 Class3.GetTag()
        Console.WriteLine($"{TAG}: (class3 as Class3)?.GetTag() = {(class3 as Class3)?.GetTag()}");

        // 调用的是 Class3.GetName()
        Console.WriteLine($"{TAG}: class1.GetName() = {class3.GetName()}");
    }

    /// <summary>
    /// 测试面向对象的继承和多态性
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        // 类型为 Class4 的实例
        Class4 class4 = new Class4();

        // 分别创建类型为 Class3, Class2, AbstractClass 的实例
        Class3 class3 = class4;
        Class2 class2 = class4;
        AbstractClass abstractClass = class4;

        // Class4 没有重写 Method1()
        // 遵循虚拟继承的规则, 实际调用的是 Class3.Method1()
        class4.Method1();

        // 遵循虚拟继承的规则, 实际调用的是 Class3.Method1()
        class3.Method1();

        // 遵循虚拟继承的规则, 实际调用的是 Class3.Method1()
        class2.Method1();

        // 遵循虚拟继承的规则, 实际调用的是 Class3.Method1()
        abstractClass.Method1();

        // Class4 重写了 Method2(), 调用的是 Class4.Method2()
        class4.Method2();

        // class3 实际运行时类型为 Class4, 并且 Class4 重写了 Method2()
        // 遵循虚拟继承的规则, 实际调用的是 Class4.Method2()
        class3.Method2();

        // 遵循虚拟继承的规则, 实际调用的是 Class4.Method2()
        class2.Method2();

        // 遵循虚拟继承的规则, 实际调用的是 Class4.Method2()
        abstractClass.Method2();

        // 调用的是 Class4.GetName()
        Console.WriteLine($"{TAG}: class4.GetName() = {class4.GetName()}");

        // class3 实际运行时类型为 Class4, 但 Class4 没有重写 GetName()
        // 遵循虚拟继承的规则, 实际调用的是 Class3.GetName()
        Console.WriteLine($"{TAG}: class3.GetName() = {class3.GetName()}");

        // 遵循虚拟继承的规则, 实际调用的是 Class3.GetName()
        Console.WriteLine($"{TAG}: class2.GetName() = {class2.GetName()}");

        // 遵循虚拟继承的规则, 实际调用的是 Class3.GetName()
        Console.WriteLine($"{TAG}: abstractClass.GetName() = {abstractClass.GetName()}");

        // Class4 重写了 GetTag(), 调用的是 Class4.GetTag()
        Console.WriteLine($"{TAG}: class4.GetTag() = {class4.GetTag()}");

        // class3 实际运行时类型为 Class4, 并且 Class4 重写了 GetTag()
        // 遵循虚拟继承的规则, 实际调用的是 Class4.GetTag()
        Console.WriteLine($"{TAG}: class3.GetTag() = {class3.GetTag()}");

        // class2 实际运行时类型为 Class4, 而 Class2 将自身的 GetTag() 声明为 private
        // 在 GetTag() 的虚拟继承层次结构中, 此处实际调用的是 AbstractClass.GetTag()
        Console.WriteLine($"{TAG}: class2.GetTag() = {class2.GetTag()}");

        // 在 GetTag() 的虚拟继承层次结构中, 此处实际调用的是 AbstractClass.GetTag()
        Console.WriteLine($"{TAG}: abstractClass.GetTag() = {abstractClass.GetTag()}");

        if (class4 is ISampleInterface sampleInterface)
        {
            // 调用的是 ISampleInterface.Method2(string)
            sampleInterface.Method2("zzz");
        }
    }
}
