using UnityEngine;

namespace Krevechous.NewRecycleSystem
{
    public abstract class Recycleable : MonoBehaviour
    {
        protected IRecycleablePool pool;

        private void Awake()
        {
            transform.parent.TryGetComponent<IRecycleablePool>(out pool);
        }

        public abstract void OnRecycle();
    }
}