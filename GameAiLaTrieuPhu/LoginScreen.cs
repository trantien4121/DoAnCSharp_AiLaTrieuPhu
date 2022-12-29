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
    public partial class LoginScreen : Form
    {
        ErrorProvider error;
        public LoginScreen()
        {
            InitializeComponent();
            error = new ErrorProvider();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StartScreen fr = new StartScreen();
            fr.Show();
            this.Hide();
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            if (String.IsNullOrEmpty(username))
            {
                error.SetError(txtUsername, "Vui lòng nhập tên đăng nhập!");
                return;
            }
            if(String.IsNullOrEmpty(password))
            {
                error.SetError(txtPassword, "Vui lòng nhập mật khẩu!");
                return;
            }
            if (username.Equals("admin") && password.Equals("123"))
            {
                QuestionControlScreen fr = new QuestionControlScreen(username);
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Vui long thử lại");
            }
        }
    }
}
