using UnityEngine;

namespace Krevechous.ObjectsRecycler
{
    public sealed class TubeRecycleAdapter : MonoRecycleAdapter<TubesRecycler>
    {

        new private void Awake()
        {
            base.Awake();
        }
        

        public override void BeforeRecycle()
        {
            base.BeforeRecycle();
        }
        public override void OnRecycle()
        {
            base.OnRecycle();
        }

        public override void AfterRecycle()
        {
            base.AfterRecycle();
        }
    }
}