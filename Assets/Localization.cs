using UnityEngine;
using TMPro;

public class Localization : MonoBehaviour
{
    [SerializeField] private TMP_Text _startTip;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private TMP_Text _okBtn;

    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.Russian) {
            _startTip.text = "Click to fly";
            _currentScore.text = "Score";
            _bestScore.text = "Best";
            _okBtn.text = "OK";
        }    
    }
}
