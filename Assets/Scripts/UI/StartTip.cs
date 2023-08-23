using Krevechous;
using UnityEngine;
using UnityEngine.EventSystems;


public class StartTip : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Animator animator;

    public void Hide() {
        if (!GameManager.Instance.IsGameStarted) // ���� ���� �� ��������
        {
            animator.SetTrigger("Hide");
            GameManager.Instance.StartGame();
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Hide();
    }
}
