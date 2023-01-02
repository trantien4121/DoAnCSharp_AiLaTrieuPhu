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
    public partial class Phone_Support_Screen : Form
    { private String answer;
        public Phone_Support_Screen(String answer)
        {
            InitializeComponent();
            this.answer = answer;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Support_ThayDung_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thầy Dũng hỗ trợ bạn câu hỏi này!", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show($"Thầy Dũng sẽ hỗ trợ cho em đáp án : {answer}");
                this.Close();
            }
        
          
        }
         
        private void Support_ThayHa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thầy Hà hỗ trợ bạn câu hỏi này!", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show($"Thầy Hà sẽ hỗ trợ cho em đáp án : {answer}");
                this.Close();
            }
          
        }

        private void Support_CoPhuoc_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn cô Phước hỗ trợ bạn câu hỏi này!", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show($"Cô Phước sẽ hỗ trợ cho em đáp án : {answer}");
                this.Close();
            }
           
        }

        private void Support_ThayLan_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thầy Lân hỗ trợ bạn câu hỏi này!", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show($"Thầy Lân sẽ hỗ trợ cho em đáp án : {answer}");
                this.Close();
            }
           
        }

        private void Phone_Support_Screen_Load(object sender, EventArgs e)
        {

        }
    }
}
