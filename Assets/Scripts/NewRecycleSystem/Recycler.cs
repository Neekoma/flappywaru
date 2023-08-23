using UnityEngine;
using UnityEngine.Events;

namespace Krevechous.NewRecycleSystem {

    public class Recycler : MonoBehaviour {
        
        public UnityEvent RecycleEvent;

        public void Recycle(Recycleable recycleable)
        {
            RecycleEvent?.Invoke(); // Запустить внешнюю переработку
            recycleable.OnRecycle(); // Запустить внутреннюю переработку
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Recycleable adapter))
            {
                Recycle(adapter);
            }
        }
    }
}