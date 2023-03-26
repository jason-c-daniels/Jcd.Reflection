#region

using System;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

#endregion

namespace Jcd.Reflection.Tests._TestHelpers;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class MyDescriptionAttribute : Attribute
{
    public MyDescriptionAttribute(string description)
    {
        Description = description;
    }

    public string Description { get; set; }
}