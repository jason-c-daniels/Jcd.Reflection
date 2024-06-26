#region

using System;

#endregion

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Jcd.Reflection.Tests._TestHelpers;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class MyDescriptionAttribute : Attribute
{
   public MyDescriptionAttribute(string description) { Description = description; }

   public string Description { get; set; }
}