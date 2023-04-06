using Krevechous;
using UnityEngine;
using UnityEngine.EventSystems;


public class StartTip : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Animator animator;

    private bool isReady = false;

    private void Start()
    {
        GameManager.OnGameReady += () =>
        {
            isReady = true;
        };
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        animator.SetTrigger("Hide");
        GameManager.Instance.StartGame();
    }
}
