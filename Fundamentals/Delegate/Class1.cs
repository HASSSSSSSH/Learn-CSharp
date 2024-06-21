using System.Text;

namespace Fundamentals.Delegate;

/// <summary>
/// 此类带有一个 delegate 示例
/// </summary>
public class Class1
{
    private const string TAG = "Class1";

    private double factor;

    // 声明一个委托
    public delegate double Function(double x);

    public Class1(double factor)
    {
        this.factor = factor;
    }

    // 一个与 Function 兼容的实例方法
    public double SampleFunction(double x)
    {
        return x * factor;
    }

    // 一个与 Function 兼容的静态方法
    public static double Sqrt(double x)
    {
        return x * x;
    }

    // 应用 Function
    public static string Apply(double x, Function f)
    {
        StringBuilder builder = new StringBuilder($"{TAG}: Apply(double, Function), result = ");
        builder.Append($"{f(x)}");
        return builder.ToString();
    }
}
