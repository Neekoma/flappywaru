using UnityEngine;

namespace Krevechous
{
    public class TubesRecycler : MonoRecycler<TubeRecycleHandler>
    {
        public override void Recycle(TubeRecycleHandler obj)
        {
            obj.OnRecycle();
        }
    }
}