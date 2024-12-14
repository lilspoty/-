namespace Test
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox leaderboardTextBox;
        private System.Windows.Forms.Button exitButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            leaderboardTextBox = new System.Windows.Forms.TextBox();
            exitButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // leaderboardTextBox
            // 
            leaderboardTextBox.Location = new System.Drawing.Point(14, 14);
            leaderboardTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            leaderboardTextBox.Multiline = true;
            leaderboardTextBox.Name = "leaderboardTextBox";
            leaderboardTextBox.ReadOnly = true;
            leaderboardTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            leaderboardTextBox.Size = new System.Drawing.Size(419, 346);
            leaderboardTextBox.TabIndex = 0;
            // 
            // exitButton
            // 
            exitButton.Location = new System.Drawing.Point(346, 367);
            exitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(88, 27);
            exitButton.TabIndex = 1;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(448, 417);
            Controls.Add(exitButton);
            Controls.Add(leaderboardTextBox);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form3";
            Text = "Leaderboard";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

