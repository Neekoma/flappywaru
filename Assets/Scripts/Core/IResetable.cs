namespace Krevechous.Core {
    public interface IResetable
    {
        public void SaveDefaultState();
        public void ApplyDefaultState();
    }
}