using System.Collections;

namespace Fundamentals.Iterator;

/// <summary>
/// 简单的集合类, 其实现了泛型接口 <see cref="IEnumerable{T}"/>
/// </summary>
public class DaysOfTheWeek : IEnumerable<DaysOfTheWeek.Days>
{
    public enum Days
    {
        Sun,
        Mon,
        Tue,
        Wed,
        Thu,
        Fri,
        Sat
    }

    /// <summary>
    /// 实现 <see cref="IEnumerable{T}.GetEnumerator()"/>
    /// </summary>
    public IEnumerator<Days> GetEnumerator()
    {
        int length = System.Enum.GetNames(typeof(Days)).Length;
        for (int index = 0; index < length; index++)
        {
            yield return (Days)index;
        }
    }

    /// <summary>
    /// 实现 <see cref="IEnumerable.GetEnumerator()"/>
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
