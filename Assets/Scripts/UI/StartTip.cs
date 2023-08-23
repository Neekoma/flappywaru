using Krevechous;
using UnityEngine;
using UnityEngine.EventSystems;


public class StartTip : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Animator animator;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameManager.Instance.IsGameStarted) // Если игра не запущена
        {
            animator.SetTrigger("Hide");
            GameManager.Instance.StartGame();
        }
    }
}
