namespace Fundamentals.TypeConversion;

/// <summary>
/// 派生类
/// 继承自 <see cref="BaseClass"/>
/// </summary>
public class DerivedClass : BaseClass
{
    private const string TAG = "DerivedClass";

    public override string GetName()
    {
        return TAG;
    }

    public new string GetTag()
    {
        return TAG;
    }
}
