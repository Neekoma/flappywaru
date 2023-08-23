using TMPro;
using UnityEngine;

namespace Krevechous
{

    public sealed class PlayerRepository : MonoBehaviour
    {
        private static PlayerRepository _instance;
        public static PlayerRepository Instance => _instance;
        
        [SerializeField] private TMP_Text text;

        public int coins { get; private set; }
        public int score { get; private set; }

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            GameManager.Instance.OnGameEnd.AddListener(() =>
            {
                var prevScore = PlayerPrefs.GetInt("Score", 0);
                var storedCoins = PlayerPrefs.GetInt("Coins", 0);
                coins += storedCoins;
                PlayerPrefs.SetInt("Coins", coins);
                if (score > prevScore)
                {
                    PlayerPrefs.SetInt("Score", score);
                }
                PlayerPrefs.Save();
            });
            Tube.OnTubePassed.AddListener(() =>
            {
                score++;
                text.text = score.ToString();
            });
            Coin.OnCoinPicked.AddListener(() =>
            {
                coins++;
                Debug.Log($"Coins: {coins}");
            });
        }
    }
}