namespace CardGame.Logic
{
    public class GamePlayer
    {
        public int PendingGames { get; set; }

        public int GamesPlayed { get; private set; }

        public GameBoard Board { get; private set; }

        public int Wins { get; private set; }

        public GamePlayer(int gamesToPlay)
        {
            this.PendingGames = gamesToPlay;
            this.Board = new GameBoard();
            this.Wins = 0;
        }

        public void PlaySingleGame()
        {
            if (this.PendingGames > 0)
            {
                this.Board.StartGame();
                this.PendingGames--;
                this.GamesPlayed++;
                if (this.Board.ClearSlotCount == 4)
                {
                    this.Wins++;
                }
            }
        }

        public void PlayGames()
        {
            while (this.PendingGames > 0)
            {
                this.PlaySingleGame();
            }
        }
    }
}
