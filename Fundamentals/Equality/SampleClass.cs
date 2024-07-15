namespace Fundamentals.Equality;

/// <summary>
/// 可用于比较值相等性的示例类
/// </summary>
public class SampleClass
{
    private const string TAG = "SampleClass";

    public int X { get; set; }
    public string Y { get; set; }

    public SampleClass(int x, string y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// 重载运算符 ==
    /// </summary>
    public static bool operator ==(SampleClass a, SampleClass b)
    {
        return Equals(a, b);
    }

    /// <summary>
    /// 重载运算符 !=
    /// </summary>
    public static bool operator !=(SampleClass a, SampleClass b)
    {
        return !Equals(a, b);
    }

    /// <summary>
    /// 判断类实例与 obj 的值相等性
    /// </summary>
    public override bool Equals(object? obj)
    {
        return Equals(this, obj as SampleClass);
    }

    /// <summary>
    /// 判断值相等性
    /// </summary>
    private static bool Equals(SampleClass a, SampleClass b)
    {
        if (ReferenceEquals(a, null))
        {
            // 当 a 和 b 同时为 null 时, 返回 ture
            return ReferenceEquals(b, null);
        }

        return a.X == b.X && a.Y == b.Y;
    }

    /// <summary>
    /// 重写 ToString 方法
    /// </summary>
    public override string ToString()
    {
        return $"{TAG}: X = {X}, Y = {Y}";
    }
}
