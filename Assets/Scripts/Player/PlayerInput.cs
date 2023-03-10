using UnityEngine;
using UnityEngine.Events;
namespace Krevechous
{
    public abstract class PlayerInput : MonoBehaviour {

        [SerializeField] private UnityEvent onScreenJump;

        private void Update()
        {
            CheckInputs();
        }

        protected abstract void CheckInputs();
    }
}