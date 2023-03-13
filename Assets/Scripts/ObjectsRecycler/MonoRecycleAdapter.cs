using System;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{

    public abstract class MonoRecycleAdapter<T> : MonoBehaviour, IRecycleable where T : MonoRecycler
    {
        private MonoRecycler _recycler;

        public event Action OnBeforeRecycle;
        public event Action OnAfterRecycle;

        public MonoRecycler Recycler { get { return _recycler; } set { _recycler = value; } }

        protected void Awake()
        {
            FindRecycler();
        }

        /**<summary>Найти переработчик на сцене и получить ссылку на него</summary>>*/
        private void FindRecycler() {
            _recycler = FindObjectOfType<T>();
            if (_recycler == null)
                throw new RecyclerNotFoundException(typeof(T), $"Переработчик не был найден");
        }
        
        public virtual void OnRecycle() { }
        public virtual void BeforeRecycle() { OnBeforeRecycle?.Invoke(); }

        public virtual void AfterRecycle() { OnAfterRecycle?.Invoke(); }
    }
}