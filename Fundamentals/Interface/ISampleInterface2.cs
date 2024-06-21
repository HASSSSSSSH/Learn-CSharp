namespace Fundamentals.Interface;

/// <summary>
/// ISampleInterface2 是带有默认实现的接口
/// </summary>
public interface ISampleInterface2
{
    // 可修改访问修饰符
    internal const string InterfaceName = nameof(ISampleInterface2);

    // 接口成员默认是 public
    static double GetPi()
    {
        return 3.141592653589793;
    }
}
