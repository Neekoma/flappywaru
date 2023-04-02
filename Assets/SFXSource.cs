using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krevechous {
    [RequireComponent(typeof(AudioSource))]
    public class SFXSource : MonoBehaviour
    {
        private AudioSource _source;

        [SerializeField] private AudioClip pointSound;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Tube.OnTubePassed.AddListener(() => {
                _source.PlayOneShot(pointSound);
            });
        }
    }
}