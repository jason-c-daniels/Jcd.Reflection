### [Jcd.Reflection](Jcd.Reflection.md 'Jcd.Reflection').[TypeDiscoveryExtensions](Jcd.Reflection.TypeDiscoveryExtensions.md 'Jcd.Reflection.TypeDiscoveryExtensions')

## TypeDiscoveryExtensions.FindImplementationsOf<T>(this IEnumerable<Assembly>, bool) Method

Gets implementations of the specified type from a collection of assemblies.

```csharp
public static System.Collections.Generic.IEnumerable<System.Type> FindImplementationsOf<T>(this System.Collections.Generic.IEnumerable<System.Reflection.Assembly> assemblies, bool returnTargetTypeIfConcrete=false);
```
#### Type parameters

<a name='Jcd.Reflection.TypeDiscoveryExtensions.FindImplementationsOf_T_(thisSystem.Collections.Generic.IEnumerable_System.Reflection.Assembly_,bool).T'></a>

`T`
#### Parameters

<a name='Jcd.Reflection.TypeDiscoveryExtensions.FindImplementationsOf_T_(thisSystem.Collections.Generic.IEnumerable_System.Reflection.Assembly_,bool).assemblies'></a>

`assemblies` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Reflection.Assembly](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.Assembly 'System.Reflection.Assembly')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The collection of assemblies to search.

<a name='Jcd.Reflection.TypeDiscoveryExtensions.FindImplementationsOf_T_(thisSystem.Collections.Generic.IEnumerable_System.Reflection.Assembly_,bool).returnTargetTypeIfConcrete'></a>

`returnTargetTypeIfConcrete` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If [T](https://docs.microsoft.com/en-us/dotnet/api/T 'T') is in the target assembly, and it's a concrete, return it as well.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
An [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') of the implementations of [T](Jcd.Reflection.TypeDiscoveryExtensions.FindImplementationsOf_T_(thisSystem.Collections.Generic.IEnumerable_System.Reflection.Assembly_,bool).md#Jcd.Reflection.TypeDiscoveryExtensions.FindImplementationsOf_T_(thisSystem.Collections.Generic.IEnumerable_System.Reflection.Assembly_,bool).T 'Jcd.Reflection.TypeDiscoveryExtensions.FindImplementationsOf<T>(this System.Collections.Generic.IEnumerable<System.Reflection.Assembly>, bool).T')

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
When [assemblies](https://docs.microsoft.com/en-us/dotnet/api/assemblies 'assemblies') is null.