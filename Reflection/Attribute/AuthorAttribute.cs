namespace Reflection.Attribute;

using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
    private string Name;

    public double Version;

    public AuthorAttribute(string name)
    {
        Name = name;
        Version = 1.0;
    }

    public string GetName() => Name;
}
