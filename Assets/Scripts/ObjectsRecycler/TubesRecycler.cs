using System;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{
    public sealed class TubesRecycler : MonoRecycler
    {
        protected override void Awake()
        {
            base.Awake();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out TubeRecycleAdapter adapter))
            {
                Recycle(adapter);
            }
        }

        public override void Recycle(IRecycleable obj)
        {
            base.Recycle(obj);

            //Перерабатываем объект
            var first = pool.recycleables.First.Value;
            var last = pool.recycleables.Last.Value;
            
            first.transform.position = new Vector3(last.transform.position.x + ((TubesPool)pool).distanceBetweenTubes, first.transform.position.y, 0);

            obj.OnRecycle();
            
            pool.ReturnToPool(first);
        }
    }
}