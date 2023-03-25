using Krevechous.ObjectsRecycler;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Krevechous
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    public sealed class Coin : MonoBehaviour
    {
        public static Action OnCoinPicked;

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

