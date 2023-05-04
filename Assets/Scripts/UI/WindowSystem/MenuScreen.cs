using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Krevechous.Windows {

    public class MenuScreen : MonoBehaviour {

        /**<summary>Первое окно в иерархии по умолчанию явлется стартовым</summary>*/
        private MenuWindow _startWindow;
        
        private MenuWindow[] _windows;
        private MenuWindow _currentWindow;

        private Stack<MenuWindow> _windowSequence;

        private void Awake()
        {
            _windows = GetComponentsInChildren<MenuWindow>();
            _startWindow = _windows[0];
        }

        private void Start()
        {
            _currentWindow = _startWindow;
            for (int i = 1; i < transform.childCount; i++)
                _windows[i].Close(false);
            _windows[0].Open(false);
        }

        public void ChangeWindow(MenuWindow window) {
            Debug.Log($"Окно меняется на {window.title}");
        }

        public void HideWindow(MenuWindow window) {
            Debug.Log($"Скрыть окно {window.title}");
        }
        
        public void CloseWindow(MenuWindow window) {
            Debug.Log($"Закрыть окно {window.title}");
        }
    }
}