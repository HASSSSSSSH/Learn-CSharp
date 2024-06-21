namespace Fundamentals.Interface;

/// <summary>
/// ISampleInterface6 继承自 <see cref="ISampleInterface3", cref="ISampleInterface4"/>
/// </summary>
public interface ISampleInterface6 : ISampleInterface3, ISampleInterface4
{
    /// <summary>
    /// 一个接口属性
    /// </summary>
    string Name { get; set; }

    void Method1(string tag);
}
