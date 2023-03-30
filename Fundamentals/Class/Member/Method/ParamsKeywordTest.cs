using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Class.Member.Method;

[TestClass]
public class ParamsKeywordTest
{
    private const string TAG = "ParamsKeywordTest";

    /// <summary>
    /// 在调用包含形参数组的方法时, 可以该形参数组的元素类型的任意数量实参, 数组实例会自动创建
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        int a = 0, b = 1, c = 2;
        Log($"{TAG}: TestMethod1, a = {0}, b = {1}, c = {2}", a, b, c);
    }

    private void Log(string fmt, params object[] args)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append($"{TAG}: Log, args = [ ");
        foreach (var i in args)
        {
            builder.Append($"{i}, ");
        }

        builder.Append(']');
        Console.WriteLine(builder.ToString());
        Console.WriteLine(fmt, args);
    }
}
