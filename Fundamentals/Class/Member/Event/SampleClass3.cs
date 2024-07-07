namespace Fundamentals.Class.Member.Event;

/// <summary>
/// SampleClass3 充当事件发布者
/// 不声明事件也可以实现事件的发送, 本示例中使用 List<T> 容器来存储委托
/// </summary>
public class SampleClass3
{
    private int[] items;

    // 声明一个委托
    public delegate string SampleEventHandler(int index, int value);

    // 声明 IList<T> 属性, 用于存储 SampleEventHandler 委托
    public IList<SampleEventHandler> HandlerList { get; } = new List<SampleEventHandler>();

    public SampleClass3(int capacity)
    {
        items = new int[capacity];
    }

    /// <summary>
    /// 一个简单的索引器
    /// 用于触发事件
    /// </summary>
    public int this[int index]
    {
        get => items[index];
        set
        {
            items[index] = value;
            OnItemChanged(index, value);
        }
    }

    /// <summary>
    /// 发送事件
    /// </summary>
    private void OnItemChanged(int index, int value)
    {
        foreach (var handler in HandlerList)
        {
            handler.Invoke(index, value);
        }
    }
}
