namespace Fundamentals.TypeConversion;

/// <summary>
/// 基类
/// </summary>
public class BaseClass
{
    private const string TAG = "BaseClass";

    public virtual string GetName()
    {
        return TAG;
    }

    public string GetTag()
    {
        return TAG;
    }
}
