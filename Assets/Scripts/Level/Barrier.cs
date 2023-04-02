using UnityEngine;
namespace Krevechous {
    public class Barrier: MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.tag == Tags.PLAYER_TAG)
            {
                GameManager.Instance.RestartGame();
            }
        }

    }

}