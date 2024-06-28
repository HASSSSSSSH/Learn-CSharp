namespace Fundamentals.Generic.Constraint;

/// <summary>
/// Class1 作为一个基类
/// </summary>
public class Class1
{
    public const string TAG = "Class1";

    public string Name { get; set; }

    /// <summary>
    /// 公共无参数构造函数
    /// </summary>
    public Class1()
    {
    }

    public virtual void Log(string msg)
    {
        Console.Out.WriteLine($"{TAG}-LOG-{Name}: {msg}");
    }
}
