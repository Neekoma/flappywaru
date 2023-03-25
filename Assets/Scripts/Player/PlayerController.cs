using UnityEngine;

namespace Krevechous
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D _rb;

        [SerializeField] private float jumpPower;

        private void Awake()
        {
            PlayerInput inputModule = GetPlayerInput();
            inputModule.onScreenJump.AddListener(Jump);
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.isKinematic = true;
        }

        public void AllowToMove() {
            Debug.Log("Game start"); _rb.isKinematic = false;
        }

        public void Jump()
        {
            if (_rb.isKinematic == false)
                _rb.velocity = Vector2.up * jumpPower;
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
