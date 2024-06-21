namespace Fundamentals.Enum;

/// <summary>
/// 可以使用无符号 16 位整数
/// </summary>
public enum ErrorCodeEnum : ushort
{
    // None = 0,
    Unknown = 1,
    ConnectionLost = 100,
    OutlierReading = 200
}
