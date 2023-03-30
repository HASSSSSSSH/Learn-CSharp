namespace Fundamentals.Class.Member;

public abstract class AbstractClass
{
    private const string TAG = "AbstractClass";

    public abstract void Method1(int a);

    public string getMyTag()
    {
        return TAG;
    }

    public virtual string getTag()
    {
        return TAG;
    }

    public override string ToString()
    {
        return TAG;
    }
}
