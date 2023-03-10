using UnityEngine;

namespace Krevechous
{
    public sealed class TubeRecycleHandler : MonoRecycleHandler
    {

        private void Awake()
        {
            AddRecycler();
        }

        private void OnBecameInvisible()
        {
            BeforeRecycle();
        }

        protected override void AddRecycler()
        {
            var recycler = FindObjectOfType<TubesRecycler>();
            if (recycler != null) {
                Debug.Log("!!!ÓÐÀ!!!");
            }
        }

        public override void OnRecycle()
        {
            throw new System.NotImplementedException();
        }

        protected override void BeforeRecycle()
        {
            throw new System.NotImplementedException();
        }

        protected override void AfterRecycle()
        {
            throw new System.NotImplementedException();
        }
    }
}