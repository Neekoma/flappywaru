using Krevechous.Core;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Krevechous.Player
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour, IResetable
    {
        private NewGameManager _gm;

        private Vector3 _defaultPosition;
        private bool _isReset = true;

        [SerializeField] private Animator _positionAnimator, _visualAnimator;
        [SerializeField] private Transform _visualTransform;
        [SerializeField] private float jumpPower;

        private Rigidbody2D _rb;
        private PlayerInputHandler _movementHandler;

        public UnityEvent OnJump;

        public Animator positionAnimator => _positionAnimator;
        public Animator visualAnimator => _visualAnimator;


        [Inject]
        public void Construct(NewGameManager gm, PlayerInputHandler movementHandler)
        {
            _gm = gm;
            _movementHandler = movementHandler;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.isKinematic = true;
            _defaultPosition = transform.position;
        }

        public void SaveDefaultState()
        {
            // Nothing to do...
        }

        public void ApplyDefaultState()
        {
            _isReset = false;
            _visualAnimator.SetTrigger("Idle");
            _rb.velocity = Vector2.zero;
            _rb.isKinematic = true;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.position = _defaultPosition;
            _positionAnimator.enabled = true;
            _isReset = true;
        }

        private void OnEnable()
        {
            _gm.OnGameStart += AllowToMove;
            _movementHandler.OnJump += Jump;
        }

        private void OnDisable()
        {
            _gm.OnGameStart -= AllowToMove;
            _movementHandler.OnJump -= Jump;
        }

        private void Update()
        {
            if (_isReset)
                _movementHandler.HandleMovementInputs();
        }

        public void OnDie()
        {
            _visualAnimator.SetTrigger("Die");
            _rb.constraints = RigidbodyConstraints2D.None;

        }

        public void AllowToMove()
        {
            _rb.isKinematic = false;
            _positionAnimator.enabled = false;
        }

        public void Jump()
        {
            if (_gm.isGameStarted && !_gm.isGamePaused)
            {
                if (transform.position.y < 5.5f)
                {
                    if (_rb.isKinematic == false)
                    {
                        _rb.velocity = Vector2.up * jumpPower;
                        OnJump?.Invoke();
                    }

                }
            }
        }
    }
}
