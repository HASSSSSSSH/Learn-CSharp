namespace Fundamentals.Delegate;

public class Class2
{
    private const string TAG = "Class2";

    public delegate double Function(double x);

    public static Function? Functions { get; set; }

    public static void Apply(double x)
    {
        double? res = Functions?.Invoke(x);

        if (res != null)
        {
            Console.Out.WriteLine($"{TAG}: Apply(double), res = {res}");
        }
    }
}
