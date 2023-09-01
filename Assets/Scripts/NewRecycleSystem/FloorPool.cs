using Krevechous.Core;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Krevechous.NewRecycleSystem
{
    public class FloorPool : MonoBehaviour, IRecycleablePool
    {
        private NewGameManager _gm;

        public LinkedList<Recycleable> recycleables { get; set; } = new();

        [Inject]
        public void Construct(NewGameManager gm)
        {
            _gm = gm;
        }

        
        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                recycleables.AddLast(transform.GetChild(i).GetComponent<Recycleable>());
            }
        }
    }
}
