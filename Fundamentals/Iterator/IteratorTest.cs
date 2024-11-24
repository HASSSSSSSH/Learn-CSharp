using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Iterator;

[TestClass]
public class IteratorTest
{
    private const string TAG = "IteratorTest";

    /// <summary>
    /// 简单的迭代器
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        foreach (int number in SomeNumbers())
        {
            Console.WriteLine($"{TAG}: {number}");
        }

        // 一个简单的迭代器方法
        IEnumerable SomeNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }

    /// <summary>
    /// 使用 IEnumerator 进行迭代
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        // 调用迭代器方法不会立即执行迭代
        IEnumerable enumerable = SomeNumbers();

        IEnumerator enumerator = enumerable.GetEnumerator();

        Console.WriteLine($"{TAG}: Start iterating");
        while (enumerator.MoveNext())
        {
            int number = (int)enumerator.Current;
            Console.WriteLine($"{TAG}: {number}");
        }

        // 对迭代器方法返回的迭代器调用 Reset 会引发 NotSupportedException
        // enumerator.Reset();

        IEnumerable SomeNumbers()
        {
            Console.WriteLine($"{TAG}: Iterator start");
            yield return 1;
            yield return 2;
            yield return 3;
            Console.WriteLine($"{TAG}: Iterator end");
        }
    }

    /// <summary>
    /// 使用集合类
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        DaysOfTheWeek days = new DaysOfTheWeek();

        foreach (DaysOfTheWeek.Days day in days)
        {
            Console.WriteLine($"{TAG}: {day}");
        }
    }
}
