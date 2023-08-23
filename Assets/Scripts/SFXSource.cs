using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krevechous
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXSource : MonoBehaviour
    {
        private AudioSource _source;

        [SerializeField] private AudioClip _pointSound;
        [SerializeField] private AudioClip _dieSound;
        [SerializeField] private AudioClip _startSound;
        [SerializeField] private AudioClip _flapSound;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Tube.OnTubePassed.AddListener(PlayPoint);
            Barrier.OnBarrierTouched.AddListener(PlayDie);
            PlayerController.OnJump.AddListener(PlayFlap);
            GameManager.Instance.OnGameStart.AddListener(PlayStart);
        }

        public void PlayPoint() { _source.PlayOneShot(_pointSound); }
        public void PlayDie() { _source.PlayOneShot(_dieSound); }
        public void PlayFlap() { _source.PlayOneShot(_flapSound); }
        public void PlayStart() { _source.PlayOneShot(_startSound); }
    }
}