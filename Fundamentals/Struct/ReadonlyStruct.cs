namespace Fundamentals.Struct;

/// <summary>
/// readonly 结构
/// </summary>
public readonly struct ReadonlyStruct
{
    private const string TAG = "ReadonlyStruct";

    private readonly string y;

    public int X { get; init; }

    public string Y
    {
        get { return y; }
        init { y = string.Concat(value, value); }
    }

    public ReadonlyStruct(int x, string y) : this()
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{TAG}: X = {X}, Y = {Y}";
    }
}
