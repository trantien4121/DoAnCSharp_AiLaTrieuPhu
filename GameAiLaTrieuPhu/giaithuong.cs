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
    public partial class giaithuong : Form
    {
        public giaithuong(string score)
        {
            InitializeComponent();
            InitializeComponent();
            lblDiem.Text = score.Substring(0, score.Length);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void giaithuong_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
