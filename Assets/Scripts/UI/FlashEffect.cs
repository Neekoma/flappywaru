using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Krevechous
{
    [RequireComponent(typeof(Image))]
    public class FlashEffect : GamePipelineAnimation
    {
        private static FlashEffect _instance;

        public static FlashEffect Instance => _instance;

        [SerializeField] private Image _image;
        [SerializeField] private float _duration; // 0.1

        [Range(0.001f, 1f)]
        [SerializeField]
        private float _smoothness; // 0.01

        public UnityEvent OnFirstStepEnd;
   
        [Range(0.1f, 1f)]
        private float _maxValue = 1;

        private float _steps;
        private float _delta;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
            _steps = _duration / _smoothness; // 10
            _delta = _maxValue / _steps;
        }

        private void Start()
        {
            GameManager.Instance.OnGameEnd.AddListener(() => {Show(_duration, true, false); });
        }

        public void Show(float duration, bool twoSteps, bool startWithSecond) {
            StartCoroutine(ShowFlash(duration, twoSteps, startWithSecond));
        }

        private IEnumerator ShowFlash(float duration, bool twoSteps, bool startWithSecond) {
            float deltaT = duration / _steps;
            float value = startWithSecond == false ? 0 : 1;
            
            if (!startWithSecond)
            {
                while (value < 1)
                {
                    value += _delta;
                    _image.color = new Color(0, 0, 0, value);
                    yield return new WaitForSeconds(deltaT);
                }

                OnFirstStepEnd?.Invoke();
            }
            
            if (twoSteps || startWithSecond)
            {
                while (value > 0)
                {
                    value -= _delta;
                    _image.color = new Color(0, 0, 0, value);
                    yield return new WaitForSeconds(deltaT);
                }
            }

            OnAnimEnd?.Invoke();
        }
    }
}
