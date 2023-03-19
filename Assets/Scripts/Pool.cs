using UnityEngine;
using Krevechous.ObjectsRecycler;
using System.Collections.Generic;
using System.Collections;

namespace Krevechous
{
    public abstract class Pool : MonoBehaviour
    {
        public LinkedList<MonoBehaviour> recycleables { get; private set; } = new LinkedList<MonoBehaviour>();

        protected virtual void Awake()
        {
            StartCoroutine(SetupPoolCoroutine());
        }

        public void SendRecyclerToChildren(MonoRecycler recycler)
        {
            var adapters = transform.GetComponentsInChildren<MonoRecycleAdapter>();
            foreach (var adapter in adapters)
            {
                adapter.Recycler = recycler;
            }
        }

        public abstract void ReturnToPool(MonoBehaviour recycleable);
        protected abstract IEnumerator SetupPoolCoroutine();
    }
}