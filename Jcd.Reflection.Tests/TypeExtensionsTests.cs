#region

using Jcd.Reflection.Tests.Fakes;
using Jcd.Reflection.Tests.Fakes;
using Jcd.Reflection.Tests.Fakes.DeepInheritance;

using Xunit;

#endregion

namespace Jcd.Reflection.Tests;

public class TypeExtensionsTests
{
   [Fact]
   public void IsConcreteType_Returns_True_For_Concrete_Types()
   {
      Assert.True(typeof(DerivedFromIiDerivedFromIImplementsIDerivedFromIiDerivedFromIGenericBase<>).IsConcreteType());
      Assert.True(typeof(S<>).IsConcreteType());
      Assert.True(typeof(S2<>).IsConcreteType());
      Assert.True(typeof(S<int>).IsConcreteType());
      Assert.True(typeof(S2<int>).IsConcreteType());
      Assert.True(typeof(NestedType).IsConcreteType());
      Assert.True(typeof(NestedType.AnotherNestedType).IsConcreteType());
      Assert.True(typeof(PrivateNestedType).IsConcreteType());
      Assert.True(typeof(NeenerImBeingDumb<>).IsConcreteType());
      Assert.True(typeof(NeenerImBeingDumb<int>).IsConcreteType());
   }

   [Fact]
   public void InheritsFrom_Returns_True_For_Derived_Types()
   {
      Assert.True(typeof(AbstractDerived<>).InheritsFrom(typeof(AbstractGenericBase<>)));
      Assert.True(typeof(PlainOldImplementation1).InheritsFrom<IPlainOldInterface>());
      Assert.True(typeof(DerivedFromIiDerivedFromIImplementsIDerivedFromIiDerivedFromIGenericBase<>)
                    .InheritsFrom(typeof(IGenericBase<>))
                 );
      Assert.True(typeof(NeenerImBeingDumb<>).InheritsFrom(typeof(IGenericBase<>)));
      Assert.True(typeof(NeenerImBeingDumb<>).InheritsFrom(typeof(Int32ImplementsIGenericBase)));
      Assert.True(typeof(AbstractDerived<int>).InheritsFrom(typeof(AbstractGenericBase<int>)));
      Assert.True(typeof(ImplementsIGenericBase<>).InheritsFrom(typeof(IGenericBase<>)));
      Assert.True(typeof(S3).InheritsFrom(typeof(I<>)));
   }

   [Fact]
   public void InheritsFrom_Returns_False_For_Types_Not_Derived_From_Provided_Type()
   {
      Assert.False(typeof(AbstractDerived<>).InheritsFrom(typeof(IGenericBase<>)));
      Assert.False(typeof(GenericBase<>).InheritsFrom<IPlainOldInterface>());
      Assert.False(typeof(DerivedFromIiDerivedFromIImplementsIDerivedFromIiDerivedFromIGenericBase<>)
                     .InheritsFrom(typeof(GenericBase<>))
                  );
      Assert.False(typeof(NeenerImBeingDumb<>).InheritsFrom(typeof(GenericBase<>)));
      Assert.False(typeof(NeenerImBeingDumb<>).InheritsFrom(typeof(
                                                               Int64DerivedFromIImplementsIDerivedFromIiDerivedFromIGenericBase)
                                                           )
                  );
      Assert.False(typeof(AbstractDerived<int>).InheritsFrom(typeof(IGenericBase<int>)));
      Assert.False(typeof(ImplementsIGenericBase<>).InheritsFrom(typeof(GenericBase<>)));
   }

   private class PrivateNestedType
   {
   }

   public class NestedType
   {
      public class AnotherNestedType
      {
      }
   }

   public struct S<T>
      where T : struct
   {
      public T F;
   }

   private struct S2<T>
      where T : struct
   {
      public T F = default;

      public S2() { }
   }

   private interface I<T>
   {
      public T F { get; }
   }

   private struct S3 : I<int>
   {
      public S3() { }

      #region Implementation of I<int>

      /// <inheritdoc />
      public int F { get; } = default;

      #endregion
   }

   private enum E
   {
      Foo
    , Bar
   }
}