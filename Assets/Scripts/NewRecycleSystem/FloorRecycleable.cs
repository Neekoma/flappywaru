using UnityEngine;

namespace Krevechous.NewRecycleSystem
{

    public class FloorRecycleable : Recycleable
    {
        private static readonly float distanceBetweenFloors = 3.774f;

        public override void OnRecycle()
        {
            //Работа с пулом
            var last = pool.recycleables.Last.Value;

            transform.position = new Vector3(last.transform.position.x + distanceBetweenFloors, transform.position.y, 0);

            pool?.recycleables.RemoveFirst();
            pool?.recycleables.AddLast(this);
        }
    }
}