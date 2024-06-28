namespace Fundamentals.Class.Member.Property;

/// <summary>
/// 属性的示例
/// </summary>
public class Class1
{
    private const string TAG = "Class1";

    // 支持字段
    private int i = 0;
    private string id;
    private string name;

    /// <summary>
    /// 声明一个静态的自动实现的属性并初始化该属性
    /// </summary>
    public static int Index { get; set; } = 1;

    /// <summary>
    /// 声明一个自动实现的读写属性
    /// </summary>
    public int A { get; set; }

    /// <summary>
    /// 声明一个只读属性
    /// </summary>
    public int B
    {
        get
        {
            // 每次读取递增 1
            return ++i;
        }
    }

    /// <summary>
    /// 声明一个只写属性
    /// </summary>
    public int Id
    {
        set
        {
            if (value > 0)
            {
                // 支持字段 id 是 string 类型
                id = $"id_{value}";
            }
        }
    }

    /// <summary>
    /// 声明一个带有 get 和 init 访问器的属性
    /// 其中 get 访问器设为 private
    /// </summary>
    public string Name
    {
        private get { return name; }
        init { name = $"name_{value}"; }
    }

    /// <summary>
    /// 使用表达式主体定义来实现只读属性
    /// 只读属性可以将 get 访问器作为 expression-bodied 成员实现
    /// </summary>
    public string UserId => $"{id}-{name}";

    public Class1(int id, string name)
    {
        // 调用 Id 的 set 访问器
        Id = id;

        // 调用 Name 的 init 访问器
        Name = name;
    }

    public void Test()
    {
        // 调用 Name 的私有 get 访问器
        Console.WriteLine($"{TAG}: Test(), Name = {Name}");
    }
}
