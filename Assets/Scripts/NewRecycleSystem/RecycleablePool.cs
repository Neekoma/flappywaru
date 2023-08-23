using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;

namespace Krevechous.NewRecycleSystem
{
    public class RecycleablePool : MonoBehaviour
    {
        public LinkedList<Recycleable> recycleables { get; private set; } = new LinkedList<Recycleable>();

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++) {
                recycleables.AddLast(transform.GetChild(i).GetComponent<Recycleable>());
            }
        }
    }
}
