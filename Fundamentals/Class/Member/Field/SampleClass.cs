namespace Fundamentals.Class.Member.Field;

/// <summary>
/// 声明字段的示例
/// </summary>
public class SampleClass
{
    // 声明一个 static 字段
    public static int counter = 0;

    // 声明一个 private 实例字段
    private DateTime _date = Convert.ToDateTime("2077, 1, 1");

    // 声明一个 public 实例字段
    public string str = "test string ";

    public SampleClass()
    {
        // 字段会在构造函数被调用之前即刻初始化
        Console.WriteLine($"SampleClass: _date = {_date}");

        // 重新赋值 _date
        _date = Convert.ToDateTime("2077, 7, 7");

        Console.WriteLine($"SampleClass: _date = {_date}");
    }
}
