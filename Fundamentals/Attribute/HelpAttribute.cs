#pragma warning disable CS8618
namespace Fundamentals.Attribute;

using System;

public class HelpAttribute : Attribute
{
    public HelpAttribute(string url)
    {
        this.Url = url;
    }

    public string Url { get; }

    public string Topic { get; set; }
}
