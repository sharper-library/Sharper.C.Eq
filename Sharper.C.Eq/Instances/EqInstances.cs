using System;
using System.Collections.Generic;
using System.Linq;
using Sharper.C.Data;

namespace Sharper.C.Instances
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

    public struct EqEnumerable<A, EqA>
      : Eq<IEnumerable<A>>
      where EqA : Eq<A>
    {
        public EqEnumerable(EqA _eqA = default(EqA))
        {
        }

        public bool Equal(IEnumerable<A> x, IEnumerable<A> y)
        =>  x.SequenceEqual(y, default(EqA).ToEqualityComparer());
    }

    public struct EqTuple<A, EqA, B, EqB>
      : Eq<Tuple<A, B>>
      where EqA : Eq<A>
      where EqB : Eq<B>
    {
        public EqTuple(EqA _eqA = default(EqA), EqB _eqB = default(EqB))
        {
        }

        public bool Equal(Tuple<A, B> x, Tuple<A, B> y)
        =>  default(EqA).Equal(x.Item1, y.Item1)
            &&
            default(EqB).Equal(x.Item2, y.Item2);
    }

}
