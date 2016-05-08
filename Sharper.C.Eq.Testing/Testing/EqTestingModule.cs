using Fuchu;
using FsCheck;

namespace Sharper.C.Testing
{

using static Data.EqModule;
using static Properties.RelationPropertiesModule;

public static class EqTestingModule
{
    public static Test EqLaws<A>(Eq<A> eqA, Arbitrary<A> arbA)
    =>
        "Eq Laws"
        .All
          ( IsEquivalence(eqA.Equal, arbA)
          );
}

}
