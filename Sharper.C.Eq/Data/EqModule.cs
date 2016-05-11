using System;
using System.Collections.Generic;

namespace Sharper.C.Data
{
    public interface Eq<A>
    {   bool Equal(A x, A y);
    }

    public static class Eq
    {
        public static bool NotEqual<A>(this Eq<A> eq, A x, A y)
        =>  !eq.Equal(x, y);

        public static IEqualityComparer<A> ToEqualityComparer<A>(this Eq<A> eq)
        =>  new AnonEqualityComparer<A>(eq);

        public static Eq<A> From<A>(Func<A, A, bool> f)
        =>  new AnonEq<A>(f);

        public static Eq<A> From<A>(IEqualityComparer<A> ec)
        =>  new AnonEq<A>(ec.Equals);

        public static Eq<A> FromEquatable<A>()
          where A : IEquatable<A>
        =>  FromDefault<A>();

        public static Eq<A> FromDefault<A>()
        =>  From(EqualityComparer<A>.Default);

        private sealed class AnonEq<A>
          : Eq<A>
        {
            public Func<A, A, bool> F { get; }

            public AnonEq(Func<A, A, bool> f)
            {   F = f;
            }

            public bool Equal(A x, A y)
            =>  F(x, y);
        }

        private sealed class AnonEqualityComparer<A>
          : IEqualityComparer<A>
        {
            public Eq<A> EqA { get; }

            public AnonEqualityComparer(Eq<A> eqA)
            {   EqA = eqA;
            }

            public bool Equals(A x, A y)
            =>  EqA.Equal(x, y);

            public int GetHashCode(A obj)
            {   throw new NotImplementedException();
            }
        }
    }
}
