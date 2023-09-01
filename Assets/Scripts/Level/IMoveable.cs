using UnityEngine;

namespace Krevechous.Level {

    public interface IMoveable {
        public void Move(Vector2 direction, float speed, float smoothnessDelta);
    }
}