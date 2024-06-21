namespace Fundamentals.Class;

/// <summary>
/// class 示例
/// </summary>
public class SampleClass
{
    private const string TAG = "SampleClass";

    public int X { get; set; }
    public string Y { get; set; }

    public SampleClass(int x, string y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{TAG}: X = {X}, Y = {Y}";
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        if (obj is SampleClass instance)
        {
            if (instance.X != this.X || instance.Y != this.Y)
            {
                return false;
            }
        }

        return true;
    }
}
