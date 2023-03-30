namespace Fundamentals.ObjectOriented;

public class Class4 : Class3
{
    private const string TAG = "Class4";

    /// <summary>
    /// 父类在 getTag() 方法上使用关键字 sealed, 使得此方法不能再被继承
    /// 关键字 new 可以省略, 但是会产生编译器警告
    /// </summary>
    public new string getTag()
    {
        return TAG;
    }
}
