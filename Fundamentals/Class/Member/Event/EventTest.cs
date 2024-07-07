using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Event;

[TestClass]
public class EventTest
{
    private const string TAG = "EventTest";

    /// <summary>
    /// 订阅事件和取消订阅
    /// 使用委托 EventHandler 进行处理
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        SampleClass1 instance = new SampleClass1(3)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3,
        };

        EventHandler handler1 = new EventHandler(OnItemChanged);
        EventHandler handler2 = new EventHandler(new EventHandler(OnItemChanged));

        // 订阅事件
        instance.eventHandler += handler1;
        instance.eventHandler += handler2;

        // 可以直接添加兼容的本地函数
        instance.eventHandler += OnItemChanged;

        // 触发事件
        instance[0] = 10;

        // 取消订阅
        instance.eventHandler -= OnItemChanged;

        // 触发事件
        instance[1] = 100;

        // 取消订阅
        instance.eventHandler -= OnItemChanged;
        instance.eventHandler -= OnItemChanged;
        instance.eventHandler -= OnItemChanged;

        // 触发事件
        instance[2] = 1000;

        // 无法通过 "class1.eventHandler -= OnItemChanged" 移除 handler2
        instance.eventHandler -= handler2;

        // 触发事件
        // 但是, 由于没有订阅者, 事件不会触发
        instance[0] = 10000;

        void OnItemChanged(object? sender, EventArgs args)
        {
            Console.WriteLine($"{TAG}: OnItemChanged, sender is {sender?.GetType()}");
            Console.WriteLine($"{TAG}: OnItemChanged, Message = \"{(args as SampleEventArgs)?.Message}\"");
        }
    }

    /// <summary>
    /// 通过匿名函数来订阅事件
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        SampleClass1 class1 = new SampleClass1(3)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3,
        };

        class1.eventHandler += delegate(object? sender, EventArgs args)
        {
            if (args.GetType() == typeof(SampleEventArgs))
            {
                Console.WriteLine($"{TAG}: Message = \"{((SampleEventArgs)args).Message}\"");
            }
        };

        // 使用 Lambda 表达式来创建匿名函数
        class1.eventHandler += (sender, args) =>
        {
            if (args.GetType() == typeof(SampleEventArgs))
            {
                Console.WriteLine($"{TAG}: Message = \"{((SampleEventArgs)args).Message}\"");
            }
        };

        // 触发事件
        class1[0] = 100;
    }

    /// <summary>
    /// 订阅事件和取消订阅
    /// 使用自定义委托 <see cref="SampleClass2.SampleEventHandler"/> 进行处理
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        SampleClass2 class2 = new SampleClass2(3)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3,
        };

        SampleClass2.SampleEventHandler handler = delegate(int index, int value)
        {
            Console.WriteLine($"{TAG}: callback, index = {index}, value = {value}");
            return "";
        };

        // 调用事件的 add 访问器
        class2.SampleEvent += handler;
        class2.SampleEvent += handler;

        // 触发事件
        class2[0] = 100;

        // 调用事件的 remove 访问器
        class2.SampleEvent -= handler;

        class2[1] = 1000;
        class2.SampleEvent -= handler;
        class2.SampleEvent -= handler;
        class2.SampleEvent -= handler;
        class2[2] = 10000;
    }

    /// <summary>
    /// 不通过使用事件来订阅事件和取消订阅
    /// 使用自定义委托 <see cref="SampleClass3.SampleEventHandler"/> 进行处理
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        SampleClass3 class3 = new SampleClass3(3)
        {
            [0] = 1,
            [1] = 2,
            [2] = 3,
        };

        string handler(int index, int value)
        {
            Console.WriteLine($"{TAG}: callback, index = {index}, value = {value}");
            return "success";
        }

        // 调用容器方法来订阅事件
        class3.HandlerList.Add(handler);
        class3.HandlerList.Add(handler);

        // 触发事件
        class3[0] = 10;

        // 调用容器方法来删除事件
        class3.HandlerList.Remove(handler);

        // 触发事件
        class3[0] = 100;

        // 清空容器
        class3.HandlerList.Clear();

        // 触发事件
        class3[1] = 1000;
    }
}
