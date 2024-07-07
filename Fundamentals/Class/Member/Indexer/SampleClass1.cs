namespace Fundamentals.Class.Member.Indexer;

/// <summary>
/// 索引器示例
/// </summary>
public class SampleClass1
{
    private const string TAG = "SampleClass1";

    // 内部数组
    private int[] items;

    public SampleClass1(int capacity)
    {
        items = new int[capacity];
    }

    /// <summary>
    /// 索引器
    /// </summary>
    public int this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    /// <summary>
    /// 重载索引器
    /// 不根据整数值进行索引
    /// </summary>
    public string this[double index]
    {
        // 返回值类型是 string
        get => items[(int)Math.Round(index)].ToString();

        // value 的类型是 string
        set => items[(int)Math.Round(index)] = Convert.ToInt32(value);
    }

    /// <summary>
    /// 重载索引器
    /// 索引器可以有多个形参
    /// </summary>
    public int this[int index, int multiply]
    {
        get
        {
            Console.WriteLine($"{TAG}: call get accessor, index = {index}");
            return items[index];
        }
        set
        {
            Console.WriteLine($"{TAG}: call set accessor, multiply = {multiply}, value = {value}");
            items[index] = value * multiply;
        }
    }
}
