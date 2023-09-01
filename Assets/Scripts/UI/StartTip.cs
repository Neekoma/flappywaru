using Krevechous.Core;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Krevechous.UI
{
    public class StartTip : MonoBehaviour, IResetable, IPointerDownHandler
    {
        [SerializeField] private TMP_Text _textObj;
        [SerializeField] private Animator _animator;

        private Vector3 _startPos;

        private NewGameManager _gm;

        public void ApplyDefaultState()
        {
            _textObj.enabled = true;
            _textObj.rectTransform.localPosition = _startPos;
            _animator.enabled = true;
            _animator.SetTrigger("Idle");
        }

        public void SaveDefaultState()
        {
            _startPos = _textObj.rectTransform.localPosition;
        }

        [Inject]
        public void Construct(NewGameManager gm) {
            _gm = gm;

            _gm.OnGameStart += Hide;
            _gm.OnGameReset += ApplyDefaultState;
        }

        public void Hide() {
            _animator.SetTrigger("Hide");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_gm.isGameStarted && !_gm.isGamePaused)
                _gm.StartGame();
        }
    }
}
