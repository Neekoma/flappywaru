using Krevechous.Localization;
using Krevechous.Player;
using UnityEngine;
using Zenject;

namespace Krevechous.Zenject
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] PlayerController _playerController;

        public override void InstallBindings()
        {
            Container.Bind<Player.PlayerInputHandler>().FromNew().AsSingle();
            Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle();
        }
    }
}
