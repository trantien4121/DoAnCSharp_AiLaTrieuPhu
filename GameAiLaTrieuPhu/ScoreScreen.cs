using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAiLaTrieuPhu
{
    public partial class ScoreScreen : Form
    {
        public ScoreScreen(string score)
        {
            InitializeComponent();
            lblPrizeAmount.Text = score.Substring(0, score.Length);
        }

        private void btnReturnToForm1_Click(object sender, EventArgs e)
        {
            form1 MainForm = new form1();
            MainForm.Show();
            this.Hide();
        }

        private void btnBacktoMenu_Click(object sender, EventArgs e)
        {
            StartScreen startForm = new StartScreen();
            startForm.Show();
            this.Hide();
        }

        private void lblPrizeAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
