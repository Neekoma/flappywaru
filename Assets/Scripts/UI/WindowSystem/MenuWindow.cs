using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Krevechous.Windows
{
    public abstract class MenuWindow : MonoBehaviour
    {
        [Header("Заголовок")]
        [Tooltip("Заголовок окна, отображающийся в рамке")]
        [SerializeField] private string _title;

        [SerializeField]
        [Tooltip("Показывает заголовок окна в рамке")]
        private bool _showTitle = false;
        [SerializeField] private RectTransform _titleObject;

        [Space(25)]
        [Header("Управление")]
        [SerializeField] private bool _closeable = false;
        [SerializeField] private MenuScreen _container;
        [SerializeField] private MenuWindowContent _content;
        private WindowState _state = WindowState.Closed;

        [Space(25)]
        [Header("События")]
        public UnityEvent<MenuWindow> OnWindowOpened;
        public UnityEvent<MenuWindow> OnWindowClosed;

        public string title => _title;
        public MenuScreen container => _container;
        public MenuWindowContent content => _content;
        public WindowState state => _state;
        public bool closeable => _closeable;

        /**<summary>Инициализирует компоненты окна при открытии. Использовать в Awake</summary>*/
        protected virtual void Initialize()
        {
            _titleObject.GetChild(0).GetComponent<TMP_Text>().text = _title;
            _titleObject.gameObject.SetActive(_showTitle);
        }

        public void Open(bool withMsg)
        {
            Initialize();
            if (withMsg == true)
            {
                OnWindowOpened?.Invoke(this);
            }
            _state = WindowState.Open;
            _content.gameObject.SetActive(true);
        }

        public void Close(bool withMsg)
        {
            if (withMsg == true)
            {
                OnWindowClosed?.Invoke(this);
            }
            _state = WindowState.Closed;
            _content.gameObject.SetActive(false);
        }
    }

    public enum WindowState { Closed, Open}
}
