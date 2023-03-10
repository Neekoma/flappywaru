using UnityEngine;

namespace Krevechous
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D _rb;

        [SerializeField] private float forcePower;

        private void Awake()
        {
            PlayerInput inputModule;
            _rb = GetComponent<Rigidbody2D>();

#if PLATFORM_ANDROID
            inputModule = gameObject.AddComponent<PlayerInputMobile>();

#else
            inputModule = gameObject.AddComponent<PlayerInputMobile>();
#endif

            inputModule.onScreenJump.AddListener(Jump);
        }


        public void Jump()
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * forcePower, ForceMode2D.Impulse);
        }

    }
}