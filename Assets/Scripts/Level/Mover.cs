using System.Collections;
using UnityEngine;

namespace Krevechous {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour{
        private Rigidbody2D _rb;

        [SerializeField] private const float MOVE_SPEED = 2f;
        [SerializeField] private bool movingOnStart;

        private Coroutine _movingCoroutine;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.isKinematic = true;
            _rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }

        private void Start()
        {
            if (!movingOnStart)
            {
                GameManager.Instance.OnGameStart.AddListener(() =>
                {
                    StartMoving();
                });
            }
            else {
                StartMoving();
            }
            GameManager.Instance.OnGameEnd.AddListener(() => {
                StopMoving();
            });
        }

        public void StartMoving()
        {
            _movingCoroutine = StartCoroutine(MovingCoroutine());
        }

        public void StopMoving()
        {
            if (_movingCoroutine != null)
            {
                StopCoroutine(_movingCoroutine);
                _movingCoroutine = null;
            }
        }

        private IEnumerator MovingCoroutine()
        {

            for (; ; )
            {
                _rb.MovePosition(Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.left, MOVE_SPEED * Time.fixedDeltaTime));
                yield return new WaitForFixedUpdate();
            }
        }
    }
}