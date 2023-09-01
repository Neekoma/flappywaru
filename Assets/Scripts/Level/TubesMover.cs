using Krevechous.Core;
using System;
using UnityEngine;
using Zenject;

namespace Krevechous.Level
{

    public sealed class TubesMover : MonoBehaviour, IMover, IStartGameListener, IEndGameListener, IPauseGameListener, IResumeGameListener
    {
        private NewGameManager _gm;


        [SerializeField] private float _moveSpeed;

        [SerializeField] private bool _moveOnStart;

        [SerializeField] private Tube[] _tubes;

        public bool isAllowToMove { get; set; } = false;

        public bool moveOnStart { get => _moveOnStart; set { _moveOnStart = value; } }
        public float moveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }



        [Inject]
        public void Construct(NewGameManager gm)
        {
            _gm = gm;
        }

        private void OnEnable()
        {
            _gm.OnGameStart += OnGameStart;
            _gm.OnGameEnd += OnGameEnd;
            _gm.OnGamePause += OnGamePause;
            _gm.OnGameResume += OnGameResume;
        }

        private void FixedUpdate()
        {
            if (isAllowToMove)
            {
                Move(Vector2.left, Time.fixedDeltaTime);
            }
        }

        public void Move(Vector2 direction, float smoothnessDelta)
        {
            foreach (Tube tube in _tubes)
            {
                tube.Move(direction, moveSpeed, smoothnessDelta);
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

        private void OnDisable()
        {
            _gm.OnGameStart -= OnGameStart;
            _gm.OnGameEnd -= OnGameEnd;
            _gm.OnGamePause -= OnGamePause;
            _gm.OnGameResume -= OnGameResume;
        }
    }
}