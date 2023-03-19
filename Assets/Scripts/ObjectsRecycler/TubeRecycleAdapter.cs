using System.Runtime.InteropServices;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{

    public sealed class TubeRecycleAdapter : MonoRecycleAdapter
    {
        [SerializeField] private Coin coin;

        //[SerializeField] private Trap trap;
        //[SerializeField] private Hentai hentai;
        //[SerializeField] private Cannon cannon;
        private Tube[] tubes;

        private float placeHeight;

        public event System.Action<TubeType, float> OnGetNewForm;

        private void Awake()
        {
            tubes = transform.GetComponentsInChildren<Tube>();
        }

        private float GetPlaceHeight(float x, float a, float b) // [-2; 2]
        { 
            return Mathf.Sin(x * a) + Mathf.Cos(x * b);
        }
        
        public override void BeforeRecycle()
        {
            
        }

        public override void OnRecycle()
        {
            placeHeight = GetPlaceHeight(Time.time, Random.Range(0f, 10f), Random.Range(0f, 10f));
            foreach (var tube in tubes)
                tube.SetHeight(placeHeight);
            AfterRecycle();
        }

        public override void AfterRecycle()
        {
            Debug.Log("OnAfterRecycle");
            coin.gameObject.SetActive(true);
            coin.transform.localPosition = new Vector3(0, placeHeight - 1f, 0);
        }
    }
}