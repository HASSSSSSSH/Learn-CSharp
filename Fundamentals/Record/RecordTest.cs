using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Record;

[TestClass]
public class RecordTest
{
    private const string TAG = "RecordTest";

    /// <summary>
    /// 使用位置参数来声明和实例化记录
    /// 记录可以输出类型名称和属性值
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        SampleRecord1 record = new("Nancy", "Lio");
        Console.WriteLine($"{TAG}: record = \"{record.ToString()}\"");

        // record 类型在实例化后不能更改该对象的任何属性或字段值
        // record.FirstName = "Bill";
    }

    /// <summary>
    /// 使用记录来创建依赖于值相等性的数据模型
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        var phoneNumbers = new string[2];
        SampleRecord2 record1 = new("Nancy", "Lio", phoneNumbers);
        SampleRecord2 record2 = new("Nancy", "Lio", phoneNumbers);
        SampleRecord2 record3 = new("Nancy", "Lee", phoneNumbers);
        SampleRecord2 record4 = new("Nancy", "Lio", new string[1]);

        // 比较值相等性
        Console.WriteLine($"{TAG}: (record1 == record2) = {record1 == record2}");
        Console.WriteLine($"{TAG}: (record1 == record3) = {record1 == record3}");
        Console.WriteLine($"{TAG}: (record1 == record4) = {record1 == record4}");

        record1.PhoneNumbers[0] = "000-1234";
        record2.PhoneNumbers[0] = "111-1234";
        Console.WriteLine($"{TAG}: (record1 == record2) = {record1 == record2}");

        // 比较引用相等性
        Console.WriteLine($"{TAG}: ReferenceEquals(record1, record2) = {ReferenceEquals(record1, record2)}");
    }
}
