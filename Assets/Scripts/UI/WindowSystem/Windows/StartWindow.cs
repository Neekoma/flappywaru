using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Krevechous.Windows
{
    public class StartWindow : MenuWindow, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Pointer down");
        }
    }
}
