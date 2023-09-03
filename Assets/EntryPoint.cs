using Krevechous.Localization;
using UnityEngine;
using YG;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private LocalizationManager _mg;

    [Inject]
    public void Construct(LocalizationManager mg, YandexGame yasdk)
    {
        _mg= mg;
    }

    private void Awake()
    {
        _mg.CheckStartupLanguage();
    }
}
