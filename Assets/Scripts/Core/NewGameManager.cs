using Krevechous.Player;
using Krevechous.UI;
using System;
using YG;

namespace Krevechous.Core
{

    public sealed class NewGameManager : IScoreIncrementer
    {
        public bool isGameStarted { get; private set; } = false;
        public bool isGamePaused { get; private set; } = false;


        public event Action OnGameStart;
        public event Action OnGameEnd;
        public event Action OnGamePause;
        public event Action OnGameResume;

        public event Action OnGameReset;

        public event Action<int> OnScoreIncremented;


        private ScoreRepository _scoreRepository;


        public NewGameManager(ScoreRepository repository) {
            _scoreRepository = repository;
            YandexGame.StickyAdActivity(true);
        }

        public void StartGame()
        {
            isGameStarted = true;
            OnGameStart?.Invoke();
            YandexGame.StickyAdActivity(false);
        }

        public void EndGame()
        {
            isGameStarted = false;
            PauseGame();
            OnGameEnd?.Invoke();
            YandexGame.StickyAdActivity(true);
        }

        public void PauseGame()
        {
            isGamePaused = true;
            OnGamePause?.Invoke();
        }

        public void ResumeGame()
        {
            isGamePaused = false;
            OnGameResume?.Invoke();
        }

        public void ResetGame() {
            isGamePaused = true;
            FlashEffect.OnComplete += () => {
                isGamePaused= false;
                isGameStarted = false;
            };
            _scoreRepository.ResetRepository();
            OnGameReset?.Invoke();
        }

        public int GetCurrentScore() {
            return _scoreRepository.GetFromRepository();
        }

        public void IncrementScore(int value)
        {
            int score = _scoreRepository.PutToRepository(value);
            OnScoreIncremented?.Invoke(score);
        }
    }
}