namespace Fundamentals.Exception;

/// <summary>
/// 创建自定义异常
/// </summary>
public class CustomException : System.Exception
{
    public CustomException(string message) : base(message)
    {
    }
}
