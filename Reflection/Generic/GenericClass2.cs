namespace Reflection.Generic;

public class GenericClass2 : GenericClass1<int, string>
{
    private const string TAG = "Generic.GenericClass2";

    public override void Method1<T>(T param)
    {
        base.X = 10;
        base.Y = "100";

        Console.Out.WriteLine($"{TAG}: Method1<T>(T), typeof(T) = {typeof(T)}");
        Console.Out.WriteLine($"{TAG}: Method1<T>(T), base.X.GetType() = {base.X.GetType()}");
        Console.Out.WriteLine($"{TAG}: Method1<T>(T), base.Y.GetType() = {base.Y.GetType()}");
    }
}
