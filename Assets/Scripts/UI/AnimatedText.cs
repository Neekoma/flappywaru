using Krevechous.Core;
using Krevechous.Localization;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Krevechous.UI
{
    public class AnimatedText : LocalizedText
    {
        private NewGameManager _gm;

        [SerializeField] private float _textSpeed;

        private bool _isSkipped = false;
        private Coroutine _coroutine;

        [Inject]
        public void Construct(NewGameManager gm)
        {
            _gm = gm;
            _gm.OnGameStart += SkipPlacingText;
        }

        private void OnDestroy()
        {
            _gm.OnGameStart -= SkipPlacingText;
        }

        public override void PlaceText(string text)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(PlaceTextCoroutine(text));
        }

        public void SkipPlacingText()
        {
            _isSkipped = true;
        }

        private IEnumerator PlaceTextCoroutine(string text)
        {
            Debug.Log(text);
            _text.text = "";

            for (int i = 0; i < text.Length; i++)
            {
                _text.text += text[i];
                if (_isSkipped == false)
                    yield return new WaitForSeconds(_textSpeed);

            }
            _isSkipped = false;
        }
    }
}
