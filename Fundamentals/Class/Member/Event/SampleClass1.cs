namespace Fundamentals.Class.Member.Event;

/// <summary>
/// SampleClass1 充当事件发布者
/// </summary>
public class SampleClass1
{
    private int[] items;

    // 声明一个事件
    public event EventHandler? eventHandler;

    public SampleClass1(int capacity)
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

        // 当设置值时, 触发事件
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
        eventHandler?.Invoke(this, EventArgs.Empty);
        eventHandler?.Invoke(this, new SampleEventArgs($"Successfully set value: items[{index}] = {value}"));
    }
}
