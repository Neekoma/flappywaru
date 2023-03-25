using System.Collections;
using UnityEngine;

namespace Krevechous {
    public class TubeMover : MonoBehaviour {


        [SerializeField] private float _moveSpeed;

        private Coroutine _movingCoroutine;

        public void StartMoving() {
            _movingCoroutine = StartCoroutine(MovingCoroutine());
        }

        public void StopMoving() {
            if (_movingCoroutine != null)
            {
                StopCoroutine(_movingCoroutine);
                _movingCoroutine = null;
            }
        }

        private IEnumerator MovingCoroutine() {

            for (; ; ) {

                transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);

                yield return new WaitForEndOfFrame();            
            }
        }

    }
}