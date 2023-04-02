﻿using Unity.VisualScripting;
using UnityEngine;

namespace Krevechous
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D _rb;
        private Animator _animator;

        [SerializeField] private float jumpPower;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            PlayerInput inputModule = GetPlayerInput();
            inputModule.onScreenJump.AddListener(Jump);
        }

        private void Start()
        {
            _rb.isKinematic = true;
        }

        public void AllowToMove() {
            _animator.enabled = false; // TODO: replace with animations
           _rb.isKinematic = false;
        }

        public void Jump()
        {
            if (_rb.isKinematic == false)
                _rb.velocity = Vector2.up * jumpPower;
        }

        /** <summary>Выбор управления в соответствии с управлением и добавление компонента на объект</summary>*/
        private PlayerInput GetPlayerInput()
        {

            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                Debug.Log("Выбрана схема: Mobile");
                return gameObject.AddComponent<PlayerInputMobile>();
            }
            else
            {
                Debug.Log("\"Выбрана схема: Desktop");
                return gameObject.AddComponent<PlayerInputPC>();
            }
        }
    }
}
