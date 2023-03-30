namespace Fundamentals.Class.Member.Property;

public class Class1
{
    private const string TAG = "Class1";

    private static int i = 1;
    private int a;
    private int b;
    private int c;

    public static int I { get; set; }

    public int A { get; set; }

    public int B
    {
        get
        {
            Console.WriteLine($"{TAG}: Class1.B.get, b = {b}");
            return ++b;
        }
    }

    public int C
    {
        set
        {
            Console.WriteLine($"{TAG}: Class1.C.set, value = {value}");
            c = --value;
        }
    }

    /// <summary>
    /// 一元后缀 ! 运算符是 null 包容运算符, 用于取消表达式的所有可为 null 警告
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving
    /// </summary>
    public object D { get; set; } = null!;

    public Class1(int a, int b, int c)
    {
        this.A = a;
        // this.B = b;
        this.C = c;
    }

    public void Method1()
    {
        Console.WriteLine($"{TAG}: Method1(), I = {I}, this.A = {this.A}, this.B = {this.B}, c = {c}");
        // Console.WriteLine($"{TAG}: Method1(), this.D.GetType().ToString() = {this.D.GetType().ToString()}");
        Console.WriteLine($"{TAG}: Method1(), this.D = {this.D}");
    }
}
