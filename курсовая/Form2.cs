using System;
using System.Windows.Forms;

namespace Test
{
    public partial class Form2 : Form
    {
        public string UserName { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserName = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(UserName))
            {
                MessageBox.Show("Please enter your name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Logger.Log($"User entered name: {UserName}");
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}



