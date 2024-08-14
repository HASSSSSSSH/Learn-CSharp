namespace Async;

public class AsyncTest
{
    // 操作的耗时
    private const int MILLISECONDS_DELAY = 2000;

    /// <summary>
    /// 测试 1
    /// 调用同步方法并等待结果
    /// </summary>
    public void TestMethod1()
    {
        ValuePair valuePair = StartTask3();
        MainClass.Log("All tasks finish");
        PrintObject(valuePair);
    }

    /// <summary>
    /// 测试 2
    /// 调用异步方法并等待结果
    /// </summary>
    public async Task TestMethod2()
    {
        ValuePair valuePair = await StartTask3Async();
        MainClass.Log("All tasks finish");
        PrintObject(valuePair);
    }

    /// <summary>
    /// 测试 3
    /// 调用异步方法并等待结果, 数个任务将会并发执行
    /// </summary>
    public async Task TestMethod3()
    {
        ValuePair valuePair = await StartTask3Async2();
        MainClass.Log("All tasks finish");
        PrintObject(valuePair);
    }

    /// <summary>
    /// 测试 4
    /// 调用异步方法, 数个任务将会并发执行, 使用 Task.WhenAny 方法等待结果
    /// </summary>
    public async Task TestMethod4()
    {
        ValuePair valuePair = await StartTask3Async3();
        MainClass.Log("All tasks finish");
        PrintObject(valuePair);
    }

    /// <summary>
    /// 测试 5
    /// 任务 Calculate 不需要等待结果, 并且需要较大的计算开销, 属于 CPU 绑定工作
    /// </summary>
    public void TestMethod5()
    {
        // 使用 Task.Run 方法将占用大量 CPU 的工作移到后台线程
        Task.Run(Calculate);

        // 不会被阻塞
        DoIndependentWork("TestMethod5()");
    }

    /// <summary>
    /// 同步方法, 执行 Task1
    /// </summary>
    private int StartTask1()
    {
        MainClass.Log("Task1 start");

        // 模拟耗时操作
        Task.Delay(MILLISECONDS_DELAY).Wait();

        MainClass.Log("Task1 end");
        return 1;
    }

    /// <summary>
    /// 异步方法, 执行 Task1
    /// </summary>
    private async Task<int> StartTask1Async()
    {
        MainClass.Log("async Task1 start");

        // 模拟耗时操作
        await Task.Delay(MILLISECONDS_DELAY);

        MainClass.Log("async Task1 end");
        return 1;
    }

    /// <summary>
    /// 同步方法, 执行 Task2
    /// </summary>
    private string StartTask2()
    {
        MainClass.Log("Task2 start");

        // 模拟耗时操作
        Task.Delay(MILLISECONDS_DELAY).Wait();

        MainClass.Log("Task2 end");
        return "new string";
    }

    /// <summary>
    /// 异步方法, 执行 Task2
    /// </summary>
    private async Task<string> StartTask2Async()
    {
        MainClass.Log("async Task2 start");

        // 模拟耗时操作
        await Task.Delay(MILLISECONDS_DELAY);

        MainClass.Log("async Task2 end");
        return "new string";
    }

    /// <summary>
    /// 同步方法, 依次执行 Task1 和 Task2
    /// </summary>
    private ValuePair StartTask3()
    {
        MainClass.Log("Task3 start");

        // 同步执行 Task1 和 Task2
        int i = StartTask1();
        string s = StartTask2();

        // 被阻塞, 需要等待 Task1 和 Task2 执行完毕
        DoIndependentWork("StartTask3()");

        ValuePair valuePair = new ValuePair
        {
            I = i,
            Str = s
        };
        MainClass.Log("Task3 end");
        return valuePair;
    }

    /// <summary>
    /// 异步方法, 但仍是依次执行 Task1 和 Task2
    /// </summary>
    private async Task<ValuePair> StartTask3Async()
    {
        MainClass.Log("StartTask3Async() start");

        // 执行 Task1 并等待结果
        int i = await StartTask1Async();

        // 执行 Task2 并等待结果
        // 被阻塞, 需要在 Task1 返回结果后才能执行 Task2
        string s = await StartTask2Async();

        // 被阻塞, 需要等待 Task1 和 Task2 执行完毕
        DoIndependentWork("StartTask3Async()");

        ValuePair valuePair = new ValuePair
        {
            I = i,
            Str = s
        };
        MainClass.Log("StartTask3Async() end");
        return valuePair;
    }

    /// <summary>
    /// 异步方法, 并发执行 Task1 和 Task2
    /// </summary>
    private async Task<ValuePair> StartTask3Async2()
    {
        MainClass.Log("StartTask3Async2() start");

        // 并发执行 Task1 和 Task2
        Task<int> task1 = StartTask1Async();
        Task<string> task2 = StartTask2Async();

        // 不被阻塞
        DoIndependentWork("StartTask3Async2()");

        // 等待 Task1 和 Task2 的结果
        int i = await task1;
        string s = await task2;

        // 被阻塞, 需要等待 Task1 和 Task2 执行完毕
        DoIndependentWork("StartTask3Async2()");

        ValuePair valuePair = new ValuePair
        {
            I = i,
            Str = s
        };
        MainClass.Log("StartTask3Async2() end");
        return valuePair;
    }

    /// <summary>
    /// 异步方法, 并发执行 Task1 和 Task2, 并且使用 Task.WhenAny 方法等待任一任务完成
    /// </summary>
    private async Task<ValuePair> StartTask3Async3()
    {
        MainClass.Log("StartTask3Async3() start");

        // 并发执行 Task1 和 Task2
        var task1 = StartTask1Async();
        var task2 = StartTask2Async();
        var taskList = new List<Task> { task1, task2 };

        // 不被阻塞
        DoIndependentWork("StartTask3Async3()");

        // 等待结果
        ValuePair valuePair = new ValuePair();
        while (taskList.Count > 0)
        {
            // 等待 Task.WhenAny 方法返回一个 Task
            Task finishedTask = await Task.WhenAny(taskList);

            // 对返回的 Task 进行 await, 以检索其结果或者确保抛出异常
            if (finishedTask == task1)
            {
                valuePair.I = await (Task<int>)finishedTask;
                MainClass.Log("get result from Task1");
            }
            else if (finishedTask == task2)
            {
                valuePair.Str = await (Task<string>)finishedTask;
                MainClass.Log("get result from Task2");
            }

            taskList.Remove(finishedTask);
        }

        // 被阻塞, 需要等待 Task1 和 Task2 执行完毕
        DoIndependentWork("StartTask3Async3()");

        MainClass.Log("StartTask3Async3() end");
        return valuePair;
    }

    /// <summary>
    /// 有着较大开销的方法
    /// </summary>
    private void Calculate()
    {
        MainClass.Log("Start Calculate");

        int raise = int.MaxValue >> 3;
        double sum = 0;
        for (int i = 2; i < raise; i++)
        {
            sum += Math.Log2(i);
        }

        MainClass.Log($"Finish Calculate, sum = {sum}");
    }

    /// <summary>
    /// 此方法表示一项独立的工作
    /// </summary>
    private void DoIndependentWork(string source)
    {
        MainClass.Log($"\"{source}\" doing independent work...");
    }

    /// <summary>
    /// 用于输出 ValuePair 的信息
    /// </summary>
    private void PrintObject(object o)
    {
        MainClass.Log($"Print object: {o.ToString()}");
    }

    /// <summary>
    /// 用于保存 Task1 和 Task2 的结果
    /// </summary>
    private class ValuePair
    {
        public int I { get; set; } = 0;
        public string Str { get; set; } = "";

        public override string ToString()
        {
            return $"ValuePair: I = {I}, Str = {Str}";
        }
    }
}
