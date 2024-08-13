namespace Fundamentals.Reflection;

/// <summary>
/// 用于反射的示例类
/// </summary>
public class SampleClass
{
    // 私有常量
    private const string TAG = "SampleClass";

    // readonly 引用类型
    public readonly DateTime dateTime = DateTime.Now;

    // static 字段
    public static int counter = 0;

    // 私有实例字段
    private string str = "test string";

    // 事件
    public event EventHandler? eventHandler;

    // 自动实现的读写属性
    public int A { get; set; } = 0;

    // 自动实现的读写属性
    public string B { get; set; } = "";

    // 私有构造函数
    private SampleClass()
    {
        Console.WriteLine($"{TAG}: SampleClass()");
    }

    // 构造函数
    public SampleClass(int a)
    {
        Console.WriteLine($"{TAG}: SampleClass(int)");
        A = a;
    }

    // 构造函数
    public SampleClass(string b)
    {
        Console.WriteLine($"{TAG}: SampleClass(string)");
        B = b;
    }

    // 构造函数
    public SampleClass(int a, string b)
    {
        Console.WriteLine($"{TAG}: SampleClass(int, string)");
        A = a;
        B = b;
    }

    // 私有方法
    private int Method1()
    {
        Console.WriteLine($"{TAG}: Method1()");
        return 1;
    }

    // 方法
    public string Method2(string s)
    {
        Console.WriteLine($"{TAG}: Method2(string)");
        return s;
    }

    // 静态方法
    public static void Method3(int x, int y, out int addition, out int subtraction)
    {
        Console.WriteLine($"{TAG}: Method3(int, int, out int, out int)");
        addition = x + y;
        subtraction = x - y;
    }

    /// <summary>
    /// 引发事件
    /// </summary>
    public void InvokeEventHandler()
    {
        eventHandler?.Invoke(this, EventArgs.Empty);
    }
}
