namespace Fundamentals.ObjectOriented;

/// <summary>
/// 抽象类示例
/// </summary>
public abstract class AbstractClass
{
    private const string TAG = "AbstractClass";

    /// <summary>
    /// 抽象方法
    /// </summary>
    public abstract void Method1();

    /// <summary>
    /// 抽象方法
    /// </summary>
    public abstract void Method2();

    /// <summary>
    /// 虚方法
    /// </summary>
    public virtual string getName()
    {
        return TAG;
    }

    /// <summary>
    /// 普通方法
    /// </summary>
    public string getTag()
    {
        return TAG;
    }
}
