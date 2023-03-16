using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Krevechous.ObjectsRecycler;
using System;

namespace Krevechous
{
    public sealed class TubesPool : Pool
    {
        public static event Action OnTubesReady;

        protected override void Awake()
        {
            base.Awake();
        }

   
        public override void ReturnToPool(Transform recycleable) {
            recycleables.RemoveFirst();
            recycleables.AddLast(recycleable);
        }

        protected override IEnumerator SetupPoolCoroutine()
        {

            for (int i = 0; i < transform.childCount; i++)
            {
                recycleables.AddLast(transform.GetChild(i).transform);
                recycleables.Last.Value.position = new Vector3(recycleables.Last.Previous != null ? recycleables.Last.Previous.Value.position.x + 2.5f : recycleables.Last.Value.position.x, UnityEngine.Random.Range(-2f, 4f), 0);
                yield return new WaitForEndOfFrame();
            }
            OnTubesReady?.Invoke();
        }
    }
}
