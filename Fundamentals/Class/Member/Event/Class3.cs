namespace Fundamentals.Class.Member.Event;

public class Class3
{
    private const string TAG = "Class3";

    private int[] items;

    public IList<NewEventHandler> HandlerList { get; } = new List<NewEventHandler>();

    public Class3(int capacity)
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
        foreach (var handler in HandlerList)
        {
            handler.Invoke(index, value);
        }
    }

    public delegate string NewEventHandler(int index, int value);
}
