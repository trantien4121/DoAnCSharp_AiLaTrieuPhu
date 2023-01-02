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
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           form1 form = new form1();
            form.Show();
            this.Hide();
       
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            LoginScreen fr = new LoginScreen();
            fr.Show();
            this.Hide();
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            GuideScreen fr = new GuideScreen();
            fr.Show();
            this.Hide();
        }
    }
}
