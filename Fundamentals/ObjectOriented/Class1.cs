namespace Fundamentals.ObjectOriented;

public class Class1 : AbstractClass, IInterface
{
    private const string TAG = "Class1";

    /// <summary>
    /// 分别调用自身和基类的 getMyTag 方法
    /// 同时重写 <see cref="AbstractClass.Method1(int)"/> 和 <see cref="IInterface.Method1(int)"/>
    /// </summary>
    public override void Method1(int a)
    {
        // 分别调用自身和基类的 getMyTag 方法
        Console.WriteLine($"{TAG}: Method1(int), getMyTag() = {getMyTag()}, base.getMyTag() = {base.getMyTag()}");
    }

    /// <summary>
    /// 注意到, 此方法带有 private 访问修饰符
    /// </summary>
    private new string getMyTag()
    {
        return TAG;
    }
}
