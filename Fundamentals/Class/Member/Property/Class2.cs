namespace Fundamentals.Class.Member.Property;

public abstract class Class2
{
    private const string TAG = "Class2";

    private int b = 0;

    public abstract int A { get; set; }

    public virtual int B
    {
        get => b;
        set => b = ++value;
    }
}
