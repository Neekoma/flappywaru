using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krevechous
{
    public class RestartBtn : MonoBehaviour
    {
        public void OnButtonPressed()
        {
            FlashEffect.Instance.Show(1, false, true);
        }
    }
}