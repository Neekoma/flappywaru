using UnityEngine;


namespace Krevechous
{
    public sealed class TubeFactory
    {
        public static TubeType GetRandTubeType() {
            int tubeType = Random.Range(0, 4);
            return (TubeType) tubeType;
        }
        

    }

    public enum TubeType
    {
        Empty, WithCoin//, WithTrap, WithH, WithCannon
    }
}
