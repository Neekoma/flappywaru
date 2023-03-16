using System;
using System.Collections.Generic;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{
    public class TubesRecycler : MonoRecycler
    {
        private LinkedList<Transform> recycleables = new LinkedList<Transform>();

        private void Awake()
        {
            var pool = FindObjectOfType<TubesPool>();
            pool.SendRecyclerToChildren(this);

            for (int i = 0; i < pool.transform.childCount; i++)
            {
                recycleables.AddLast(pool.transform.GetChild(i).transform);
                recycleables.Last.Value.position = new Vector3(recycleables.Last.Previous != null ? recycleables.Last.Previous.Value.position.x + 2.5f : recycleables.Last.Value.position.x, UnityEngine.Random.Range(-2f, 4f), 0);
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out TubeRecycleAdapter adapter))
            {
                Debug.Log("Trigger");
                Recycle(adapter);
            }
        }

        public override void Recycle(IRecycleable obj)
        {
            base.Recycle(obj);

            var first = recycleables.First.Value;
            var last = recycleables.Last.Value;
            var newHeight = UnityEngine.Random.Range(-2f, 4f);
            first.position = new Vector3(last.position.x + 2.5f, newHeight, 0);
            recycleables.RemoveFirst();
            recycleables.AddLast(first);

            obj.OnRecycle();
        }

    }
}