using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{
    public class RecycleablePool : MonoBehaviour
    {
        private Transform[] _objects;

        private void Awake()
        {
            _objects = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                _objects[i] = transform.GetChild(0);
            }
        }

        public Transform GetFirst() { return _objects[0]; }
        public Transform GetLast() { return _objects[_objects.Length - 1]; }
    }
}