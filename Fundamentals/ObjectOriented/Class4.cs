namespace Fundamentals.ObjectOriented;

/// <summary>
/// Class4 派生自 <see cref="Class3"/>
/// </summary>
public class Class4 : Class3
{
    private const string TAG = "Class4";

    // 由于基类 Class3 在 Method1() 上使用 sealed 关键字, 使得此方法不能被重写
    // public override void Method1()
    // {
    // }

    /// <summary>
    /// 仍然可以重写 <see cref="Class3.Method2()"/>
    /// </summary>
    public override void Method2()
    {
        // 分别调用 Class3 和 AbstractClass 的 GetTag()
        Console.WriteLine($"{TAG}: Method2(), base.GetTag() = {base.GetTag()}," +
                          $" (this as AbstractClass).GetTag() = {(this as AbstractClass).GetTag()}");
    }

    /// <summary>
    /// 由于基类在 <see cref="Class3.GetName"/> 上使用 sealed 关键字, 使得此方法不能被重写
    /// 仍然可以使用 new 关键字声明与基类相同名称和签名的方法
    /// 关键字 new 可以省略, 但是会产生编译器警告
    /// </summary>
    public new string GetName()
    {
        return TAG;
    }

    /// <summary>
    /// 重写虚方法 <see cref="Class3.GetTag"/>
    /// </summary>
    public override string GetTag()
    {
        return TAG;
    }
}
