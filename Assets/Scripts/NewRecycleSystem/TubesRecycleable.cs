using System.Collections.Generic;
using UnityEngine;

namespace Krevechous.NewRecycleSystem
{

    public class TubesRecycleable : Recycleable
    {
        public static readonly float distanceBetweenTubes = 2.5f;

        [SerializeField] private Coin coin;

        private void Start ()
        {
            StartPlacement();
        }

        private void StartPlacement() {
            GetPlaceHeight(out float placeHeight, Random.Range(-1000f, 1000f), Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(-2, 1));
            transform.position = new Vector3(transform.position.x, placeHeight, 0);
            SetupOtherObjects();
        }

        private void GetPlaceHeight(out float placeHeight, float x, float a, float b, float c) // [-3; 2]
        {
            placeHeight = (Mathf.Sin(x * a) * Mathf.Cos(x * b)) * c;
        }

        private void SetupOtherObjects()
        {
            if (Random.Range(1, 4) == 1) // 1/3
            {
                coin?.gameObject.SetActive(true);
            }
        }

        public override void OnRecycle()
        {
            //Работа с пулом
            var last = pool.recycleables.Last.Value;

            GetPlaceHeight(out float placeHeight, Random.Range(-1000f, 1000f), Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(-2, 1));

            transform.position = new Vector3(last.transform.position.x + distanceBetweenTubes, placeHeight, 0);

            pool?.recycleables.RemoveFirst();
            pool?.recycleables.AddLast(this);

            SetupOtherObjects();
        }
    }
}