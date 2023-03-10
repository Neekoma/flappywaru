using UnityEngine;
using System;
using System.Data.SqlTypes;

namespace Krevechous
{
    public sealed class TubeFactory : Factory<TubeRecycleHandler>
    {
        public TubeRecycleHandler GetTube()
        {
            return null;
        }

        public TubeRecycleHandler GetTubeWithCoin()
        {
            return null;
        }

        public TubeRecycleHandler GetTubeWithTrap()
        {
            throw new NotImplementedException();
        }

        public TubeRecycleHandler GetTubeWithH()
        {
            throw new NotImplementedException();
        }
    }
}
