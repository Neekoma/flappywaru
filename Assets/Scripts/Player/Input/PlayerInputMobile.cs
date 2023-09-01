using System;
using UnityEngine;

namespace Krevechous.Player.Inputs
{

    public sealed class PlayerInputMobile : IPlayerInput
    {
        public event Action OnClick;

        public void OnPlayerInput()
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    OnClick?.Invoke();
                }
            }
        }
    }
}