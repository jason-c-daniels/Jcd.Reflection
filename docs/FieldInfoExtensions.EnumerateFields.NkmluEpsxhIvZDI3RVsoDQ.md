### [Jcd.Reflection](Jcd.Reflection.md 'Jcd.Reflection').[FieldInfoExtensions](FieldInfoExtensions.md 'Jcd.Reflection.FieldInfoExtensions')

## FieldInfoExtensions.EnumerateFields(this object, Nullable<BindingFlags>, Func<FieldInfo,bool>) Method

Enumerate the FieldInfo entries for a given instance

```csharp
public static System.Collections.Generic.IEnumerable<System.Reflection.FieldInfo> EnumerateFields(this object self, System.Nullable<System.Reflection.BindingFlags> flags=null, System.Func<System.Reflection.FieldInfo,bool> skip=null);
```

#### Parameters

<a name='Jcd.Reflection.FieldInfoExtensions.EnumerateFields(thisobject,System.Nullable_System.Reflection.BindingFlags_,System.Func_System.Reflection.FieldInfo,bool_).self'></a>

`self` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The data instance to reflect on

<a name='Jcd.Reflection.FieldInfoExtensions.EnumerateFields(thisobject,System.Nullable_System.Reflection.BindingFlags_,System.Func_System.Reflection.FieldInfo,bool_).flags'></a>

`flags` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Reflection.BindingFlags](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.BindingFlags 'System.Reflection.BindingFlags')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The BindingFlags

<a name='Jcd.Reflection.FieldInfoExtensions.EnumerateFields(thisobject,System.Nullable_System.Reflection.BindingFlags_,System.Func_System.Reflection.FieldInfo,bool_).skip'></a>

`skip` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Reflection.FieldInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.FieldInfo 'System.Reflection.FieldInfo')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

a predicate for skipping certain entries (e.g. System...)

#### Returns

[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Reflection.FieldInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.FieldInfo 'System.Reflection.FieldInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
An enumerable across FieldInfo s