namespace Fundamentals.ObjectOriented;

/// <summary>
/// Class1 派生自 <see cref="AbstractClass"/> 和 <see cref="ISampleInterface"/>
/// </summary>
public class Class1 : AbstractClass, ISampleInterface
{
    private const string TAG = "Class1";

    /// <summary>
    /// 重写 <see cref="AbstractClass.Method1()"/> 并实现 <see cref="ISampleInterface.Method1()"/>
    /// </summary>
    public override void Method1()
    {
        // 分别调用自身和基类的 GetName()
        Console.WriteLine($"{TAG}: Method1(), GetName() = {GetName()}, base.GetName() = {base.GetName()}");

        // 都是调用自身的 Method2(string)
        // ISampleInterface sampleInterface = this;
        // Method2("AAA");
        // sampleInterface.Method2("AAA");
    }

    /// <summary>
    /// 重写抽象方法 <see cref="AbstractClass.Method2()"/>
    /// </summary>
    public override void Method2()
    {
        Console.WriteLine($"{TAG}: Method2()");
    }

    /// <summary>
    /// 实现接口方法 <see cref="ISampleInterface.Method2(string)"/>
    /// 由于此接口方法有默认实现, 因此这里不一定需要实现此方法
    /// </summary>
    public void Method2(string s)
    {
        Console.WriteLine($"{TAG}: Method2(string), s = {s}");
    }

    /// <summary>
    /// 重写虚方法 <see cref="AbstractClass.GetName"/>
    /// </summary>
    public override string GetName()
    {
        return TAG;
    }
}
