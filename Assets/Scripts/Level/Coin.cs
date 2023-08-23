using UnityEngine.Events;
using UnityEngine;
using UnityEditor;

namespace Krevechous
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class Coin : MonoBehaviour
    {
        public static UnityEvent OnCoinPicked = new UnityEvent();

        
    }
}

