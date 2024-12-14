using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        List<int> questionNumbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        List<PictureBox> Boxes = new List<PictureBox>();

        string firstChoice;
        string secondChoice;

        PictureBox picA;
        PictureBox picB;

        int tries;
        int totalTime = 30;
        int countDownTime;
        bool gameOver = false;
        bool gameStarted = false;

        string currentUserName;
        const string ScoresFile = "PlayerScores.txt";

        private GameStatistics statistics = new GameStatistics();
        private MemoryGame memoryGame = new MemoryGame();
        private ImageManager imageManager = new ImageManager();

        public Form1()
        {
            InitializeComponent();
            LoadPic();
            button2.Text = "Start"; // Устанавливаем текст на кнопке
            button2.Enabled = true; // Убедимся, что кнопка активна
        }

        private void LoadPic()
        {
            int pLeft = 20;
            int pTop = 20;
            int rows = 0;

            for (int i = 0; i < 12; i++)
            {
                PictureBox nwPic = new PictureBox
                {
                    Height = 50,
                    Width = 50,
                    BackColor = Color.LightGray,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                nwPic.Click += NwPic_Click;
                Boxes.Add(nwPic);

                if (rows < 3)
                {
                    rows++;
                    nwPic.Left = pLeft;
                    nwPic.Top = pTop;
                    Controls.Add(nwPic);
                    pLeft += 60;
                }

                if (rows == 3)
                {
                    pLeft = 20;
                    pTop += 60;
                    rows = 0;
                }
            }

            RestartGame();
        }

        private void NwPic_Click(object sender, EventArgs e)
        {
            if (gameOver || !gameStarted) // Блокируем клики, если игра завершена или ещё не началась
            {
                return;
            }

            if (firstChoice == null)
            {
                picA = sender as PictureBox;

                if (picA.Tag != null && picA.Image == null)
                {
                    picA.Image = imageManager.LoadImage((string)picA.Tag);
                    firstChoice = (string)picA.Tag;
                }
            }
            else if (secondChoice == null)
            {
                picB = sender as PictureBox;

                if (picB.Tag != null && picB.Image == null)
                {
                    picB.Image = imageManager.LoadImage((string)picB.Tag);
                    secondChoice = (string)picB.Tag;
                }
            }
            else
            {
                RunCheck(picA, picB);
            }
        }

        private void RestartGame()
        {
            var randomList = questionNumbers.OrderBy(x => Guid.NewGuid()).ToList();
            questionNumbers = randomList;

            for (int i = 0; i < Boxes.Count; i++)
            {
                Boxes[i].Image = null;
                Boxes[i].Tag = questionNumbers[i].ToString();
            }

            tries = 0;
            statusLabel.Text = "Mismatched: " + tries + " Times";

            // Сбрасываем таймер
            countDownTime = totalTime;
            txtCountDown.Text = "Time Left: " + countDownTime;

            gameOver = false;
            gameStarted = false; // Игра еще не началась
            GameTImer.Stop(); // Останавливаем таймер
        }

        private void RunCheck(PictureBox A, PictureBox B)
        {
            if (firstChoice == secondChoice)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                tries++;
                statusLabel.Text = "Mismatched: " + tries + " Times";
            }

            firstChoice = null;
            secondChoice = null;

            foreach (PictureBox x in Boxes)
            {
                if (x.Tag != null)
                {
                    x.Image = null;
                }
            }

            if (Boxes.All(o => o.Tag == null))
            {
                GameOver("Great work, you win!");
            }
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if (gameOver) return;

            countDownTime--;
            txtCountDown.Text = "Time Left: " + countDownTime;

            if (countDownTime < 1)
            {
                GameOver("Times Up, You Lose!");

                foreach (PictureBox x in Boxes)
                {
                    if (x.Tag != null)
                    {
                        x.Image = imageManager.LoadImage((string)x.Tag);
                    }
                }
            }
        }

        private void GameOver(string msg)
        {
            GameTImer.Stop(); // Останавливаем таймер
            gameOver = true;
            gameStarted = false; // Блокируем возможность кликов
            SavePlayerScore();

            if (msg.Contains("win"))
            {
                statistics.RecordWin();
            }
            else
            {
                statistics.RecordLoss();
            }

            MessageBox.Show(msg + " Click Start to Play Again", "Game Over");
            button2.Enabled = true; // Делаем кнопку "Старт" активной
        }

        private void SavePlayerScore()
        {
            string result = $"{currentUserName},{tries}";
            if (!File.Exists(ScoresFile))
            {
                File.WriteAllText(ScoresFile, result + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(ScoresFile, result + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Открываем форму для ввода имени пользователя
            Form2 nameInputForm = new Form2();
            if (nameInputForm.ShowDialog() == DialogResult.OK)
            {
                currentUserName = nameInputForm.UserName;
                if (string.IsNullOrEmpty(currentUserName))
                {
                    MessageBox.Show("Please enter your name to start the game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return; // Если пользователь закрыл окно ввода имени
            }

            button2.Enabled = false; // Отключаем кнопку "Старт" после начала игры

            RestartGame(); // Перезапускаем игру
            gameStarted = true; // Игра запущена
            GameTImer.Start(); // Запускаем таймер
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 leaderboardForm = new Form3(statistics);
                leaderboardForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the leaderboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}











