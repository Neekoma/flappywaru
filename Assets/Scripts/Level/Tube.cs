using Krevechous.Core;
using Krevechous.Level;
using Krevechous.NewRecycleSystem;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Krevechous
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Tube : MonoBehaviour, IMoveable, IResetable, IRecycleable
    {
        [SerializeField] private Rigidbody2D _rb;

        private NewGameManager _gm;
        public Rigidbody2D rb => _rb;

        private Vector3 defaultPosition;
        private bool _isPassed = false; // защита от двойного увеличения счета


        [Inject]
        public void Construct(NewGameManager gm)
        {
            _gm = gm;
        }

        private void OnEnable()
        {
            _gm.OnGameReset += ApplyDefaultState;

            SaveDefaultState();
        }

        private void OnDisable()
        {
            _gm.OnGameReset -= ApplyDefaultState;
        }


        public void Move(Vector2 direction, float speed, float smoothnessDelta)
        {
            _rb.MovePosition((Vector2)transform.position + direction * speed * smoothnessDelta);
        }

        public void SaveDefaultState()
        {
            defaultPosition = transform.position;
        }

        public void ApplyDefaultState()
        {
            transform.position = defaultPosition;
            _isPassed = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.PLAYER_TAG)
            {
                if (!_isPassed && _gm.isGameStarted)
                {
                    _gm.IncrementScore(1);
                    _isPassed = true;
                }
            }
        }

        public void OnRecycle()
        {
            _isPassed = false;
        }
    }
}