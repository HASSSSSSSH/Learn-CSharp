namespace Fundamentals.Deconstruct;

/// <summary>
/// 扩展系统类型
/// </summary>
public static class NullableExtensions
{
    /// <summary>
    /// 扩展 Nullable<T> 类型, 使其支持析构
    /// </summary>
    public static void Deconstruct<T>(this T? nullable, out bool hasValue, out T value) where T : struct
    {
        hasValue = nullable.HasValue;
        value = nullable.GetValueOrDefault();
    }
}
