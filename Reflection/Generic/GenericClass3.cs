namespace Reflection.Generic;

public class GenericClass3<T> : GenericClass1<int, T>
{
    private const string TAG = "Generic.GenericClass3<T>";

    public void Method1(T param)
    {
        Console.Out.WriteLine($"{TAG}: Method1, typeof(T) = {typeof(T)}");
    }
}
