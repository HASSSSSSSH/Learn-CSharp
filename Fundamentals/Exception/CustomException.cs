namespace Fundamentals.Exception;

public class CustomException : System.Exception
{
    public CustomException(string? message) : base(message)
    {
    }
}
