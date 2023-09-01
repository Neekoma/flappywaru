using Krevechous.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

namespace Krevechous.UI
{
    public class RestartBtn : MonoBehaviour
    {
        private NewGameManager _gm;

        [Inject]
        public void Construct(NewGameManager gm)
        {
            _gm = gm;
        }

        public void OnButtonPressed()
        {
            _gm.ResetGame();
            FlashEffect.instance.ShowFlash();
        }
    }
}