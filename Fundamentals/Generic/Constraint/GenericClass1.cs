namespace Fundamentals.Generic.Constraint;

public class GenericClass1<T> where T : BaseClass
{
    public string Method1(T t)
    {
        // 可直接使用约束类型的属性
        return t.name;
    }
}
