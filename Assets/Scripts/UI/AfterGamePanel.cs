using Krevechous;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private TMP_Text _currentScoreDisp, _bestScoreDisp;

    private AfterGamePanel _instance;

    public AfterGamePanel Instance => _instance;

    public int bestScoreVal { get; set; }


    private void Awake()
    {
        _instance = this;
    }

    public void ShowAfterGame() {
        bestScoreVal = PlayerPrefs.GetInt("Score");
        _bestScoreDisp.text = bestScoreVal.ToString();
        _currentScoreDisp.text = PlayerRepository.Instance.score.ToString();
        _container.SetActive(true);
    }
}
