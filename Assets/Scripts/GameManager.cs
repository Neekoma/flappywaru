using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Krevechous
{
    public sealed class GameManager : MonoBehaviour
    {
        //public static event Action OnGameStart;
        //public static event Action OnGameEnd;
        //public static event Action OnGamePause;
        //public static event Action OnGameResume;
        //public static event Action OnGameRestarted;


        public static GameManager Instance { get; private set; }

        public UnityEvent OnGameStart;
        public UnityEvent OnGameEnd;
        public UnityEvent OnGameRestart;

        public static event Action OnGameReady;
        public bool IsGameReady { get; private set; }


        private void Awake()
        {
            Instance = this;
        }

        public void StartGame()
        {
            OnGameStart.Invoke();
        }

        public void StartGame(AsyncOperation op) {
            Debug.Log("StartGameReset");
            if(op.isDone)
                OnGameStart.Invoke();
        }

        public void EndGame()
        {
            OnGameEnd.Invoke();
        }

        public void RestartGame()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            op.completed += StartGame;
            OnGameRestart.Invoke();
        }

    }
}
