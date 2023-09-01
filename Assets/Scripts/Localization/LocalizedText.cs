using Krevechous.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace Krevechous.Localization
{
    public class LocalizedText : MonoBehaviour, ITextPlaceable
    {
        private LocalizationManager _manager;
        private Language _currentLang;

        [SerializeField] protected TMP_Text _text;

        [SerializeField] protected LocalizedString _strings;

        private void OnEnable()
        {
            _manager.OnLanguageChanged += ChangeLang;
            _currentLang = _manager.currentLanguage;
            ChangeLang(_currentLang);
        }

        private void OnDisable()
        {
            _manager.OnLanguageChanged -= ChangeLang;
        }

        [Inject]
        public void Construct(LocalizationManager manager) {
            _manager = manager;
            _currentLang = manager.currentLanguage;
        }


        private void ChangeLang(Language lang) {
            switch(lang)
            {
                case Language.Rus:
                    PlaceText(_strings.rusText);
                    break;
                case Language.Eng:
                    PlaceText(_strings.engText);
                    break;
                case Language.Turk:
                    PlaceText(_strings.turkText);
                    break;
            }
        }

        public virtual void PlaceText(string text)
        {
            _text.text = text;
        }
    }
}
