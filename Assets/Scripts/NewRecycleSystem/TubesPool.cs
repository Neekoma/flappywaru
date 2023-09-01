using Krevechous.Core;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Krevechous.NewRecycleSystem
{
    public class TubesPool : MonoBehaviour, IResetable, IRecycleablePool
    {
        private NewGameManager _gm;

        private LinkedList<Recycleable> _defaultPool = new LinkedList<Recycleable>();

        public LinkedList<Recycleable> recycleables { get; set; } = new();

        [Inject]
        public void Construct(NewGameManager gm)
        {
            _gm = gm;
        }

        private void OnEnable()
        {
            _gm.OnGameReset += ApplyDefaultState;
        }

        private void OnDisable()
        {
            _gm.OnGameReset -= ApplyDefaultState;
        }

        public void ApplyDefaultState()
        {
            CopyLinkedLists(_defaultPool, recycleables);
        }

        public void SaveDefaultState()
        {
            CopyLinkedLists(recycleables, _defaultPool);
        }

        private void CopyLinkedLists(LinkedList<Recycleable> from, LinkedList<Recycleable> to)
        {
            to.Clear();

            var o = from.First;

            do
            {
                to.AddLast(o.Value);
                o = o.Next;
            } while (o != null);
        }

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                recycleables.AddLast(transform.GetChild(i).GetComponent<Recycleable>());
            }

            SaveDefaultState();
        }
    }
}
