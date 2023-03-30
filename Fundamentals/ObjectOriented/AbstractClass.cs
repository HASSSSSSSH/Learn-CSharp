namespace Fundamentals.ObjectOriented;

public abstract class AbstractClass
{
    private const string TAG = "AbstractClass";

    /// <summary>
    /// 抽象方法
    /// </summary>
    public abstract void Method1(int a);

    public string getMyTag()
    {
        return TAG;
    }

    /// <summary>
    /// 虚方法
    /// </summary>
    public virtual string getTag()
    {
        return TAG;
    }

    /// <summary>
    /// 重写 <see cref="System.Object.ToString()"/>
    /// </summary>
    public override string ToString()
    {
        return TAG;
    }
}
