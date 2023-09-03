using Krevechous.Core;
using System;
using YG;


namespace Krevechous.Localization
{
    public class LocalizationManager
    {
        public Language currentLanguage { get; private set; }

        public event Action<Language> OnLanguageChanged;

        private SaveManager _saves;

        public LocalizationManager(SaveManager saves)
        {
            _saves = saves;
        }

        public void CheckStartupLanguage()
        {
            int savedLanguage = _saves.LoadLanguage();

            if (savedLanguage == -1)
            {
                string playerLanguage = YandexGame.EnvironmentData.language;

                switch (playerLanguage)
                {
                    case "ru":
                        currentLanguage = Language.Rus;
                        break;
                    case "tr":
                        currentLanguage = Language.Turk;
                        break;
                    case "en":
                        currentLanguage = Language.Eng;
                        break;
                    default:
                        currentLanguage = Language.Rus;
                        break;
                }
            }
            else
                currentLanguage = (Language) savedLanguage;

            ChangeLanguage(currentLanguage, withSave: false);
        }

        public void ChangeLanguage(Language lang, bool withSave = true)
        {
            currentLanguage = lang;

            if (withSave)
                _saves.SaveLanguage(lang);

            OnLanguageChanged?.Invoke(lang);
        }
    }

    public enum Language { Rus, Eng, Turk }
}