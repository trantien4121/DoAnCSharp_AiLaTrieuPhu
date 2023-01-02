using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAiLaTrieuPhu
{
    public partial class ScoreScreen : Form
    {
        System.Media.SoundPlayer sound_CamOn_ketThuc = new System.Media.SoundPlayer(@"D:\sound_AiLaTrieuPhu-CSharp\CamOn_KetThuc_sound.wav");
        public ScoreScreen(string score)
        {
            sound_CamOn_ketThuc.Play();
            Thread.Sleep(2000);
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

        private void ScoreScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
