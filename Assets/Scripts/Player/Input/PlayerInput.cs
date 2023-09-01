using System;

namespace Krevechous.Player.Inputs
{
    public interface IPlayerInput
    {
        public event Action OnClick;

        public void OnPlayerInput();
    }
}