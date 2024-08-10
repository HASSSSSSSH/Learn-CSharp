#pragma warning disable CS8618
namespace Fundamentals.Attribute;

using System;

/// <summary>
/// 自定义特性
/// </summary>

// 应用 AttributeUsageAttribute, 其中 validOn 是必选参数
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]

// 自定义特性可以应用自身
[HelpAttribute("https://learn.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes",
    Topic = "custom attribute")]
public class HelpAttribute : Attribute
{
    /// <summary>
    /// Url 是必选参数
    /// </summary>
    public string Url { get; init; }

    /// <summary>
    /// Topic 是可选参数
    /// </summary>
    public string Topic { get; set; }

    /// <summary>
    /// 特性是通过构造函数初始化的
    /// 此特性具有一个必选参数
    /// </summary>
    public HelpAttribute(string url)
    {
        this.Url = url;
    }
}
