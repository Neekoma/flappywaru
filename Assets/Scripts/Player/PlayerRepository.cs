using TMPro;
using UnityEngine;

namespace Krevechous {

    public sealed class PlayerRepository :MonoBehaviour {
        [SerializeField] private TMP_Text text;

        [SerializeField] public int Coins = 0;
        [SerializeField] public int Score = 0;

        private void Start()
        {
            Tube.OnTubePassed.AddListener(() => {
                Score++;
                text.text = Score.ToString();
            });
            Coin.OnCoinPicked.AddListener(() => {
                Coins++;
                Debug.Log($"Coins: {Coins}");
            });
        }
    }
}