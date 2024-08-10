namespace Fundamentals.Deconstruct;

/// <summary>
/// 支持析构的用户定义类型的示例
/// </summary>
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public Person(int id, string firstName, string lastName, string city, string country)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        City = city;
        Country = country;
    }

    /// <summary>
    /// 通过实现一个或多个 Deconstruct 方法来析构该类型的实例
    /// </summary>
    public void Deconstruct(out string firstName, out string lastName)
    {
        firstName = FirstName;
        lastName = LastName;
    }

    // 在重载解析过程中, 无法区分具有相同数量参数的 Deconstruct 方法
    // public void Deconstruct(out int id, out string firstName)
    // {
    //     id = Id;
    //     firstName = FirstName;
    // }

    // 不能声明签名相同的 Deconstruct 方法
    // public void Deconstruct(out string city, out string country)
    // {
    //     city = City;
    //     country = Country;
    // }

    /// <summary>
    /// 可以重载 Deconstruct 方法
    /// </summary>
    public void Deconstruct(out int id, out string firstName, out string lastName, out string city, out string country)
    {
        id = Id;
        firstName = FirstName;
        lastName = LastName;
        city = City;
        country = Country;
    }
}
