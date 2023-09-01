using UnityEngine;
using TMPro;
using Krevechous.Core;
using Zenject;

namespace Krevechous {
    public class ScoreDisplay : MonoBehaviour
    {
        private NewGameManager _gm;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _text.text = "0";
            _text.enabled = false;
        }

        [Inject]
        public void Construct(NewGameManager gm) {
            _gm = gm;
        }

        private void OnEnable()
        {
            _gm.OnGameStart += Show;
            _gm.OnGameEnd += Hide;
            _gm.OnGameReset += ResetScore;
            _gm.OnScoreIncremented += ChangeScore;
        }

        private void OnDisable()
        {
            _gm.OnGameStart -= Show;
            _gm.OnGameEnd -= Hide;
            _gm.OnGameReset -= ResetScore;
            _gm.OnScoreIncremented -= ChangeScore;
        }

        private void ChangeScore(int score) {
            _text.text = score.ToString();
        }

        private void ResetScore() {
            _text.text = "0";
        }

        private void Hide() {
            _text.enabled = false;
        }
        private void Show() {
            _text.enabled = true;
        }
    }
}
