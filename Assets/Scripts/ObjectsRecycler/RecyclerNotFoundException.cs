using System;

namespace Krevechous.ObjectsRecycler {
    public class RecyclerNotFoundException : Exception {
        public RecyclerNotFoundException(Type t, string msg) : base($"Переработчик не был найден {t.Name}. {msg}"){
            
        }
    }

}