using UnityEngine;
using Krevechous.ObjectsRecycler;
using TMPro.EditorUtilities;
using System.Collections.Generic;
using System.Collections;

namespace Krevechous
{
    public abstract class Pool : MonoBehaviour
    {
        public LinkedList<Transform> recycleables { get; private set; } = new LinkedList<Transform>();

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

        public abstract void ReturnToPool(Transform recycleable);
        protected abstract IEnumerator SetupPoolCoroutine();
    }
}