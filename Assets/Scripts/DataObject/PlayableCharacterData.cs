using UnityEngine;

namespace Krevechous
{
    [CreateAssetMenu(menuName ="Characters/Playable", fileName ="New playable character")]
    public class PlayableCharacterData : ScriptableObject
    {
        [SerializeField] private Sprite sprite;

        public Sprite Sprite => sprite;

    }
}