using System;

namespace Krevechous
{
    public interface IResetable
    {
        public void SaveStartState();
        public void Reset(object sender, EventArgs args);
    }
}