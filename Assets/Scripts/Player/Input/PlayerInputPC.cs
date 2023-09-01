using System;
using UnityEngine;

namespace Krevechous.Player.Inputs {

    public sealed class PlayerInputPC : IPlayerInput
    {
        public event Action OnClick;

        public void OnPlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                OnClick?.Invoke();
            }
        }
    }
}