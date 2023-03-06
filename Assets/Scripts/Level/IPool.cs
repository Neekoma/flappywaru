using System.Collections.Generic;
using UnityEngine.Events;

namespace Krevechous {
    public interface IPool<T> {

        public Queue<T> Pool { get; }
        public UnityEvent<T> OnRecycle { get; }

        public void Add(T obj);
        public T Extract();
        public void Recycle();
    }
}