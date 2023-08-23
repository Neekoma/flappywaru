using UnityEngine;

public class Hider : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    public void Hide() {
        _animator.enabled = false;
    }
}
