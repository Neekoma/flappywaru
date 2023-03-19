using UnityEditor.TextCore.Text;
using UnityEngine;

namespace Krevechous
{

    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class Tube : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private BoxCollider2D _collider;

        private bool isLower = false;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();

            if (transform.position.y < 0) isLower = true;
        }


        public void SetHeight(float y) { 
            if (isLower)
                _renderer.size = new Vector2(1, Mathf.Abs(transform.position.y + 1 - y + 0.8f) * 2); //14
            else
               _renderer.size = new Vector2(1, Mathf.Abs(-transform.position.y - 1 + y + 0.8f) * 2);

            _collider.size = new Vector2(1, _renderer.size.y);
        }
    }

}