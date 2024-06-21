namespace Fundamentals.Delegate;

/// <summary>
/// 用于测试多播委托的类
/// </summary>
public class Class2
{
    private const string TAG = "Class2";

    // 声明一个委托
    public delegate int PerformCalculation(int x, int y);

    // 声明一个自动实现的委托属性
    public static PerformCalculation? Functions { get; set; }

    // 静态方法, 用于使用委托属性 Functions
    public static void Apply(int x, int y)
    {
        double? result = Functions?.Invoke(x, y);

        if (result != null)
        {
            Console.Out.WriteLine($"{TAG}: Apply(int, int), result = {result}");
        }
    }
}
