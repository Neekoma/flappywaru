using UnityEngine;

namespace Krevechous {

    public sealed class PlayerInputPC : PlayerInput
    {
        protected override void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                onScreenJump.Invoke();           
            }
        }
    }
}