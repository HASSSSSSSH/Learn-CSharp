namespace Fundamentals.Reflection.Generic;

/// <summary>
/// GenericClass3 继承自 GenericClass1
/// 在类的声明中直接指定 GenericClass1 的类型参数
/// </summary>
public class GenericClass3 : GenericClass1<int, string>
{
    private const string TAG = "Generic.GenericClass3";
}
