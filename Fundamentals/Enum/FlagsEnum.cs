namespace Fundamentals.Enum;

/// <summary>
/// 作为位标志的枚举类型
/// 若要指示枚举类型声明位字段, 必须对其应用特性 Flags
/// </summary>
[Flags]
public enum FlagsEnum
{
    // 0
    None = 0b_0000_0000,

    // 1
    A = 0b_0000_0001,

    // 2
    B = 0b_0000_0010,

    // 4
    C = 0b_0000_0100,

    // 0b_0000_0111 = 7
    ALL = A | B | C
}
