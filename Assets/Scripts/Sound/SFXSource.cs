using Krevechous.Core;
using Krevechous.Player;
using Krevechous.Player.Inputs;
using UnityEngine;
using Zenject;

namespace Krevechous.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXSource : MonoBehaviour
    {
        private NewGameManager _gm;

        private AudioSource _source;

        [SerializeField] private AudioClip _pointSound;
        [SerializeField] private AudioClip _dieSound;
        [SerializeField] private AudioClip _startSound;
        [SerializeField] private AudioClip _flapSound;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _gm.OnGameStart += PlayStart;
            _gm.OnScoreIncremented += PlayPoint;
            _gm.OnGameEnd += PlayDie;
        }

        private void OnDisable()
        {
            _gm.OnGameStart -= PlayStart;
            _gm.OnGameEnd -= PlayDie;
            _gm.OnScoreIncremented -= PlayPoint;
        }

        [Inject]
        public void Construct(NewGameManager gameManager)
        {
            _gm = gameManager;
        }

        public void PlayPoint(int score) { _source.PlayOneShot(_pointSound); }

        public void PlayDie() { _source.PlayOneShot(_dieSound); }

        public void PlayFlap()
        {
            _source.PlayOneShot(_flapSound);
        }

        public void PlayStart() { _source.PlayOneShot(_startSound); }
    }
}