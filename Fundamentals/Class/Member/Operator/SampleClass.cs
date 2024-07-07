#pragma warning disable CS0660, CS0661
namespace Fundamentals.Class.Member.Operator;

/// <summary>
/// 重载运算符的示例
/// </summary>
public class SampleClass
{
    // 内部数组
    public int[] items;

    public SampleClass(int capacity)
    {
        items = new int[capacity];
    }

    /// <summary>
    /// 一个简单的索引器, 用于读取和写入 items 数组
    /// </summary>
    public int this[int index]
    {
        get => items[index];
        set => items[index] = value;
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
    /// 判断类实例与 obj 的相等性
    /// </summary>
    public override bool Equals(object? obj)
    {
        return Equals(this, obj as SampleClass);
    }

    /// <summary>
    /// 判断相等性
    /// </summary>
    private static bool Equals(SampleClass a, SampleClass b)
    {
        if (ReferenceEquals(a, null))
        {
            // 当 a 和 b 同时为 null 时, 返回 ture
            return ReferenceEquals(b, null);
        }

        if (ReferenceEquals(b, null) || a.items.Length != b.items.Length)
        {
            return false;
        }

        for (int i = 0; i < a.items.Length; i++)
        {
            if (!Equals(a.items[i], b.items[i]))
            {
                return false;
            }
        }

        return true;
    }
}
