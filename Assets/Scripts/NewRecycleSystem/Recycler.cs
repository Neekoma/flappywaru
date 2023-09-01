using UnityEngine;


namespace Krevechous.NewRecycleSystem {

    public class Recycler : MonoBehaviour {
        
        public void Recycle(Recycleable recycleable)
        {
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