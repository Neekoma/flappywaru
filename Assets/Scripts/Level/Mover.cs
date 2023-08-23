using UnityEngine;

namespace Krevechous {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour{
        private Rigidbody2D _rb;

        [SerializeField] private const float MOVE_SPEED = 2f;
        [SerializeField] private bool movingOnStart;

        private bool _isCanMove = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.isKinematic = true;
            _rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }

        private void Start()
        {
            GameManager.Instance.OnGameStart.AddListener(() => { _isCanMove = true; });
            GameManager.Instance.OnGameEnd.AddListener(() => { _isCanMove = false; });

            if (movingOnStart) { _isCanMove = true; }
        }


        private void FixedUpdate()
        {
            if (_isCanMove)
            {
                _rb.MovePosition((Vector2)transform.position + Vector2.left * MOVE_SPEED * Time.fixedDeltaTime);
            }
        }
    }
}