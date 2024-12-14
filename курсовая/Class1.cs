using System;
using System.Collections.Generic;

namespace Test
{
    public class MemoryGame
    {
        public List<PlayerRecord> PlayerRecords { get; private set; } = new List<PlayerRecord>();
        

        public void StartGame()
        {
            // Инициализация игры
        }

        public void EndGame(bool isWin, string playerName, int errors)
        {
            PlayerRecords.Add(new PlayerRecord { Name = playerName, Errors = errors });
        }
    }
}




