using Krevechous.Core;
using UnityEngine;
using YG;
using Zenject;

namespace Krevechous.UI
{
    public class RestartBtn : MonoBehaviour
    {
        private NewGameManager _gm;
        private static int _clicks = 0;


        [Inject]
        public void Construct(NewGameManager gm)
        {
            _gm = gm;
        }

        public void OnButtonPressed()
        {
            if (++_clicks % 5 == 0) {
                YandexGame.FullscreenShow();
            }

            _gm.ResetGame();
            FlashEffect.instance.ShowFlash();
        }
    }
}