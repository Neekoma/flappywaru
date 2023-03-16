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
            var newHeight = UnityEngine.Random.Range(-2f, 4f);
            first.position = new Vector3(last.position.x + 2.5f, newHeight, 0);

            obj.OnRecycle();
            
            pool.ReturnToPool(first);
        }
    }
}