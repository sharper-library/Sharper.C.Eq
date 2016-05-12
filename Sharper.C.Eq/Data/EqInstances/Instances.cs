using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharper.C.Data.EqInstances
{

public struct EqInt
  : Eq<int>
{
    public bool Equal(int x, int y)
    =>  x == y;
}

public struct EqUInt
  : Eq<uint>
{
    public bool Equal(uint x, uint y)
    =>  x == y;
}

public struct EqLong
  : Eq<long>
{
    public bool Equal(long x, long y)
    =>  x == y;
}

public struct EqByte
  : Eq<byte>
{
    public bool Equal(byte x, byte y)
    =>  x == y;
}

public struct EqChar
  : Eq<char>
{
    public bool Equal(char x, char y)
    =>  x == y;
}

public struct EqBool
  : Eq<bool>
{
    public bool Equal(bool x, bool y)
    =>  x == y;
}

public struct EqString
  : Eq<string>
{
    public bool Equal(string x, string y)
    =>  x == y;
}

public struct EqEnumerable<A, AEq>
  : Eq<IEnumerable<A>>
  where AEq : Eq<A>
{
    public bool Equal(IEnumerable<A> x, IEnumerable<A> y)
    =>  x.SequenceEqual(y, default(AEq).ToEqualityComparer());
}

public struct EqTuple<A, AEq, B, BEq>
  : Eq<Tuple<A, B>>
  where AEq : Eq<A>
  where BEq : Eq<B>
{
    public bool Equal(Tuple<A, B> x, Tuple<A, B> y)
    =>  default(AEq).Equal(x.Item1, y.Item1)
        &&
        default(BEq).Equal(x.Item2, y.Item2);
}

}
