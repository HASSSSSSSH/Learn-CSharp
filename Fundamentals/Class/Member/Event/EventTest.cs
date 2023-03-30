using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Event;

[TestClass]
public class EventTest
{
    private const string TAG = "EventTest";

    [TestMethod]
    public void TestMethod1()
    {
        Class1 class1 = new Class1(3)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3,
        };

        EventHandler handler1 = new EventHandler(OnItemChanged);
        EventHandler handler2 = new EventHandler(new EventHandler(OnItemChanged));

        class1.eventHandler += handler1;
        class1.eventHandler += handler2;
        class1.eventHandler += OnItemChanged;
        class1[0] = 100;
        class1.eventHandler -= OnItemChanged;
        class1[1] = 1000;
        class1.eventHandler -= OnItemChanged;
        class1.eventHandler -= OnItemChanged;
        class1.eventHandler -= OnItemChanged;
        class1[2] = 10000;

        // 无法通过 "class1.eventHandler -= OnItemChanged" 删除 handler2
        class1.eventHandler -= handler2;

        class1[0] = 100000;
    }

    [TestMethod]
    public void TestMethod2()
    {
        Class1 class1 = new Class1(3)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3,
        };

        class1.eventHandler += new EventHandler(delegate(object? sender, EventArgs args)
        {
            Console.WriteLine(
                $"{TAG}: TestMethod2, sender?.GetType().ToString() = {sender?.GetType().ToString()}");

            if (args.GetType() == typeof(Class1.SampleEventArgs))
            {
                Console.WriteLine(
                    $"{TAG}: TestMethod2, ((Class1.SampleEventArgs)args).Text = \"{((Class1.SampleEventArgs)args).Text}\"");
            }
        });

        // 使用 Lambda 表达式来创建匿名函数
        class1.eventHandler += new EventHandler((sender, args) =>
        {
            Console.WriteLine(
                $"{TAG}: TestMethod2, sender?.GetType().ToString() = {sender?.GetType().ToString()}");

            if (args.GetType() == typeof(Class1.SampleEventArgs))
            {
                Console.WriteLine(
                    $"{TAG}: TestMethod2, ((Class1.SampleEventArgs)args).Text = \"{((Class1.SampleEventArgs)args).Text}\"");
            }
        });
        class1[0] = 100;
    }

    [TestMethod]
    public void TestMethod3()
    {
        Class2 class2 = new Class2(3)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3,
        };

        Class2.NewEventHandler handler = delegate(int index, int value)
        {
            Console.WriteLine($"{TAG}: TestMethod3, index = {index}, value = {value}");
            return "";
        };
        class2.newEventHandler += handler;
        class2.newEventHandler += handler;
        class2[0] = 100;
        class2.newEventHandler -= handler;
        class2[1] = 1000;
        class2.newEventHandler -= handler;
        class2.newEventHandler -= handler;
        class2.newEventHandler -= handler;
        class2[2] = 10000;
    }

    [TestMethod]
    public void TestMethod4()
    {
        Class3 class3 = new Class3(3)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3,
        };

        string handler(int index, int value)
        {
            Console.WriteLine($"{TAG}: TestMethod4, index = {index}, value = {value}");
            return "";
        }

        class3.HandlerList.Add(handler);
        class3.HandlerList.Add(handler);
        class3[0] = 100;
        class3.HandlerList.Clear();
        class3[1] = 1000;
    }

    private void OnItemChanged(object? sender, EventArgs args)
    {
        Console.WriteLine(
            $"{TAG}: OnItemChanged, sender?.GetType().ToString() = {sender?.GetType().ToString()}");
        Console.WriteLine(
            $"{TAG}: OnItemChanged, (args as Class1.SampleEventArgs)?.Text = \"{(args as Class1.SampleEventArgs)?.Text}\"");
    }
}
