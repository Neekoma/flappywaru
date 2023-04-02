using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.AI;

namespace Krevechous
{

    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class Tube : MonoBehaviour
    {
        public static UnityEvent OnTubePassed = new UnityEvent();


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.PLAYER_TAG)
            {
                OnTubePassed?.Invoke();
            }
        }


    }

}