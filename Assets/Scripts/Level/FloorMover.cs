using Krevechous.Core;
using System;
using UnityEngine;
using Zenject;

namespace Krevechous.Level
{
    public class FloorMover : MonoBehaviour, IMover, IStartGameListener, IEndGameListener, IPauseGameListener, IResumeGameListener
    {
        private NewGameManager _gm;


        [SerializeField] private float _moveSpeed;

        [SerializeField] private bool _moveOnStart;

        [SerializeField] private Floor[] _floors;

        public bool moveOnStart { get => moveOnStart; set => moveOnStart = value; }
        public bool isAllowToMove { get; set; }
        public float moveSpeed { get => _moveSpeed; set => _moveSpeed = value; }


        [Inject]
        public void Construct(NewGameManager gm) {
            _gm = gm;
        }

        private void OnEnable()
        {
            _gm.OnGameStart += OnGameStart;
            _gm.OnGameEnd += OnGameEnd;
            _gm.OnGamePause += OnGamePause;
            _gm.OnGameResume += OnGameResume;
            _gm.OnGameReset += OnGameReset;
        }

        private void OnDisable()
        {
            _gm.OnGameStart -= OnGameStart;
            _gm.OnGameEnd -= OnGameEnd;
            _gm.OnGamePause -= OnGamePause;
            _gm.OnGameResume -= OnGameResume;
            _gm.OnGameReset -= OnGameReset;
        }


        private void Start()
        {
            if (_moveOnStart)
                isAllowToMove = true;
        }

        private void FixedUpdate()
        {
            if (isAllowToMove)
            {
                Move(Vector2.left, Time.fixedDeltaTime);
            }
        }

        public void OnGameStart()
        {
            isAllowToMove = true;
        }

        public void OnGameEnd()
        {
            isAllowToMove = false;
        }

        public void OnGameResume()
        {
            isAllowToMove = true;
        }

        public void OnGamePause()
        {
            isAllowToMove = false;
        }

        public void OnGameReset() {
            isAllowToMove = true;
        }

        public void Move(Vector2 direction, float smoothnessDelta)
        {
            foreach (Floor floor in _floors)
            {
                floor.Move(direction, moveSpeed, smoothnessDelta);
            }
        }
    }
}
