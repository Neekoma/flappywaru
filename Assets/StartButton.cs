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
        button = GetComponent<Button>();
        button.enabled = false;
        GameManager.OnGameReady += () =>
        {
            if(button != null)
                button.enabled = true;
        };
    }
}
