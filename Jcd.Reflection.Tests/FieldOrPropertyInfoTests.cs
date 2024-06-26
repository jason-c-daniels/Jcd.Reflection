﻿#region

using System;
using System.Linq;
using System.Reflection;

using Jcd.Reflection.Tests.Fakes;

using Moq;

using Xunit;

// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable InconsistentNaming
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident

#endregion

namespace Jcd.Reflection.Tests;

public class FieldOrPropertyInfoTests
{
   /// <summary>
   /// Validate that Constructor Throws ArgumentNullException When memberInfoIsNull.
   /// </summary>
   [Fact]
   public void Constructor_WhenMemberInfoIsNull_ThrowsArgumentNullException()
   {
      Assert.Throws<ArgumentNullException>(() =>
                                              new FieldOrPropertyInfo(null, BindingFlags.Public | BindingFlags.Instance)
                                          );
   }

   /// <summary>
   /// Validate that Constructor Throws ArgumentException when non-property or non-field MemberInfo passed.
   /// </summary>
   [Theory]
   [InlineData(MemberTypes.Constructor)]
   [InlineData(MemberTypes.Event)]
   [InlineData(MemberTypes.Method)]
   [InlineData(MemberTypes.NestedType)]
   [InlineData(MemberTypes.TypeInfo)]
   public void Constructor_WhenNonPropertyNonFieldMemberInfoPassed_ThrowsArgumentException(MemberTypes type)
   {
      var mi = new Mock<MemberInfo>();
      mi.SetupGet(s => s.MemberType).Returns(type);
      Assert.Throws<ArgumentException>(() =>
                                          new FieldOrPropertyInfo(mi.Object
                                                                , BindingFlags.Public | BindingFlags.Instance
                                                                 )
                                      );
   }

   /// <summary>
   /// Validate that Constructor does not throw any exception when property or field MemberInfo passed.
   /// </summary>
   [Theory]
   [InlineData(MemberTypes.Field)]
   [InlineData(MemberTypes.Property)]
   public void Constructor_WhenPropertyOrFieldMemberInfoPassed_DoesNoThrowAnyException(MemberTypes type)
   {
      var mi = new Mock<MemberInfo>();
      mi.SetupGet(s => s.MemberType).Returns(type);
      _ = new FieldOrPropertyInfo(mi.Object, BindingFlags.Public | BindingFlags.Instance);
   }

   /// <summary>
   /// Validate that AllProperties Return DelegatedValue When Called. Additional test description.
   /// </summary>
   [Fact]
   public void AllProperties_WhenCalled_ReturnDelegatedValue()
   {
      var               mi                    = new Mock<MemberInfo>();
      const MemberTypes expectedMemberType    = MemberTypes.Property;
      var               expectedDeclaringType = typeof(TestClassA);
      var               expectedReflectedType = typeof(TestClassB);
      const string      expectedName          = "AnExpectedName";

      mi.SetupGet(s => s.MemberType).Returns(expectedMemberType);
      mi.SetupGet(s => s.DeclaringType).Returns(expectedDeclaringType);
      mi.SetupGet(s => s.Name).Returns(expectedName);
      mi.SetupGet(s => s.ReflectedType).Returns(expectedReflectedType);
      var sut = new FieldOrPropertyInfo(mi.Object, BindingFlags.Public | BindingFlags.Instance);
      Assert.Equal(expectedMemberType,    sut.MemberType);
      Assert.Equal(expectedDeclaringType, sut.DeclaringType);
      Assert.Equal(expectedReflectedType, sut.ReflectedType);
      Assert.Equal(expectedName,          sut.Name);
      mi.VerifyGet(s => s.MemberType);
      mi.VerifyGet(s => s.DeclaringType);
      mi.VerifyGet(s => s.ReflectedType);
      mi.VerifyGet(s => s.Name);
   }

   /// <summary>
   /// Validate that IsDefined DelegatesToMemberInfo When Called.
   /// </summary>
   [Theory]
   [InlineData(MemberTypes.Property, typeof(string), false, false)]
   [InlineData(MemberTypes.Property, typeof(Type),   false, true)]
   [InlineData(MemberTypes.Property, typeof(string), true,  false)]
   [InlineData(MemberTypes.Property, typeof(Type),   true,  true)]
   [InlineData(MemberTypes.Field,    typeof(string), true,  false)]
   [InlineData(MemberTypes.Field,    typeof(string), false, false)]
   [InlineData(MemberTypes.Field,    typeof(Type),   false, true)]
   [InlineData(MemberTypes.Field,    typeof(Type),   true,  true)]
   public void IsDefined_WhenCalled_DelegatesToMemberInfoImplementation(
      MemberTypes memberType
    , Type        attributeType
    , bool        inherit
    , bool        result
   )
   {
      var mi = new Mock<MemberInfo>();
      mi.SetupGet(s => s.MemberType).Returns(memberType);
      mi.Setup(s => s.IsDefined(attributeType, inherit)).Returns(result);
      var sut = new FieldOrPropertyInfo(mi.Object, BindingFlags.Public | BindingFlags.Instance);
      var res = sut.IsDefined(attributeType, inherit);
      mi.Verify(s => s.IsDefined(attributeType, inherit));
      Assert.Equal(result, res);
   }

   /// <summary>
   /// Validate that GetCustomAttributes (with type) delegates to MemberInfo when called.
   /// </summary>
   [Theory]
   [InlineData(MemberTypes.Property, typeof(string), false)]
   [InlineData(MemberTypes.Property, typeof(Type),   false)]
   [InlineData(MemberTypes.Property, typeof(string), true)]
   [InlineData(MemberTypes.Property, typeof(Type),   true)]
   [InlineData(MemberTypes.Field,    typeof(string), true)]
   [InlineData(MemberTypes.Field,    typeof(string), false)]
   [InlineData(MemberTypes.Field,    typeof(Type),   false)]
   [InlineData(MemberTypes.Field,    typeof(Type),   true)]
   public void GetCustomAttributesWithType_WhenCalled_DelegatesToMemberInfoImplementation(
      MemberTypes memberType
    , Type        attributeType
    , bool        inherit
   )
   {
      var result = Array.Empty<object>();
      var mi     = new Mock<MemberInfo>();
      mi.SetupGet(s => s.MemberType).Returns(memberType);
      mi.Setup(s => s.GetCustomAttributes(attributeType, inherit)).Returns(result);
      var sut = new FieldOrPropertyInfo(mi.Object, BindingFlags.Public | BindingFlags.Instance);
      var res = sut.GetCustomAttributes(attributeType, inherit);
      mi.Verify(s => s.GetCustomAttributes(attributeType, inherit));
      Assert.Same(result, res);
   }

   /// <summary>
   /// Validate that GetCustomAttributes (with inherit) delegates to MemberInfo when called.
   /// </summary>
   [Theory]
   [InlineData(MemberTypes.Property, false)]
   [InlineData(MemberTypes.Property, true)]
   [InlineData(MemberTypes.Field,    true)]
   [InlineData(MemberTypes.Field,    false)]
   public void GetCustomAttributesWithInherit_WhenCalled_DelegatesToMemberInfoImplementation(
      MemberTypes memberType
    , bool        inherit
   )
   {
      var result = Array.Empty<object>();
      var mi     = new Mock<MemberInfo>();
      mi.SetupGet(s => s.MemberType).Returns(memberType);
      mi.Setup(s => s.GetCustomAttributes(inherit)).Returns(result);
      var sut = new FieldOrPropertyInfo(mi.Object, BindingFlags.Public | BindingFlags.Instance);
      var res = sut.GetCustomAttributes(inherit);
      mi.Verify(s => s.GetCustomAttributes(inherit));
      Assert.Same(result, res);
   }

   /// <summary>
   /// Validate that GetValue (for property) delegates to MemberInfo when called.
   /// </summary>
   [Fact]
   public void GetValueForProperty_WhenCalled_DelegatesToMemberInfoImplementation()
   {
      const string       result = "A name";
      const string       name   = "Prop2";
      const BindingFlags flags  = BindingFlags.Public | BindingFlags.Instance;
      var                obj    = new TestClassA { Prop2 = result };
      var                mi     = obj.GetType().GetMember(name)[0];
      var                sut    = new FieldOrPropertyInfo(mi, flags);
      var                res    = sut.GetValue(obj);
      Assert.Same(result, res);
   }

   /// <summary>
   /// Validate that GetValue (for field) delegates to MemberInfo when called.
   /// </summary>
   [Fact]
   public void GetValueForField_WhenCalled_DelegatesToMemberInfoImplementation()
   {
      var                obj    = new object();
      var                result = new object();
      var                mi     = new Mock<MemberInfo>();
      var                dt     = new Mock<Type>();
      var                fi     = new Mock<FieldInfo>();
      const BindingFlags flags  = BindingFlags.Public | BindingFlags.Instance;
      const string       name   = "name";
      mi.SetupGet(s => s.Name).Returns(name);
      mi.SetupGet(s => s.MemberType).Returns(MemberTypes.Field);
      mi.SetupGet(s => s.DeclaringType).Returns(dt.Object);
      dt.Setup(s => s.GetField(name, flags)).Returns(fi.Object);
      fi.Setup(s => s.GetValue(obj)).Returns(result);
      var sut = new FieldOrPropertyInfo(mi.Object, flags);
      var res = sut.GetValue(obj);
      mi.VerifyGet(s => s.Name);
      mi.VerifyGet(s => s.MemberType);
      mi.VerifyGet(s => s.DeclaringType);
      dt.Verify(s => s.GetField(name, flags));
      fi.Verify(s => s.GetValue(obj));
      Assert.Same(result, res);
   }

   [Fact]
   public void GetValue_When_Property_Throws_An_Exception_Returns_Null()
   {
      var a     = new TestClassC();
      var item  = new FieldOrPropertyEnumerator(a).First(x => x.Name == "ExceptionalProperty");
      var value = item.GetValue(a);
      Assert.Null(value);
   }

   [Fact]
   public void GetValue_When_Property_Throws_An_Exception_Returns_Null_And_Outputs_Errored_Of_True()
   {
      var a     = new TestClassC();
      var item  = new FieldOrPropertyEnumerator(a).First(x => x.Name == "ExceptionalProperty");
      var value = item.GetValue(a, out var errored);
      Assert.Null(value);
      Assert.True(errored);
   }

   [Fact]
   public void SetValue_When_Property_Throws_An_Exception_Throws_No_Exception()
   {
      var a    = new TestClassC();
      var item = new FieldOrPropertyEnumerator(a).First(x => x.Name == "ExceptionalProperty");
      item.SetValue(a, 5);
   }

   [Fact]
   public void SetValue_When_Property_Throws_An_Exception_Throws_No_Exception_And_Returns_Errored_True()
   {
      var a    = new TestClassC();
      var item = new FieldOrPropertyEnumerator(a).First(x => x.Name == "ExceptionalProperty");
      item.SetValue(a, 5, out var errored);
      Assert.True(errored);
   }

   [Fact]
   public void SetValue_Sets_A_Property_Successfully()
   {
      var a    = new TestClassA();
      var item = new FieldOrPropertyEnumerator(a).First(x => x.Name == "Prop1");
      item.SetValue(a, 13);
      Assert.Equal(13, a.Prop1);
   }

   [Fact]
   public void SetValue_Sets_A_Field_Successfully()
   {
      var a    = new TestClassA();
      var item = new FieldOrPropertyEnumerator(a).First(x => x.Name == "Field1");
      item.SetValue(a, 13);
      Assert.Equal(13, a.Field1);
   }
}