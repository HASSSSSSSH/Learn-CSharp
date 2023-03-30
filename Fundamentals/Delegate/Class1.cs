using System.Text;

namespace Fundamentals.Delegate;

public class Class1
{
    private const string TAG = "Class1";

    public delegate double Function(double x);

    public static string Apply(double x, Function f)
    {
        StringBuilder builder = new StringBuilder($"{TAG}: Apply(double, Function), result = ");
        builder.Append($"{f(x)}");
        return builder.ToString();
    }
}
