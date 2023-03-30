namespace Fundamentals.Class.Member.Event;

public class Class1
{
    private const string TAG = "Class1";

    private int[] items;
    public event EventHandler? eventHandler;

    public Class1(int capacity)
    {
        items = new int[capacity];
    }

    public int this[int index]
    {
        get => items[index];
        set
        {
            items[index] = value;
            OnItemChanged(index, value);
        }
    }

    private void OnItemChanged(int index, int value)
    {
        eventHandler?.Invoke(this, EventArgs.Empty);
        eventHandler?.Invoke(this, new SampleEventArgs($"index = {index}, value = {value}"));
    }

    public class SampleEventArgs : EventArgs
    {
        public SampleEventArgs(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
