using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Krevechous
{
    public sealed class TubesPool : Pool<TubeRecycleHandler>
    {
        private Queue<TubeRecycleHandler> _tubes = new Queue<TubeRecycleHandler>();

        

    }
}
