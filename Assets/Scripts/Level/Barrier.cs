using UnityEngine;
namespace Krevechous {
    public class Barrier: MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (GameManager.Instance.isPlaying)
            {
                if (collision.gameObject.tag == Tags.PLAYER_TAG)
                {
                    GameManager.Instance.EndGame();
                }
            }
        }

    }

}