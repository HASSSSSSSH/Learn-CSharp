namespace Fundamentals.Generic.Constraint;

/// <summary>
/// Class2 继承自 <see cref="Constraint.Class1"/> 并且实现接口 <see cref="System.IEquatable"/> 
/// </summary>
public class Class2 : Class1, IEquatable<Class2>
{
    public Class2(string name)
    {
        this.Name = name;
    }

    public bool Equals(Class2? other)
    {
        return other != null && other.Name == this.Name;
    }
}
