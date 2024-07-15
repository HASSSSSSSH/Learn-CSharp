namespace Fundamentals.ObjectOriented;

/// <summary>
/// Class2 派生自 <see cref="AbstractClass"/> 和 <see cref="ISampleInterface"/>
/// </summary>
public class Class2 : AbstractClass, ISampleInterface
{
    private const string TAG = "Class2";

    /// <summary>
    /// 重写 <see cref="AbstractClass.Method1()"/> 并实现 <see cref="ISampleInterface.Method1()"/>
    /// </summary>
    public override void Method1()
    {
        // 分别调用自身和基类的 getTag()
        Console.WriteLine($"{TAG}: Method1(), getTag() = {getTag()}, base.getTag() = {base.getTag()}");
    }

    /// <summary>
    /// 重写抽象方法 <see cref="AbstractClass.Method2()"/>
    /// </summary>
    public override void Method2()
    {
        Console.WriteLine($"{TAG}: Method2()");
    }

    // 不实现此接口方法
    // public void Method2(string s)
    // {
    //     Console.WriteLine($"{TAG}: Method2(string), s = {s}");
    // }

    /// <summary>
    /// 隐藏基类成员 <see cref="AbstractClass.getTag()"/>
    /// 注意, 此处访问修饰符为 private
    /// </summary>
    private new string getTag()
    {
        return TAG;
    }
}
