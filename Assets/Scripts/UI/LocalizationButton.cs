using Krevechous.Core;
using Krevechous.Localization;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class LocalizationButton : MonoBehaviour
{
    [SerializeField] private RawImage _renderer;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Texture[] _flags;

    private NewGameManager _gm;
    private LocalizationManager _localization;

    private void OnEnable()
    {
        ChangePictute(_localization.currentLanguage);
        _localization.OnLanguageChanged += ChangePictute;
        _gm.OnGameStart += Hide;
        _gm.OnGameReset += Show;
        
    }

    private void OnDisable()
    {
        _localization.OnLanguageChanged -= ChangePictute;
        _gm.OnGameStart -= Hide;
        _gm.OnGameReset -= Show;
    }

    [Inject]
    public void Construct(LocalizationManager _mgr, NewGameManager gm)
    {
        _localization = _mgr;
        _gm = gm;
    }

    public void OnClick()
    {
        if (!_gm.isGamePaused)
        {
            Language lang = (int)_localization.currentLanguage < Enum.GetValues(typeof(Language)).Length - 1 ? _localization.currentLanguage + 1 : 0;
            _localization.ChangeLanguage(lang);
            YandexGame.Instance._LanguageRequest();
        }
    }

    private void ChangePictute(Language lang) {
        _renderer.texture = _flags[(int) lang];
    }

    private void Hide() { _renderer.enabled = false; _text.enabled = false; }
    private void Show() { _renderer.enabled = true; _text.enabled = true; }

}
