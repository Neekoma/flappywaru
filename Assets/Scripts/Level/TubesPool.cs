using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Krevechous
{
    public class TubesPool : MonoBehaviour, IPool<Tube>
    {
        [SerializeField] private UnityEvent<Tube> _onRecycle;
        public Queue<Tube> Pool { get; }

        public UnityEvent<Tube> OnRecycle => _onRecycle;

        public void Add(Tube obj)
        {
            Pool.Enqueue(obj);
        }

        public Tube Extract()
        {
            return Pool.Peek();
        }

        public void Recycle()
        {
            var tube = Pool.Dequeue();
            Pool.Enqueue(tube);
            OnRecycle?.Invoke(tube);
        }
    }
}
