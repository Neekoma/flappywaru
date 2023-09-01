using UnityEngine;

namespace Krevechous.Level {

    public interface IMover {

        public bool moveOnStart { get; set; }
        public bool isAllowToMove { get; set; }


        public float moveSpeed { get; set; }
        public void Move(Vector2 direction, float smoothnessDelta);


    }
}