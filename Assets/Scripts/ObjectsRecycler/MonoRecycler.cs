using System.Collections.Generic;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{
    public abstract class MonoRecycler: MonoBehaviour
    {
        protected Pool pool;

        protected virtual void Awake()
        {
            pool = FindObjectOfType<TubesPool>();
            pool.SendRecyclerToChildren(this);
        }

        public virtual void Recycle(IRecycleable obj) {
            obj.BeforeRecycle();
        }
    }
}