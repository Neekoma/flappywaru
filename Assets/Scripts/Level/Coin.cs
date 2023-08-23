using UnityEngine.Events;
using UnityEngine;
using UnityEditor;

namespace Krevechous
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class Coin : MonoBehaviour
    {
        public static UnityEvent OnCoinPicked = new UnityEvent();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.PLAYER_TAG)
            {
                OnCoinPicked?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}

