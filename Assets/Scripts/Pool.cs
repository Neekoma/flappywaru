using UnityEngine;

namespace Krevechous
{
    public abstract class Pool<T> : MonoBehaviour where T : MonoRecycleHandler
    {
        protected Factory<T> factory;

        protected int size;
        public int Size => size;

        public Factory<T> Factory => factory;



    }
}