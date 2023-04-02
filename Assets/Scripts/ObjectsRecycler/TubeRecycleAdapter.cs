using Mono.Cecil.Cil;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{

    public sealed class TubeRecycleAdapter : MonoRecycleAdapter
    {
        [SerializeField] private Coin coin;

        private float placeHeight;

        //public event System.Action<TubeType, float> OnGetNewForm;

        private void Awake()
        {
            OnRecycle();
        }

        private float GetPlaceHeight(float x, float a, float b, float c) // [-3; 2]
        { 
            return (Mathf.Sin(x * a) * Mathf.Cos(x * b)) * c;
        }
        
        public override void BeforeRecycle()
        {
            
        }

        public override void OnRecycle()
        {
            placeHeight = GetPlaceHeight(Random.Range(-1000f, 1000f), Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(-2, 1));
            transform.position = new Vector3(transform.position.x, placeHeight, 0);
            AfterRecycle();
        }

        public override void AfterRecycle()
        {
            if (Random.Range(1, 7) == 1) { // 1/6
                if(coin != null) { }
                    coin.gameObject.SetActive(true);
            }
        }
    }
}