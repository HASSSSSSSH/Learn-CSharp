namespace Fundamentals.Class.Member.Constant;

/// <summary>
/// 声明常量的示例
/// </summary>
public static class Constants
{
    // 使用 const 关键字来声明常量字段
    public const string Tag = "Fundamentals.Class.Member.Constant.Constants";
    public const double Pi = 3.14159;

    // 除 string 以外的引用类型常量只能使用 null 值进行初始化
    public const object Obj = null;
    public const Dictionary<string, int>? Dictionary = null;

    // 常量在声明时必须初始化
    // public const int Index;

    // 在常量声明中不允许使用 static 修饰符
    // public static const int SpeedOfLight = 300000; // km/s
}
