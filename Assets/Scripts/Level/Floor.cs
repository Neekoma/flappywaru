using Krevechous.Level;
using UnityEngine;

namespace Krevechous {
    public class Floor : MonoBehaviour, IMoveable
    {
        [SerializeField] private Rigidbody2D _rb;


        public void Move(Vector2 direction, float speed, float smoothnessDelta)
        {
            _rb.MovePosition((Vector2)transform.position + direction * speed * smoothnessDelta);
        }
    }
}