using Krevechous.Core;
using UnityEngine;
using Zenject;

namespace Krevechous.NewRecycleSystem
{
    public class TubesRecycleable : Recycleable
    {
        private NewGameManager _gm;

        public static readonly float distanceBetweenTubes = 2.5f;

        [SerializeField] private Tube _tube;
        

        [Inject]
        public void Construct(NewGameManager gm) {
            _gm = gm;
        }

        private void OnEnable()
        {
            _gm.OnGameStart += StartPlacement;
        }

        private void OnDisable()
        {
            _gm.OnGameStart -= StartPlacement;
        }

        private void StartPlacement() {
            GetPlaceHeight(out float placeHeight, Random.Range(-1000f, 1000f), Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(-2, 1));
            transform.position = new Vector3(transform.position.x, placeHeight, 0);
        }

        private void GetPlaceHeight(out float placeHeight, float x, float a, float b, float c) // [-3; 2]
        {
            placeHeight = (Mathf.Sin(x * a) * Mathf.Cos(x * b)) * c;
        }

        public override void OnRecycle()
        {
            var last = pool.recycleables.Last.Value;

            GetPlaceHeight(out float placeHeight, Random.Range(-1000f, 1000f), Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(-2, 1));

            transform.position = new Vector3(last.transform.position.x + distanceBetweenTubes, placeHeight, 0);

            pool?.recycleables.RemoveFirst();
            pool?.recycleables.AddLast(this);

            _tube.OnRecycle();
        }
    }
}