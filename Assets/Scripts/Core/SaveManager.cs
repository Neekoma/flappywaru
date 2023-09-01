using Krevechous.Localization;
using UnityEngine;
using YG;

namespace Krevechous.Core
{
    public class SaveManager
    {
        public void SaveLanguage(Language language) {
            PlayerPrefs.SetInt("Language", (int)language);
        }

        public int LoadLanguage()
        {
            return PlayerPrefs.GetInt("Language", -1);
        }

        public void SaveBestScore(int score) {
            YandexGame.savesData.bestScore = score;
            YandexGame.SaveProgress();
        }

        public int LoadBestScore() {
            int bestScore = YandexGame.savesData.bestScore;
            return bestScore;
        }
    }

}