namespace Krevechous.Core
{
    public interface IRepository<T>
    {
        public T PutToRepository(T value);
        public T GetFromRepository();

        public void ResetRepository();
    }
}