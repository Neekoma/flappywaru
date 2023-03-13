namespace Krevechous.ObjectsRecycler
{
    public interface IRecycleable
    {
        public event System.Action OnBeforeRecycle;
        public event System.Action OnAfterRecycle;

        public void BeforeRecycle();
        public void OnRecycle();
        public void AfterRecycle();

    }
}