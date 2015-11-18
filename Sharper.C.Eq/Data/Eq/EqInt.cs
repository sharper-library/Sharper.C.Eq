using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharper.C.Data.Eq
{

using Lang.Typeclass;
using static EqModule;

[TypeclassInstance]
public struct EqInt
  : Eq<int>
{
    public bool Equal(int x, int y)
    =>
        x == y;
}

[TypeclassInstance]
public struct EqUint
  : Eq<uint>
{
    public bool Equal(uint x, uint y)
    =>
        x == y;
}

[TypeclassInstance]
public struct EqLong
  : Eq<long>
{
    public bool Equal(long x, long y)
    =>
        x == y;

}

[TypeclassInstance]
public struct EqByte
  : Eq<byte>
{
    public bool Equal(byte x, byte y)
    =>
        x == y;
}

[TypeclassInstance]
public struct EqChar
  : Eq<char>
{
    public bool Equal(char x, char y)
    =>
        x == y;
}

[TypeclassInstance]
public struct EqBool
  : Eq<bool>
{
    public bool Equal(bool x, bool y)
    =>
        x == y;
}

[TypeclassInstance]
public struct EqString
  : Eq<string>
{
    public bool Equal(string x, string y)
    =>
        x == y;
}

[TypeclassInstance]
public sealed class EqEnumerable<A>
  : Eq<IEnumerable<A>>
{
    public Eq<A> EqA { get; }

    public EqEnumerable(Eq<A> eqA)
    {
        EqA = eqA;
    }

    public bool Equal(IEnumerable<A> x, IEnumerable<A> y)
    =>
        x.SequenceEqual(y, EqA.EqualityComparer());
}

[TypeclassInstance]
public sealed class EqTuple<A, B>
  : Eq<Tuple<A, B>>
{
    public Eq<A> EqA { get; }
    public Eq<B> EqB { get; }

    public EqTuple(Eq<A> eqA, Eq<B> eqB)
    {
        EqA = eqA;
        EqB = eqB;
    }

    public bool Equal(Tuple<A, B> x, Tuple<A, B> y)
    =>
        EqA.Equal(x.Item1, y.Item1)
        &&
        EqB.Equal(x.Item2, y.Item2);
}

}
