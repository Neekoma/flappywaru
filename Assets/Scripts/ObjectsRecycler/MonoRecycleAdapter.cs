using System;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{

    public abstract class MonoRecycleAdapter : MonoBehaviour, IRecycleable
    {
        private MonoRecycler _recycler;

        public event Action OnBeforeRecycle;
        public event Action OnAfterRecycle;

        public MonoRecycler Recycler
        {
            get { return _recycler; }
            set { _recycler = value; }
        }

        public abstract void OnRecycle();
        public abstract void BeforeRecycle();
        public abstract void AfterRecycle();
    }
}