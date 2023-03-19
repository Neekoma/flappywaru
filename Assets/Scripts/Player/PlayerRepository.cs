namespace Krevechous {

    public sealed class PlayerRepository {
    
        public int Coins { get; set; }


        public PlayerRepository() {
            Coin.OnCoinPicked += () => { Coins++; };
        }
    }
}