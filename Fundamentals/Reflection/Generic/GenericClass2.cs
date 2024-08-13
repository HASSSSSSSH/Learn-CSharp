namespace Fundamentals.Reflection.Generic;

/// <summary>
/// GenericClass2 继承自 GenericClass1
/// 将 GenericClass2 的类型参数 T 指定给 GenericClass1 的类型参数 A
/// </summary>
public class GenericClass2<T> : GenericClass1<T, int>
{
    private const string TAG = "Generic.GenericClass2<T>";
}
