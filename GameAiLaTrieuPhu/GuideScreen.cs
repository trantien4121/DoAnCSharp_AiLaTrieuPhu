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
    public partial class GuideScreen : Form
    {
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@"D:\sound_AiLaTrieuPhu-CSharp\NhacNen_sound.wav");
        public GuideScreen()
        {
            InitializeComponent();
            sound.Play();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartScreen fr = new StartScreen();
            fr.Show();
            sound.Stop();
            this.Hide();
        }
    }
}
