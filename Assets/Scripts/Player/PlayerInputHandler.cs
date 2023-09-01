using Krevechous.Core;
using Krevechous.Player.Inputs;
using Krevechous.UI;
using System;

namespace Krevechous.Player
{
    public class PlayerInputHandler : IDisposable
    {
        private NewGameManager _gm;
        private IPlayerInput _input;

        public event Action OnJump;

        bool enabled = true;

        public PlayerInputHandler(NewGameManager gm, IPlayerInput input)
        {
            _input = input;
            _gm = gm;

            _input.OnClick += OnClick;

            FlashEffect.OnStarted += () => enabled = false;
            FlashEffect.OnComplete += () => enabled = true;
        }

        public void HandleMovementInputs()
        {
            if(enabled)
                _input.OnPlayerInput();
        }

        private void OnClick()
        {
            if (!_gm.isGamePaused)
            {
                if(_gm.isGameStarted)
                    OnJump?.Invoke();
            }
        }

        public void Dispose()
        {
            _input.OnClick -= OnClick;
        }
    }
}