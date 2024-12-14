namespace Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            statusLabel = new System.Windows.Forms.Label();
            txtCountDown = new System.Windows.Forms.Label();
            GameTImer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(215, 21);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Start";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(215, 50);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Leaderboard";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new System.Drawing.Point(215, 76);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(38, 15);
            statusLabel.TabIndex = 1;
            statusLabel.Text = "status";
            // 
            // txtCountDown
            // 
            txtCountDown.AutoSize = true;
            txtCountDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtCountDown.Location = new System.Drawing.Point(215, 91);
            txtCountDown.Name = "txtCountDown";
            txtCountDown.Size = new System.Drawing.Size(113, 21);
            txtCountDown.TabIndex = 1;
            txtCountDown.Text = "Timer Left: 30";
            // 
            // GameTImer
            // 
            GameTImer.Enabled = true;
            GameTImer.Interval = 1000;
            GameTImer.Tick += TimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(418, 344);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtCountDown);
            Controls.Add(statusLabel);
            Name = "Form1";
            Text = "Психологический тест";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3; // Объявляем кнопку
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Timer GameTImer;
        private System.Windows.Forms.Label txtCountDown;


    }
}


