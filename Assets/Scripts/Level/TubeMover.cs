using System.Collections;
using UnityEngine;


namespace Krevechous {
    public class TubeMover : MonoBehaviour {


        [SerializeField] private float _moveSpeed;

        private void Awake()
        {
            GameManager.OnGameStart += StartMoving;
            GameManager.OnGamePause += StopMoving;
        }

        public void StartMoving() {
            StartCoroutine(MovingCoroutine());
        }

        public void StopMoving() { }

        private IEnumerator MovingCoroutine() {

            for (; ; ) {

                transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);

                yield return new WaitForEndOfFrame();            
            }
        }

    }

}