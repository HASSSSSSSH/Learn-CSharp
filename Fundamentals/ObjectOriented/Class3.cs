namespace Fundamentals.ObjectOriented;

/// <summary>
/// Class3 派生自 <see cref="Class2"/>
/// </summary>
public class Class3 : Class2
{
    private const string TAG = "Class3";

    /// <summary>
    /// 重写 <see cref="Class2.Method1()"/>
    /// 关键字 sealed 使得此方法不能再被继承
    /// </summary>
    public sealed override void Method1()
    {
        // 调用的是自身和 AbstractClass 的 GetTag()
        Console.WriteLine($"{TAG}: Method1(), GetTag() = {GetTag()}, base.GetTag() = {base.GetTag()}");
    }

    // 由于 Class3 继承自 Class2, 不再必须重写此抽象方法
    // public override void Method2()
    // {
    //     Console.WriteLine($"{TAG}: Method2()");
    // }

    /// <summary>
    /// 重写虚方法 <see cref="AbstractClass.GetName"/>
    /// 关键字 sealed 使得此方法不能再被继承
    /// </summary>
    public sealed override string GetName()
    {
        return TAG;
    }

    /// <summary>
    /// 使用 new 关键字声明与基类相同名称和签名的方法
    /// 此方法是一个虚方法
    /// </summary>
    public new virtual string GetTag()
    {
        return TAG;
    }
}
