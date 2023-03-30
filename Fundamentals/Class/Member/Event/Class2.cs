namespace Fundamentals.Class.Member.Event;

public class Class2
{
    private const string TAG = "Class2";

    private int[] items;

    private NewEventHandler? EventHandlerValue { get; set; }

    public event NewEventHandler? newEventHandler
    {
        add
        {
            Console.WriteLine($"{TAG}: newEventHandler.add");
            EventHandlerValue += value;
        }
        remove
        {
            Console.WriteLine($"{TAG}: newEventHandler.remove");
            EventHandlerValue -= value;
        }
    }

    public Class2(int capacity)
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
        EventHandlerValue?.Invoke(index, value);
    }

    public delegate string NewEventHandler(int index, int value);
}
