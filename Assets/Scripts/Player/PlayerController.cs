using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Krevechous
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        private static PlayerController _instance;
        public static PlayerController Instance => _instance;

        public static UnityEvent OnJump = new UnityEvent();

        private Rigidbody2D _rb;
        [SerializeField] private Animator _animator, _visualAnimator;

        [SerializeField] private Transform _visualTransform;
        [SerializeField] private float jumpPower;

        private Vector3 _upRotation = new Vector3(0, 0, 20);

        private void Awake()
        {
            _instance = this;
            _rb = GetComponent<Rigidbody2D>();
            GetPlayerInput().onScreenJump.AddListener(Jump);
        }

        private void Start()
        {
            GameManager.Instance.OnGameEnd.AddListener(() => {
                _visualAnimator.SetTrigger("Die");
            });
            _rb.isKinematic = true;
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance.isPlaying)
            {
                if (_rb.velocity.y > 0)
                {
                    _visualTransform.rotation = Quaternion.Euler(_upRotation);
                }
                else
                {
                    _visualTransform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(_rb.velocity.y * 2, -100, 0)));
                }
            }
        }

        public void AllowToMove() {
           _rb.isKinematic = false;
        }
        
        public void Jump()
        {
            if (GameManager.Instance.isPlaying)
            {
                if (transform.position.y < 5.5f)
                {
                    if (_rb.isKinematic == false)
                    {
                        OnJump?.Invoke();
                        _rb.velocity = Vector2.up * jumpPower;
                    }
                }
            }
        }

        /** <summary>Выбор управления в соответствии с управлением и добавление компонента на объект</summary>*/
        private PlayerInput GetPlayerInput()
        {

            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                Debug.Log("Выбрана схема: Mobile");
                return gameObject.AddComponent<PlayerInputMobile>();
            }
            else
            {
                Debug.Log("\"Выбрана схема: Desktop");
                return gameObject.AddComponent<PlayerInputPC>();
            }
        }
    }
}
