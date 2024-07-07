using System.Numerics;
using System.Text;

namespace Fundamentals.Class.Member.Method;

/// <summary>
/// 方法的示例
/// </summary>
public class SampleClass1
{
    private const string TAG = "SampleClass1";

    /// <summary>
    /// 声明一个不需要参数的静态方法
    /// </summary>
    public static string GetClassTag()
    {
        return TAG;
    }

    /// <summary>
    /// 声明一个按值传递参数的方法并修改参数
    /// 在两个方法参数中, int 属于值类型, ICollection 属于引用类型
    /// </summary>
    public void Method1(int i, ICollection<string> collection)
    {
        // 修改值类型的数据
        ++i;

        // 修改引用类型所引用的对象的状态
        collection.Add("SampleClass1.Method1");
    }

    /// <summary>
    /// 声明一个按值传递参数的方法并令参数引用其他对象
    /// 在两个方法参数中, int 属于值类型, ICollection 属于引用类型
    /// </summary>
    public void Method2(int i, ICollection<string> collection)
    {
        // 令参数引用其他对象
        i = int.MaxValue;
        collection = new LinkedList<string>();
        collection.Add("SampleClass1.Method2");
    }

    /// <summary>
    /// 使用 ref 参数修饰符, 声明一个按引用传递参数的方法并修改参数
    /// 在两个方法参数中, int 属于值类型, ICollection 属于引用类型
    /// </summary>
    public void Method3(ref int i, ref ICollection<string> collection)
    {
        // 修改值类型的数据
        ++i;

        // 修改引用类型所引用的对象的状态
        collection.Add("SampleClass1.Method3");
    }

    /// <summary>
    /// 使用 ref 参数修饰符, 声明一个按引用传递参数的方法并令参数引用其他对象
    /// 在两个方法参数中, int 属于值类型, ICollection 属于引用类型
    /// </summary>
    public void Method4(ref int i, ref ICollection<string> collection)
    {
        // 令参数引用其他对象
        i = int.MaxValue;
        collection = new LinkedList<string>();
        collection.Add("SampleClass1.Method4");
    }

    /// <summary>
    /// 声明一个方法, 其中的两个参数带有 out 参数修饰符
    /// </summary>
    public void Method5(int x, int y, out int addition, out int subtraction)
    {
        addition = x + y;
        subtraction = x - y;
    }

    /// <summary>
    /// 声明一个方法, 方法的参数带有 in 修饰符
    /// 方法声明 in 参数可以指定参数按引用安全传递, 因为方法不修改该参数的状态
    /// </summary>
    public void Method6(in Vector4 vector4)
    {
        // 方法拿到的是参数的只读引用, 不允许修改参数的状态
        // vector4 = new Vector4(1f, 1f, 1f, 1f);
        // vector4.X = vector4.Y + vector4.W + vector4.Z;

        Console.WriteLine($"{TAG}: vector4.ToString() = {vector4.ToString()}");
    }

    /// <summary>
    /// 声明一个方法, 方法的最后一个参数带有 params 修饰符
    /// </summary>
    public void Method7(string format, params object[] args)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append($"{TAG}: args = [");
        foreach (var obj in args)
        {
            builder.Append($"{obj.ToString()}, ");
        }

        builder.Append(']');
        Console.WriteLine(builder.ToString());
        Console.WriteLine(format, args);
    }

    /// <summary>
    /// 使用表达式主体定义声明方法
    /// </summary>
    public void Print(string msg) => Console.WriteLine($"{TAG}: {msg}");

    /// <summary>
    /// 使用表达式主体定义声明方法
    /// </summary>
    public string GetTag() => TAG;
}
