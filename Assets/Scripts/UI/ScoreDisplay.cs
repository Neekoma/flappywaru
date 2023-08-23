using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Krevechous {
    public class ScoreDisplay : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _text.text = "0";
        }

        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.OnGameStart.AddListener(() => { _text.enabled = true; });
            GameManager.Instance.OnGameEnd.AddListener(() => { _text.enabled = false; });
        }
    }
}
