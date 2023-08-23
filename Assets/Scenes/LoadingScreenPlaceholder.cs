using System.Collections;
using UnityEngine;
using TMPro;

public class LoadingScreenPlaceholder : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private string _defaultText;

    private IEnumerator Start()
    {
        _defaultText = _text.text;
        do {
            for (byte i = 0; i < 3; i++) {
                _text.text += '.';
                yield return new WaitForSeconds(.5f);
            }
            _text.text = _defaultText;
        }
        while (true);
    }

}
