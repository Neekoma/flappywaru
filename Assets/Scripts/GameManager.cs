using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace Krevechous
{
    public sealed class GameManager : MonoBehaviour
    {
        public static event Action OnGameStart;
        public static event Action OnGameEnd;
        public static event Action OnGamePause;
        public static event Action OnGameResume;

        private void Start() // TODO: старт по кнопке
        {
            OnGameStart.Invoke();
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
                OnGamePause?.Invoke();

            OnGameResume?.Invoke();
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
