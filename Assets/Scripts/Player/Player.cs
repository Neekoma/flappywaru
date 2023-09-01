using Krevechous.Core;
using UnityEngine;
using Zenject;

namespace Krevechous.Player
{
    [RequireComponent(typeof(PlayerController))]
    public sealed class Player : MonoBehaviour, IResetable
    {
        private Vector3 _defaultPos;
        private Quaternion _defaultRot;

        private NewGameManager _gm;
        private PlayerController _controller;


        private void Awake()
        {
            SaveDefaultState();
            _controller = GetComponent<PlayerController>();
        }

        [Inject]
        public void Construct(NewGameManager gm) {
            _gm = gm;
        }

        private void OnEnable()
        {
            _gm.OnGameReset += ApplyDefaultState;
        }

        private void OnDisable()
        {
            _gm.OnGameReset -= ApplyDefaultState;
        }

        public void ApplyDefaultState()
        {
            _controller.ApplyDefaultState();
            transform.position = _defaultPos;
            transform.rotation = _defaultRot;
        }

        public void SaveDefaultState()
        {
            _defaultPos = transform.position;
            _defaultRot = transform.rotation;
        }
    }
}
