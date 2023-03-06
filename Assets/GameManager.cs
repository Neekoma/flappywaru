using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Krevechous
{
    public class GameManager : MonoBehaviour
    {
        [Header("������")]
        [Description("���������� ����� ����� �������� ������ \"������ ����\"")]
        public UnityEvent OnGameStart;
        [Description("���������� ����� ����� �������� ����������� ��� ��������� ����")]
        public UnityEvent OnGameEnd;
        [Description("���������� ����� ����� �������� ����� ��� ����������� ����")]
        public UnityEvent OnGamePause;
        [Description("���������� ����� ����� ������� ����� ��� ������������� ����")]
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
