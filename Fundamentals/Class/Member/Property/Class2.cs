namespace Fundamentals.Class.Member.Property;

/// <summary>
/// 可以将属性声明为 virtual, abstract, sealed
/// </summary>
public abstract class Class2
{
    private int _index = 0;

    public abstract int Id { get; set; }

    public virtual int Index
    {
        get => _index;
        init => _index = ++value;
    }
}
