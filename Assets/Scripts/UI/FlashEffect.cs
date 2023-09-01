using System;
using UnityEngine;


namespace Krevechous.UI
{
    public class FlashEffect : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _cg;
        public static FlashEffect instance { get; private set; }
        public static event Action OnStarted;
        public static event Action OnComplete;

        private void Awake()
        {
            instance = this;
        }

        public void ShowFlash() {
            OnStarted?.Invoke();
            LeanTween.alphaCanvas(_cg, 1, .5f).setOnComplete(OnFadeRaiseComplete);
        }

        public void OnFadeRaiseComplete()
        {
            LeanTween.alphaCanvas(_cg, 0, .5f).setOnComplete(()=> { OnComplete?.Invoke(); });
        }
    }
}
