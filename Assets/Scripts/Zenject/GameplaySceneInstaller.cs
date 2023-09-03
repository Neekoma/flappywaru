using Krevechous.Player;
using UnityEngine;
using YG;
using Zenject;

namespace Krevechous.Zenject
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private YandexGame _yaGame;
        [SerializeField] PlayerController _playerController;

        public override void InstallBindings()
        {
            Container.Bind<PlayerInputHandler>().FromNew().AsSingle();
            Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle();
            Container.Bind<YandexGame>().FromInstance(_yaGame).AsSingle();
        }
    }
}