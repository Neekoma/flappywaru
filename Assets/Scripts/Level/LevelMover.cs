using System.Collections;
using UnityEngine;


namespace Krevechous {
    public class LevelMover : MonoBehaviour {
        [SerializeField] TubesPool _pool;

        [SerializeField] private float _moveSpeed;

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