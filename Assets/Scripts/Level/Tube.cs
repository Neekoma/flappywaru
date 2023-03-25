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

       
    }

}