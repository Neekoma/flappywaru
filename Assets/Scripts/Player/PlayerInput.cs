using UnityEngine;
using UnityEngine.Events;

namespace Krevechous
{
    public abstract class PlayerInput : MonoBehaviour {

        [SerializeField] public UnityEvent onScreenJump = new UnityEvent();

        private void Update()
        {
            CheckInputs();
        }

        protected abstract void CheckInputs();
    }
}