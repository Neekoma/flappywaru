using UnityEngine;

namespace Krevechous {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour{

        private Rigidbody2D _rb;

        [SerializeField] private float forcePower;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }


        public void Jump() {
            _rb.AddForce(Vector2.up * forcePower, ForceMode2D.Impulse);
        
        }

    }
}