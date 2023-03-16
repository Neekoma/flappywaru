using UnityEngine;

namespace Krevechous.ObjectsRecycler
{
    public sealed class TubeRecycleAdapter : MonoRecycleAdapter
    {
        public override void BeforeRecycle()
        {
            
          
        }
        public override void OnRecycle()
        {
            Debug.Log($"Труба номер {gameObject.name} теперь не такая, какой была раньше");
        }

        public override void AfterRecycle()
        {
            
        }
    }
}