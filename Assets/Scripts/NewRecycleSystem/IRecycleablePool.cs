using System.Collections.Generic;

namespace Krevechous.NewRecycleSystem
{
    public interface IRecycleablePool
    {
        public LinkedList<Recycleable> recycleables { get; set; }

    }
}