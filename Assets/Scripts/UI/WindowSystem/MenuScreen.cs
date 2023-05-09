using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace Krevechous.Windows
{

    public class MenuScreen : MonoBehaviour
    {

        /**<summary>Первое окно в иерархии по умолчанию явлется стартовым</summary>*/
        private MenuWindow _startWindow;

        private MenuWindow[] _windows;
        private MenuWindow _currentWindow;

        private LinkedList<MenuWindow> _sequence = new LinkedList<MenuWindow>();

        private void Awake()
        {
            _windows = GetComponentsInChildren<MenuWindow>();
            _startWindow = _windows[0];
            _sequence.AddLast(_startWindow);
        }

        private void Start()
        {
            _currentWindow = _startWindow;
            for (int i = 1; i < transform.childCount; i++)
                _windows[i].Close(false);
            _windows[0].Open(false);
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
                ChangeWindow(_windows[1], false);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                ChangeWindow(_windows[2], false);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Back();
            }
        }

        public void ChangeWindow(MenuWindow window, bool isBack)
        {
            var last = _sequence.Last.Value;
            
            if (isBack)
            {
                if (_sequence.Count == 1)
                    return;

                    _sequence.RemoveLast();
            }
            else
                _sequence.AddLast(window);

            last.Close(true);
            _sequence.Last.Value.Open(true);
        }

        public void CloseWindow(MenuWindow window)
        {
            Debug.Log($"Закрыть окно {window.title}");

        }

        public void Back()
        {
            ChangeWindow(null, true);
        }

        public void ToStart()
        {

        }

        public void HideScreen()
        {
        }
    }
}