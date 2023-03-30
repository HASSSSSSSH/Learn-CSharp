namespace Fundamentals.Generic;

public class Class3<T> : Class1<T, T>
{
    private const string TAG = "Class3<T>";

    public void Method1(T param)
    {
        base.Method1(param);
        base.X = param!;
        base.Y = param!;

        Console.Out.WriteLine($"{TAG}: Method1(T), typeof(T) = {typeof(T)}");
        Console.Out.WriteLine($"{TAG}: Method1(T), base.X.GetType() = {base.X.GetType()}");
        Console.Out.WriteLine($"{TAG}: Method1(T), base.Y.GetType() = {base.Y.GetType()}");
    }
}
