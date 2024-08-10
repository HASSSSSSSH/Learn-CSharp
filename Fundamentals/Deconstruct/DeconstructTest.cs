using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fundamentals.Deconstruct;

[TestClass]
public class DeconstructTest
{
    private const string TAG = "DeconstructTest";

    /// <summary>
    /// 析构元组
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        {
            // 在括号内显式声明每个字段的类型
            (string cityName, double area, int population, string country) = GetCityData();
            Console.WriteLine(
                $"{TAG}: cityName = {cityName}, area = {area}, population = {population}, country = {country}");
        }

        {
            // 使用 var 关键字推断类型
            var (cityName, area, population, country) = GetCityData();
            Console.WriteLine(
                $"{TAG}: cityName = {cityName}, area = {area}, population = {population}, country = {country}");
        }

        {
            // 使用弃元
            var (cityName, _, _, country) = GetCityData();
            Console.WriteLine($"{TAG}: cityName = {cityName}, country = {country}");
        }

        (string, double, int, string) GetCityData() => ("Paris", 105.4, 2102650, "France");
    }

    /// <summary>
    /// 析构用户定义类型
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
        {
            var (firstName, lastName) = GetPersonData();
            Console.WriteLine($"{TAG}: firstName = {firstName}, lastName = {lastName}");
        }

        {
            // 可以使用弃元
            var (id, firstName, lastName, _, country) = GetPersonData();
            Console.WriteLine($"{TAG}: id = {id}, firstName = {firstName}, lastName = {lastName}, country = {country}");
        }

        Person GetPersonData() => new Person(1768, "Jean-Baptiste",
            "Joseph Fourier", "Paris", "France");
    }

    /// <summary>
    /// 使用支持析构的系统类型
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        var starMap = new Dictionary<string, int>
        {
            ["https://github.com/dotnet/docs"] = 4_200,
            ["https://github.com/dotnet/runtime"] = 14_700,
            ["https://github.com/dotnet/installer"] = 1_300,
            ["https://github.com/dotnet/roslyn"] = 18_800,
            ["https://github.com/dotnet/aspnetcore"] = 34_900
        };

        foreach (var (repo, starCount) in starMap)
        {
            Console.WriteLine($"{repo} : {starCount:N0}");
        }
    }

    /// <summary>
    /// 析构 Nullable<T> 类型
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
        DateTime? dateTime = default;
        (bool hasValue, DateTime value) = dateTime;
        Console.WriteLine($"{{ HasValue = {hasValue}, Value = {value} }}");

        dateTime = null;
        (hasValue, value) = dateTime;
        Console.WriteLine($"{{ HasValue = {hasValue}, Value = {value} }}");

        dateTime = DateTime.Now;
        (hasValue, value) = dateTime;
        Console.WriteLine($"{{ HasValue = {hasValue}, Value = {value} }}");
    }
}
