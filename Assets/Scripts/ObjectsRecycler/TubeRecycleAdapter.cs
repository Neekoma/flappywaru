using UnityEngine;

namespace Krevechous.ObjectsRecycler
{
    public sealed class TubeRecycleAdapter : MonoRecycleAdapter
    {
        public override void BeforeRecycle()
        {
            
          
        }
        public override void OnRecycle()
        {
            Debug.Log($"����� ����� {gameObject.name} ������ �� �����, ����� ���� ������");
        }

        public override void AfterRecycle()
        {
            
        }
    }
}