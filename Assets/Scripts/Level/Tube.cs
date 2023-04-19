using Krevechous.NewRecycleSystem;
using System.Runtime.CompilerServices;
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

        public bool _isPassed { get; set; } = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isPassed == false)
            {
                if (collision.gameObject.tag == Tags.PLAYER_TAG)
                {
                    _isPassed = true;
                    OnTubePassed?.Invoke();
                }
            }
        }
    }
}