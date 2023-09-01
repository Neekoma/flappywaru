using Krevechous.Core;

namespace Krevechous.Player {

    public class ScoreRepository : IRepository<int>
    {
        public int data { get; private set ; }


        public ScoreRepository() {
            data = 0;
        }

        public ScoreRepository(SavedPlayerData saved) {
            data = saved.score;
        }

        public int GetFromRepository()
        {
            return data;
        }

        public int PutToRepository(int value)
        {
            data += value;
            return data;
        }

        public void ResetRepository()
        {
            data = 0;
        }
    }
}