using UnityEngine;

namespace Krevechous.Gacha {
    [CreateAssetMenu(menuName = "Gacha/Gacha object", fileName = "New gacha object")]
    public class GachaObject : ScriptableObject {
        [SerializeField] private string _name;
        [SerializeField] private string _desctiption;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Rarity _rarity;
        [SerializeField] private bool _obtained;

        public string Name => _name;
        public string Desctiption => _desctiption;
        public Sprite GachaSprite => _sprite;
        public Rarity GachaRarity => _rarity;
        public bool Obtained => _obtained;
    }
}