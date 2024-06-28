namespace Fundamentals.Class.Member.Constant;

/// <summary>
/// readonly 关键字的示例
/// </summary>
public class SampleClass
{
    // 声明一个 readonly 值类型的实例字段
    public readonly int index = 1;

    // 声明一个 readonly 引用类型的实例字段并初始化
    public readonly DateTime dateTime = DateTime.Now;

    // 声明一个 readonly 引用类型的实例字段但不初始化
    public readonly Dictionary<string, int>? dictionary;

    public SampleClass()
    {
        // 赋值 dictionary
        dictionary = new Dictionary<string, int>();
    }

    public SampleClass(DateTime dateTime)
    {
        // 重新赋值 dateTime
        this.dateTime = dateTime;
    }
}
