using System.Collections;
using UnityEngine;
using System;
using Krevechous.ObjectsRecycler;

namespace Krevechous
{
    public sealed class TubesPool : Pool
    {
        public static event Action OnTubesReady;

        public float distanceBetweenTubes { get; } = 4.5f;

        protected override void Awake()
        {
            base.Awake();
        }


        public void StartMoving() {
            TubeMover[] movers = GetComponentsInChildren<TubeMover>();
            foreach (var mover in movers)
                mover.StartMoving();
        }

        public override void ReturnToPool(MonoBehaviour recycleable)
        {
            recycleables.RemoveFirst();
            recycleables.AddLast(recycleable);
        }

        protected override IEnumerator SetupPoolCoroutine()
        {
            if (recycleables.Count != 0)
                recycleables.Clear();

            for (int i = 0; i < transform.childCount; i++)
            {
                var recycleable = recycleables.AddLast((MonoBehaviour)transform.GetChild(i).GetComponent<IRecycleable>()).Value;
                
                recycleable.transform.position = new Vector3(recycleables.Last.Previous != null
                    ? recycleables.Last.Previous.Value.transform.position.x + distanceBetweenTubes
                    : recycleable.transform.position.x, recycleable.transform.position.y, 0);

                yield return new WaitForEndOfFrame();
            }
            OnTubesReady?.Invoke();
        }
    }
}