namespace Test
{
    public class GameStatistics
    {
        public int TotalGamesPlayed { get; private set; } = 0;
        public int TotalWins { get; private set; } = 0;
        public int TotalLosses { get; private set; } = 0;

        public void RecordWin()
        {
            TotalGamesPlayed++;
            TotalWins++;
        }

        public void RecordLoss()
        {
            TotalGamesPlayed++;
            TotalLosses++;
        }

        public void ResetStatistics()
        {
            TotalGamesPlayed = 0;
            TotalWins = 0;
            TotalLosses = 0;
        }
    }
}



