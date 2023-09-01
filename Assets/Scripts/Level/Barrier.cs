using Krevechous.Core;
using Krevechous.Player;
using UnityEngine;
using Zenject;

namespace Krevechous
{
    public class Barrier : MonoBehaviour
    {
        [SerializeField] private PlayerController _pController;

        private NewGameManager _gm;

        public static bool EnabledToDamage { get; private set; } = true;


        [Inject]
        public void Construct(NewGameManager gm, PlayerController pc)
        {
            _gm = gm;
            _pController = pc;
        }

        private void OnEnable()
        {
            _gm.OnGameStart += EnableDamage;
            _gm.OnGameReset += DisableDamage;
        }

        private void OnDisable()
        {
            _gm.OnGameStart -= EnableDamage;
            _gm.OnGameReset -= DisableDamage;
        }

        private void EnableDamage()
        {
            EnabledToDamage = true;
        }

        private void DisableDamage()
        {
            EnabledToDamage = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (EnabledToDamage)
            {
                if (collision.gameObject.tag == Tags.PLAYER_TAG)
                {
                    if (_gm.isGameStarted)
                    {
                        _pController.OnDie();
                        _gm.EndGame();
                    }
                }
            }
        }
    }
}