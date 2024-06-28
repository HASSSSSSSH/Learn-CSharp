using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Property;

[TestClass]
public class PropertyTest
{
    private const string TAG = "PropertyTest";

    /// <summary>
    /// 属性的使用
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        // 直接使用静态属性
        Console.WriteLine($"{TAG}: (++Class1.Index) = {++Class1.Index}");

        Class1 instance = new Class1(111, "Jay");

        // A 是读写属性
        instance.A = 777;
        Console.WriteLine($"{TAG}: instance.A = {instance.A}");

        // B 是只读属性
        Console.WriteLine($"{TAG}: instance.B = {instance.B}");
        // instance.B = 0;

        // 调用 UserId 属性的 get 访问器
        Console.WriteLine($"{TAG}: instance.UserId = {instance.UserId}");

        // Id 是只写属性
        instance.Id = 100;
        // Console.WriteLine($"{TAG}: instance.Id = {instance.Id}");

        // 再次调用 UserId 属性的 get 访问器
        Console.WriteLine($"{TAG}: instance.UserId = {instance.UserId}");

        // 此处不能直接调用属性 Name 的私有 get 访问器
        // Console.WriteLine($"{TAG}: instance.Name = {instance.Name}");
        instance.Test();
    }

    /// <summary>
    /// 使用 virtual 和 abstract 属性
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        Class3 instance = new Class3(666)
        {
            // 通过对象初始值设定项使用 Index 属性的 init 访问器
            Index = 11
        };

        Console.WriteLine($"{TAG}: instance.Id = {instance.Id}, instance.Index = {instance.Index}");
    }
}
