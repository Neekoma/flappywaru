using Krevechous;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button.enabled = false;
        GameManager.OnGameReady += () =>
        {
            button.enabled = true;
        };
    }
}
