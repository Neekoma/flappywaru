using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Krevechous
{
    public sealed class GameManager : MonoBehaviour
    {
        #region AD
        [DllImport("__Internal")]
        private static extern void ShowBlockAd();

        private static int playsCount = 0; // сколько раз игрок перезапускал игру
        #endregion

        public static GameManager Instance { get; private set; }

        public UnityEvent OnGameStart;
        public UnityEvent OnGameEnd;
        public UnityEvent OnGameRestart;
        public UnityEvent OnGameRestarted;

        public bool isPlaying { get; private set; } = true;

        public bool IsGameStarted { get; private set; }
        public bool IsGameReady { get; private set; }


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            if (playsCount++ % 4 == 0)
            {
                ShowBlockAd();
            }
        }

        public void StartGame()
        {
            IsGameStarted = true;
            isPlaying = true;
            OnGameStart.Invoke();
        }

        public void StartGame(AsyncOperation op) {
            if (op.isDone)
            {
                OnGameRestarted?.Invoke();
                isPlaying = true;
                OnGameStart.Invoke();
            }
        }

        public void EndGame()
        {
            isPlaying = false;
            OnGameEnd.Invoke();
        }

        public void RestartGame()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            op.completed += StartGame;
            OnGameRestart?.Invoke();
        }

    }
}
