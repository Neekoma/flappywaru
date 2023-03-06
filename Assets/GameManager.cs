using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Krevechous
{
    public class GameManager : MonoBehaviour
    {
        [Header("Ивенты")]
        [Description("Вызывается когда игрок нажимает кнопку \"Начать игру\"")]
        public UnityEvent OnGameStart;
        [Description("Вызывается когда игрок нажимает проигрывает или завершает игру")]
        public UnityEvent OnGameEnd;
        [Description("Вызывается когда игрок нажимает паузу или сворачивает игру")]
        public UnityEvent OnGamePause;
        [Description("Вызывается когда игрок убирает паузу или разворачивает игру")]
        public UnityEvent OnGameResume;

        private void OnApplicationPause(bool pause)
        {
            if (pause)
                OnGamePause.Invoke();
            OnGameResume.Invoke();
        }

        public void StartGame()
        {
            OnGameStart.Invoke();
        }

        public void PauseGame()
        {
            OnGamePause.Invoke();
        }

        public void ResumeGame()
        {
            OnGameResume.Invoke();
        }

        public void EndGame()
        {
            OnGameEnd.Invoke();
        }

    }
}
