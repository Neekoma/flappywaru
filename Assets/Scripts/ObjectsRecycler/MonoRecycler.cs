using System.Collections.Generic;
using UnityEngine;

namespace Krevechous.ObjectsRecycler
{
    public abstract class MonoRecycler: MonoBehaviour
    {
        
        public virtual void Recycle(IRecycleable obj) {
            obj.BeforeRecycle();
        }
    }
}