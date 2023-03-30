namespace Fundamentals.ObjectOriented;

public class Class3 : AbstractClass, IInterface
{
    private const string TAG = "Class3";

    /// <summary>
    /// 同时重写 <see cref="AbstractClass.Method1(int)"/> 和 <see cref="IInterface.Method1(int)"/>
    /// </summary>
    public override void Method1(int a)
    {
        Console.WriteLine($"{TAG}: Method1(int)");
    }

    /// <summary>
    /// 重写 <see cref="AbstractClass.getTag()"/>
    /// 关键字 sealed 使得此方法不能再被继承
    /// </summary>
    public sealed override string getTag()
    {
        return TAG;
    }
}
