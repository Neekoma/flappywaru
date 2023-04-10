using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Krevechous
{
    [RequireComponent(typeof(Image))]
    public class FlashEffect : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _duration; // 0.1

        [Range(0.001f, 1f)]
        [SerializeField]
        private float _smoothness; // 0.01

        public UnityEvent OnFirstStepEnd;
        public UnityEvent OnAnimEnd;
   
        [Range(0.1f, 1f)]
        private float _maxValue = 1;

        private float _steps;
        private float _delta;

        private void Awake()
        {
            _steps = _duration / _smoothness; // 10
            _delta = _maxValue / _steps;
        }

        private void Start()
        {
            GameManager.Instance.OnGameEnd.AddListener(() => { StartCoroutine(ShowFlash(_duration)); });
            GameManager.Instance.OnGameRestart.AddListener(() => { StartCoroutine(ShowFlash(_duration)); });
        }

        private IEnumerator ShowFlash(float duration) {
            float deltaT = duration / _steps;
            float value = 0;
            while (value < 1) {
                value += _delta;
                _image.color = new Color(0,0,0, value);
                yield return new WaitForSeconds(deltaT);
            }
            OnFirstStepEnd?.Invoke();
            while (value > 0)
            {
                value -= _delta;
                _image.color = new Color(0, 0, 0, value);
                yield return new WaitForSeconds(deltaT);
            }
            OnAnimEnd?.Invoke();
        }
    }
}
