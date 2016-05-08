using System.Collections.Generic;

namespace Sharper.C.Data
{

using System;
using Lang.Typeclass;

public static class EqModule
{
    [Typeclass]
    public interface Eq<A>
    {   bool Equal(A x, A y);
    }

    public static bool NotEqual<A>(this Eq<A> eq, A x, A y)
    =>  !eq.Equal(x, y);

    public static IEqualityComparer<A> EqualityComparer<A>(this Eq<A> eq)
    =>  new AnonEqualityComparer<A>(eq);

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
