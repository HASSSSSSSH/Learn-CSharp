namespace Fundamentals.Class.Member.Property;

/// <summary>
/// Class3 继承自 <see cref="Class2"/>
/// </summary>
public class Class3 : Class2
{
    private string id = null!;

    public Class3(int id)
    {
        Id = id;
    }

    /// <summary>
    /// 实现 Class2 的抽象属性 Id 并使用 sealed 阻止派生类重写该属性
    /// </summary>
    public sealed override int Id
    {
        get { return int.Parse(id); }
        set { id = $"{value}"; }
    }

    /// <summary>
    /// 重写 Class2 的属性 Index
    /// </summary>
    public override int Index { get; init; }
}
