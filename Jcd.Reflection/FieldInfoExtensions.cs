#region

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ObjectAllocation.Possible

#endregion

namespace Jcd.Reflection;

/// <summary>
/// Extension methods to aid in reflecting on fields.
/// </summary>
public static class FieldInfoExtensions
{
   /// <summary>
   /// Enumerate the FieldInfo entries for a given type 
   /// </summary>
   /// <param name="type">The data type to reflect on</param>
   /// <param name="flags">The BindingFlags</param>
   /// <param name="skip">a predicate for skipping certain entries (e.g. System...)</param>
   /// <returns>An enumerable across FieldInfo s</returns>
   [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
   public static IEnumerable<FieldInfo> EnumerateFields(
      this Type             type
    , BindingFlags?         flags = null
    , Func<FieldInfo, bool> skip  = null
   )
   {
      IEnumerable<FieldInfo> props = flags.HasValue ? type.GetFields(flags.Value) : type.GetFields();

      foreach (var fi in props)
      {
         if (fi.DeclaringType?.FullName != null && fi.DeclaringType.FullName.StartsWith("System.")) continue;
         var skipped = skip?.Invoke(fi);

         if (skipped.HasValue && skipped.Value) continue;

         yield return fi;
      }
   }

   /// <summary>
   /// Enumerate the FieldInfo entries for a given instance 
   /// </summary>
   /// <param name="self">The data instance to reflect on</param>
   /// <param name="flags">The BindingFlags</param>
   /// <param name="skip">a predicate for skipping certain entries (e.g. System...)</param>
   /// <returns>An enumerable across FieldInfo s</returns>
   public static IEnumerable<FieldInfo> EnumerateFields(
      this object           self
    , BindingFlags?         flags = null
    , Func<FieldInfo, bool> skip  = null
   )
   {
      return self.IsScalar() ? null : self.GetType().EnumerateFields(flags, skip);
   }
}