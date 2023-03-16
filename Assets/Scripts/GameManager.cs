using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Krevechous
{
    public sealed class GameManager : MonoBehaviour
    {
        public static event Action OnGameStart;
        public static event Action OnGameEnd;
        public static event Action OnGamePause;
        public static event Action OnGameResume;

        public bool IsGameReady { get; private set; }
        public event Action OnGameReady;

        private void Awake()
        {
            TubesPool.OnTubesReady += () => { IsGameReady = true; OnGameReady?.Invoke(); };
        }

        private void Start() // TODO: старт по кнопке
        {
            OnGameReady += () => { OnGameStart?.Invoke(); };
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
