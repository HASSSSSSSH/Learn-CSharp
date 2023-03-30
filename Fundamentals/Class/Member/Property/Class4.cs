namespace Fundamentals.Class.Member.Property;

public class Class4 : Class2
{
    private const string TAG = "Class4";

    private int i = 0;

    public override int A
    {
        get => 0;
        set
        {
            i = value;
            ++i;
        }
    }

    public override int B
    {
        get => i;
        set { }
    }
}
