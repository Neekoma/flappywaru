using UnityEngine;
using Krevechous.ObjectsRecycler;

namespace Krevechous
{
    public abstract class Pool<T> : MonoBehaviour
    {
        protected Factory<T> factory;

        protected int size;
        public int Size => size;

        public Factory<T> Factory => factory;



    }
}