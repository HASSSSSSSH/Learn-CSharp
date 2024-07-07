namespace Fundamentals.Class.Member.Event;

public class SampleEventArgs : EventArgs
{
    public string Message { get; init; }

    public SampleEventArgs(string msg)
    {
        Message = msg;
    }
}
