﻿using System;
using System.Reflection;

namespace Jcd.Reflection;

/// <summary>
/// The settings indicating "how" to enumerate. (i.e. BindingFlags and a predicate for skipping members)
/// </summary>
public class FieldOrPropertyInfoFilter
{
   /// <summary>
   /// The BindingFlags for the member lookup.
   /// </summary>
   public BindingFlags? Flags { get; init; } = null;

   // ReSharper disable once UnassignedField.Global
   /// <summary>
   /// A predicate for skipping certain members.
   /// </summary>
   public Func<FieldOrPropertyInfo, bool> Skip { get; init; } = null;
}