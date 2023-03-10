using UnityEngine;

namespace Krevechous
{

    public abstract class MonoRecycleHandler : MonoBehaviour
    {
        private MonoRecycler<MonoRecycleHandler> _recycler;

        public MonoRecycler<MonoRecycleHandler> Recycler { get { return _recycler; } set { _recycler = value; } }

        protected abstract void AddRecycler();
        public abstract void OnRecycle();
        protected abstract void BeforeRecycle();

        protected abstract void AfterRecycle();
    }
}