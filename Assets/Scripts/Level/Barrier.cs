using System;
using UnityEngine;
using UnityEngine.Events;

namespace Krevechous {
    public class Barrier: MonoBehaviour, IResetable
    {
        public static UnityEvent OnBarrierTouched = new UnityEvent();

        public void Reset(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        public void SaveStartState()
        {
            throw new NotImplementedException();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (GameManager.Instance.isPlaying)
            {
                if (collision.gameObject.tag == Tags.PLAYER_TAG)
                {
                    OnBarrierTouched?.Invoke();
                    GameManager.Instance.EndGame();
                }
            }
        }

    }

}