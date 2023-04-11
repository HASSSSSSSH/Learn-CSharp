namespace Reflection.Generic;

public class GenericClass1<A, B>
{
    private const string TAG = "Generic.GenericClass1<A, B>";

    private A x;
    public A X { get; set; }
    private B? y;
    public B? Y { get; set; }

    public GenericClass1()
    {
    }

    public GenericClass1(A x, B y)
    {
        this.x = x;
        X = x;
        this.y = y;
        Y = y;
    }

    public virtual void Method1<T>(T param)
    {
        Console.Out.WriteLine($"{TAG}: Method1<T>(T), typeof(T) = {typeof(T)}");
    }
}
