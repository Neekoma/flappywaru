using Krevechous.ObjectsRecycler;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;


namespace Krevechous
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    public sealed class Coin : MonoBehaviour
    {
        public static Action OnCoinPicked;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == Tags.PLAYER_TAG)
            {
                OnCoinPicked?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}

