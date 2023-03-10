using UnityEngine;

namespace Krevechous
{
    public abstract class MonoRecycler<T> : MonoBehaviour where T : MonoRecycleHandler
    {
        public abstract void Recycle(T obj);
    }
}