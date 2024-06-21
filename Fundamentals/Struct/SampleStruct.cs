namespace Fundamentals.Struct;

/// <summary>
/// struct 示例
/// </summary>
public struct SampleStruct
{
    private const string TAG = "SampleStruct";

    public int X { get; set; }
    public string Y { get; set; }

    /// <summary>
    /// 在 C# 11 之前, 构造函数必须初始化所有实例字段
    /// </summary>
    public SampleStruct()
    {
        X = int.MinValue;
        Y = "Undefined";
    }

    public SampleStruct(int x, string y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// 覆盖 System.ValueType 的 ToString 方法
    /// </summary>
    public override string ToString()
    {
        return $"{TAG}: X = {X}, Y = {Y}";
    }
}
