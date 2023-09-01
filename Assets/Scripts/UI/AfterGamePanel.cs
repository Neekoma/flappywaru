using Krevechous.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace Krevechous.UI
{
    public class AfterGamePanel : MonoBehaviour, IResetable
    {
        [SerializeField] private GameObject _okBtn;

        private NewGameManager _gm;
        private SaveManager _saveManager;

        [SerializeField] private GameObject _container;
        [SerializeField] private TMP_Text _currentScoreDisp, _bestScoreDisp;


        [Inject]
        public void Construct(NewGameManager gm, SaveManager saveManager) {
            _gm = gm;
            _saveManager = saveManager;
        }

        public void SaveDefaultState()
        {
               
        }

        public void ApplyDefaultState()
        {
            transform.localScale = Vector3.zero;
            _okBtn.transform.localScale = Vector3.zero;
            _container.SetActive(false);
        }


        private void OnEnable()
        {
            _gm.OnGameEnd += ShowAfterGame;
            _gm.OnGameReset += ApplyDefaultState;
        }

        private void OnDisable()
        {
            _gm.OnGameEnd -= ShowAfterGame;
            _gm.OnGameReset -= ApplyDefaultState;
        }

        public void ShowAfterGame()
        {
            int bestScore = _saveManager.LoadBestScore();
            int currentScore = _gm.GetCurrentScore();

            if(currentScore > bestScore)
            {
                _saveManager.SaveBestScore(currentScore);
                bestScore = currentScore;
            }

            _bestScoreDisp.text = bestScore.ToString();
            _currentScoreDisp.text = currentScore.ToString();
            _container.SetActive(true);
            LeanTween.scale(gameObject, new Vector3(1, 1, 1), .75f).setEaseOutBounce().setOnComplete(ShowOkBtn);
        }

        private void ShowOkBtn() {
            LeanTween.scale(_okBtn, new Vector3(1, 1, 1), .35f).setEaseInExpo();
        }

       
    }
}
