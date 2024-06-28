namespace Fundamentals.Generic.Constraint;

/// <summary>
/// 定义有着各种类型参数约束的方法
/// </summary>
public class SampleClass1
{
    private const string TAG = "SampleClass1";

    /// <summary>
    /// 类型参数 T 必须是不可为 null 的值类型
    /// </summary>
    public static void Method1<T>(T param) where T : struct
    {
        Console.Out.WriteLine($"{TAG}: Method1[T](T), param.GetType() = {param.GetType()}");
    }

    /// <summary>
    /// 类型参数 T 必须是引用类型
    /// </summary>
    public static void Method2<T>(T param) where T : class
    {
        Console.Out.WriteLine($"{TAG}: Method2[T](T), param.GetType() = {param.GetType()}");
    }

    /// <summary>
    /// 类型参数 T 必须是可为 null 或不可为 null 的引用类型
    /// </summary>
    public static void Method3<T>(T param) where T : class?
    {
        Console.Out.WriteLine($"{TAG}: Method3[T](T), (param == null) = {param == null}");
        Console.Out.WriteLine($"{TAG}: Method3[T](T), typeof(T) = {typeof(T)}");
    }

    /// <summary>
    /// 类型参数 T 必须是不可为 null 的类型
    /// </summary>
    public static void Method4<T>(T param) where T : notnull
    {
        if (param == null)
        {
            Console.Out.WriteLine($"{TAG}: Method4[T](T), param is null");
        }
        else
        {
            Console.Out.WriteLine($"{TAG}: Method4[T](T), param.GetType() = {param.GetType()}");
        }
    }

    /// <summary>
    /// 类型参数 T 必须是不可为 null 的非托管类型
    /// </summary>
    public static void Method5<T>(T param) where T : unmanaged
    {
        Console.Out.WriteLine($"{TAG}: Method5[T](T), param.GetType() = {param.GetType()}");
    }

    /// <summary>
    /// 类型参数 T 必须具有公共无参数构造函数
    /// </summary>
    public static void Method6<T>(T param) where T : new()
    {
        Console.Out.WriteLine($"{TAG}: Method6[T](T), param.GetType() = {param!.GetType()}");
    }

    /// <summary>
    /// 类型参数 T 必须是指定的基类或派生自指定的基类
    /// </summary>
    public static void Method7<T>(T param) where T : Class1
    {
        Console.Out.WriteLine($"{TAG}: Method7[T](T), (param is Class1) = {param is Class1}");

        // 可以直接使用约束类型的属性和方法
        param.Name = param.GetType().Name;
        param.Log("TEST!");
    }

    /// <summary>
    /// 类型参数 T 必须是指定的接口或实现指定的接口
    /// </summary>
    public static void Method8<T>(T param) where T : IEquatable<T>
    {
        T? instance = default;

        // 可以直接使用接口的方法
        Console.Out.WriteLine($"{TAG}: Method8[T](T), (param.Equals(instance)) = {param.Equals(instance)}");
    }

    /// <summary>
    /// 为 T 提供的类型参数必须是为 U 提供的参数或派生自为 U 提供的参数
    /// </summary>
    public static void Method9<T, U>(T param1, U param2) where T : U
    {
        Console.Out.WriteLine($"{TAG}: Method9[T, U](T, U), param1.GetType() = {param1!.GetType()}");
        Console.Out.WriteLine($"{TAG}: Method9[T, U](T, U), param2.GetType() = {param2!.GetType()}");
        Console.Out.WriteLine($"{TAG}: Method9[T, U](T, U), (param1 is U) = {param1 is U}");
    }
}
