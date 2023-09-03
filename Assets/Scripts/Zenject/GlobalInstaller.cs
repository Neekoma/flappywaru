using Krevechous.Core;
using Krevechous.Localization;
using Krevechous.Player;
using Krevechous.Player.Inputs;
using UnityEngine;
using Zenject;


namespace Krevechous.Zenject
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            if (Application.isMobilePlatform)
                Container.Bind<IPlayerInput>().To<PlayerInputMobile>().FromNew().AsSingle();
            else
                Container.Bind<IPlayerInput>().To<PlayerInputPC>().FromNew().AsSingle();

            Container.Bind<ScoreRepository>().FromNew().AsSingle();
            Container.Bind<SaveManager>().FromNew().AsSingle();
            Container.Bind<LocalizationManager>().FromNew().AsSingle();
            Container.Bind<NewGameManager>().FromNew().AsSingle();
        }
    }
}