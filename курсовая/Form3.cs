using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Test
{
    public partial class Form3 : Form
    {
        private const string ScoresFile = "PlayerScores.txt";
        private GameStatistics statistics;

        // Конструктор, принимающий экземпляр GameStatistics
        public Form3(GameStatistics gameStatistics)
        {
            InitializeComponent();
            statistics = gameStatistics; // Сохраняем переданный экземпляр
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            try
            {
                leaderboardTextBox.Clear();

                if (File.Exists(ScoresFile))
                {
                    var scores = File.ReadAllLines(ScoresFile)
                                     .Select(line => line.Split(','))
                                     .Where(parts => parts.Length == 2 && int.TryParse(parts[1], out _))
                                     .GroupBy(parts => parts[0]) // Группируем по имени игрока
                                     .Select(group => new
                                     {
                                         Name = group.Key,
                                         GamesPlayed = group.Count(),
                                         TotalErrors = group.Sum(g => int.Parse(g[1])),
                                         Wins = group.Where(g => int.Parse(g[1]) == 0).Count(),
                                         Losses = group.Where(g => int.Parse(g[1]) > 0).Count()
                                     })
                                     .OrderByDescending(player => player.Wins) // Сортируем по победам
                                     .ThenBy(player => player.TotalErrors) // Сортируем по ошибкам
                                     .ToList();

                    leaderboardTextBox.AppendText("Leaderboard:\n");
                    leaderboardTextBox.AppendText("=========================================\n");

                    // Вывод информации для каждого игрока с новыми абзацами
                    foreach (var player in scores)
                    {
                        leaderboardTextBox.AppendText($"\n\t\tPlayer: {player.Name}\t\n\n");
                        leaderboardTextBox.AppendText($"\tGames Played: {player.GamesPlayed}\t\n\n");
                        leaderboardTextBox.AppendText($"\nWins: {player.Wins}\t\n\n");
                        leaderboardTextBox.AppendText($"\nLosses: {player.Losses}\t\n\n");
                        leaderboardTextBox.AppendText($"\nTotal Errors: {player.TotalErrors}\t\n\n");
                        leaderboardTextBox.AppendText("\t=========================================\n\n"); // Разделитель между игроками
                    }
                }
                else
                {
                    leaderboardTextBox.Text = "No scores available yet.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading leaderboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void exitButton_Click(object sender, EventArgs e)
        {
            Close(); // Закрываем окно
        }
    }
}





