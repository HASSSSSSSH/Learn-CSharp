namespace Fundamentals.ObjectOriented;

public class Class2 : AbstractClass, IInterface
{
    private const string TAG = "Class2";

    /// <summary>
    /// 分别调用自身和基类的 getMyTag 方法
    /// 同时重写 <see cref="AbstractClass.Method1(int)"/> 和 <see cref="IInterface.Method1(int)"/>
    /// </summary>
    public override void Method1(int a)
    {
        Console.WriteLine($"{TAG}: Method1(int), getMyTag() = {getMyTag()}, base.getMyTag() = {base.getMyTag()}");
    }

    /// <summary>
    /// 重写 <see cref="IInterface.Method2(string)"/>
    /// </summary>
    public void Method2(string s)
    {
        Console.WriteLine($"{TAG}: Method2(string), s = {s}");
    }

    /// <summary>
    /// 注意到, 此方法带有 public 访问修饰符
    /// </summary>
    public new string getMyTag()
    {
        return TAG;
    }
}
