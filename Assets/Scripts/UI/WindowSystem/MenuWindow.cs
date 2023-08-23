using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Krevechous.Windows
{
    public abstract class MenuWindow : MonoBehaviour
    {
        [Header("���������")]
        [Tooltip("��������� ����, �������������� � �����")]
        [SerializeField] private string _title;

        [SerializeField]
        [Tooltip("���������� ��������� ���� � �����")]
        private bool _showTitle = false;
        [SerializeField] private RectTransform _titleObject;

        [Space(25)]
        [Header("����������")]
        [SerializeField] private bool _closeable = false;
        [SerializeField] private MenuScreen _container;
        [SerializeField] private MenuWindowContent _content;
        private WindowState _state = WindowState.Closed;

        [Space(25)]
        [Header("�������")]
        public UnityEvent<MenuWindow> OnWindowOpened;
        public UnityEvent<MenuWindow> OnWindowHidden;
        public UnityEvent<MenuWindow> OnWindowClosed;

        public string title => _title;
        public MenuScreen container => _container;
        public MenuWindowContent content => _content;
        public WindowState state => _state;
        public bool closeable => _closeable;

        /**<summary>�������������� ���������� ���� ��� ��������. ������������ � Awake</summary>*/
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
                _container.ChangeWindow(this);
                OnWindowOpened?.Invoke(this);
            }
            _content.gameObject.SetActive(true);
        }
        public void Hide()
        {
            _container.HideWindow(this);
            OnWindowHidden?.Invoke(this);
        }
        public void Close(bool withMsg)
        {
            if (withMsg == true)
            {
                _container.CloseWindow(this);
                OnWindowClosed?.Invoke(this);
            }
            _content.gameObject.SetActive(false);
        }
    }

    public enum WindowState { Closed, Open, Hidden }
}
