using System.Collections;
using UnityEngine;
using System;
using Krevechous.ObjectsRecycler;

namespace Krevechous
{
    public sealed class TubesPool : Pool
    {
        public static event Action OnTubesReady;

        public float distanceBetweenTubes { get; } = 3f;
 
        protected override void Awake()
        {
            base.Awake();
        }

   
        public override void ReturnToPool(MonoBehaviour recycleable) {
            recycleables.RemoveFirst();
            recycleables.AddLast(recycleable);
        }

        protected override IEnumerator SetupPoolCoroutine()
        {

            for (int i = 0; i < transform.childCount; i++)
            {
                var recycleable = recycleables.AddLast((MonoBehaviour)transform.GetChild(i).GetComponent<IRecycleable>()).Value;

                recycleable.transform.position = new Vector3(recycleables.Last.Previous != null
                    ? recycleables.Last.Previous.Value.transform.position.x + distanceBetweenTubes 
                    :recycleables.Last.Value.transform.position.x, recycleables.Last.Value.transform.position.y, 0);
                 
                yield return new WaitForEndOfFrame();
            }
            OnTubesReady?.Invoke();
        }
    }
}