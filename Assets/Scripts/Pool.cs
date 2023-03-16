using UnityEngine;
using Krevechous.ObjectsRecycler;
using TMPro.EditorUtilities;

namespace Krevechous
{
    public abstract class Pool<T> : MonoBehaviour
    {
        protected Factory<T> factory;

        public void SendRecyclerToChildren(MonoRecycler recycler)
        {
            var adapters = transform.GetComponentsInChildren<MonoRecycleAdapter>();
            foreach (var adapter in adapters)
            {
                adapter.Recycler = recycler;
            }
        }



    }
}