namespace Fundamentals.Class.Member.Event;

/// <summary>
/// SampleClass2 充当事件发布者
/// 其中声明了自定义委托 SampleEventHandler
/// </summary>
public class SampleClass2
{
    private const string TAG = "SampleClass2";

    private int[] items;

    // 声明一个委托
    public delegate string SampleEventHandler(int index, int value);

    // 声明类型为 SampleEventHandler 的属性
    private SampleEventHandler? EventHandlerValue { get; set; }

    /// <summary>
    /// 声明一个事件
    /// 此事件具有 add 和 remove 访问器
    /// </summary>
    public event SampleEventHandler? SampleEvent
    {
        add
        {
            Console.WriteLine($"{TAG}: SampleEvent.add");

            // 使用 += 运算符添加委托
            EventHandlerValue += value;
        }
        remove
        {
            Console.WriteLine($"{TAG}: SampleEvent.remove");

            // 使用 -= 运算符删除委托
            EventHandlerValue -= value;
        }
    }

    public SampleClass2(int capacity)
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
        EventHandlerValue?.Invoke(index, value);
    }
}
