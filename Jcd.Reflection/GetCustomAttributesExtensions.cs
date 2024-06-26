#region

#region

using System;
using System.Linq;
using System.Reflection;

using Jcd.Validations;

#endregion

// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable S4018
namespace Jcd.Reflection;

#endregion

/// <summary>
/// Various extension methods that assist in getting custom attributes of a specified type.
/// </summary>
public static class GetCustomAttributesExtensions
{
   #region GetCustomAttributes Overloads

   /// <summary>
   /// Gets all attributes of a specified type on an enum value
   /// </summary>
   /// <param name="value">the enum value to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamref name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this Enum value, bool inherit = false)
      where TAttribute : Attribute
   {
      return value.GetCustomAttributes(typeof(TAttribute), inherit).OfType<TAttribute>().ToArray();
   }

   // ReSharper disable once ReturnTypeCanBeEnumerable.Global
   /// <summary>
   /// Gets all attributes of a specified type on an enum value
   /// </summary>
   /// <param name="value">the enum value to inspect</param>
   /// <param name="attributeType">The type of attributes to retrieve.</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <returns>An array of located <see cref="Attribute" /> instances. If none are found, an empty array is returned.</returns>
   public static Attribute[] GetCustomAttributes(this Enum value, Type attributeType, bool inherit = false)
   {
      Argument.IsNotNull(value, nameof(value));
      var type       = value.GetType();
      var memberInfo = type.GetMember(Enum.GetName(type, value) ?? value.ToString()).FirstOrDefault();
      var attributes = memberInfo?.GetCustomAttributes(attributeType, inherit).ToArray();

      if (attributes is null || !attributes.Any())
      {
         return Array.Empty<Attribute>();
      }

      return attributes.Select(x => (Attribute) x).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a FieldInfo
   /// </summary>
   /// <param name="fieldInfo">the field to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this FieldInfo fieldInfo, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(fieldInfo, nameof(fieldInfo));

      var attributes = fieldInfo.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a PropertyInfo
   /// </summary>
   /// <param name="propertyInfo">the property to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this PropertyInfo propertyInfo, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(propertyInfo, nameof(propertyInfo));
      var attributes = propertyInfo.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a MethodInfo
   /// </summary>
   /// <param name="methodInfo">the method to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this MethodInfo methodInfo, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(methodInfo, nameof(methodInfo));
      var attributes = methodInfo.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a type
   /// </summary>
   /// <param name="type">the type to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this Type type, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(type, nameof(type));
      var attributes = type.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a parameter
   /// </summary>
   /// <param name="paramInfo">the parameter to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this ParameterInfo paramInfo, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(paramInfo, nameof(paramInfo));
      var attributes = paramInfo.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a module
   /// </summary>
   /// <param name="module">the module to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this Module module, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(module, nameof(module));
      var attributes = module.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a TypeInfo
   /// </summary>
   /// <param name="typeInfo">the typeInfo to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this TypeInfo typeInfo, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(typeInfo, nameof(typeInfo));
      var attributes = typeInfo.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on an assembly
   /// </summary>
   /// <param name="assembly">the assembly to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this Assembly assembly, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(assembly, nameof(assembly));
      var attributes = assembly.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a parameter
   /// </summary>
   /// <param name="eventInfo">the eventINfo to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamre name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this EventInfo eventInfo, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(eventInfo, nameof(eventInfo));
      var attributes = eventInfo.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   /// <summary>
   /// Gets all attributes of a specified type on a MemberInfo
   /// </summary>
   /// <param name="memberInfo">the MemberInfo to inspect</param>
   /// <param name="inherit">inspect the inheritance hierarchy</param>
   /// <typeparam name="TAttribute">The type of attributes to retrieve</typeparam>
   /// <returns>
   /// An array of located <typeparamref name="TAttribute" /> instances. If none are found, an empty array is
   /// returned.
   /// </returns>
   public static TAttribute[] GetCustomAttributes<TAttribute>(this MemberInfo memberInfo, bool inherit = false)
      where TAttribute : Attribute
   {
      Argument.IsNotNull(memberInfo, nameof(memberInfo));
      var attributes = memberInfo.GetCustomAttributes(typeof(TAttribute), inherit);

      if (attributes.Length == 0)
      {
         return Array.Empty<TAttribute>();
      }

      return (
                from attribute in attributes
                select (TAttribute) attribute).ToArray();
   }

   #endregion
}