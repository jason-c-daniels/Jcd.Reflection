// ReSharper disable UnusedMember.Local
// ReSharper disable ConvertToAutoProperty
// ReSharper disable UnusedMember.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace Jcd.Reflection.Tests._Fakes.AssemblyTest;

public struct TestStruct
{
    private int _afield;

    public int AProp { get; set; }

    private int AFieldAccessor
    {
        get => _afield;
        set => _afield = value;
    }

    public TestStruct(int afield, int aProp = 0)
    {
        _afield = afield;
        AProp = aProp;
    }
}