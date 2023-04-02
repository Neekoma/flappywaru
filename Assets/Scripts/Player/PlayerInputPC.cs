using UnityEngine;

namespace Krevechous {

    public sealed class PlayerInputPC : PlayerInput
    {
        protected override void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
                onScreenJump.Invoke();
            }
        }
    }
}