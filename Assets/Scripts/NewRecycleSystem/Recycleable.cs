using UnityEngine;

namespace Krevechous.NewRecycleSystem
{
    public abstract class Recycleable : MonoBehaviour
    {
        protected RecycleablePool pool;

        private void Awake()
        {
            transform.parent.TryGetComponent<RecycleablePool>(out pool);
        }

        public abstract void OnRecycle();
    }
}