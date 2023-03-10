using UnityEngine;

namespace Krevechous {

    public sealed class PlayerInputMobile : PlayerInput
    {
        protected override void CheckInputs()
        {
            if (Input.touchCount > 0) {
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    onScreenJump.Invoke();
                }
            }
        }
    }
}