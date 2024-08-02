namespace Fundamentals.TypeConversion;

public readonly struct Digit
{
    private readonly byte digit;

    public Digit(byte digit)
    {
        if (digit > 9)
        {
            throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be greater than nine.");
        }

        this.digit = digit;
    }

    public Digit(int digit)
    {
        if (digit is > 9 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(digit),
                "Digit cannot be greater than nine or less than zero.");
        }

        // 从 int 到 byte 的显式转换
        this.digit = (byte)digit;
    }

    /// <summary>
    /// 定义从 Digit 到 byte 的隐式转换
    /// </summary>
    public static implicit operator byte(Digit d) => d.digit;

    /// <summary>
    /// 定义从 Digit 到 int 的隐式转换
    /// </summary>
    public static implicit operator int(Digit d)
    {
        // 从 byte 到 int 的隐式转换
        return d.digit;
    }

    /// <summary>
    /// 定义从 byte 到 Digit 的显式转换, 可能会抛出异常
    /// </summary>
    public static explicit operator Digit(byte b) => new Digit(b);

    /// <summary>
    /// 定义从 int 到 Digit 的显式转换, 可能会抛出异常
    /// </summary>
    public static explicit operator Digit(int a) => new Digit(a);

    /// <summary>
    /// 以十进制输出
    /// </summary>
    public override string ToString() => $"{digit:D}";
}
