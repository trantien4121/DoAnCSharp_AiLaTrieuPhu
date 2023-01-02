using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAiLaTrieuPhu
{
    public partial class QuestionControlScreen : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        string str = "Data Source=QuestionDataBase.db; Version = 3; New = True; Compress = True; ";
        SQLiteDataAdapter adapter = new SQLiteDataAdapter();
        DataTable table = new DataTable();

        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Questions";
            adapter.SelectCommand = command;
            NapDsQuestion();
        }
        void LoadDataAfterSearch(String key)
        {
            command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Questions where Question like '{key}%'";
            adapter.SelectCommand = command;
            NapDsQuestion();
        }
        void getNumOfQuestion()
        {
            int numOfQuestions = 0; ;
            command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM Questions";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                numOfQuestions = reader.GetInt32(0);
                
            }
            toolStripStatusLabel2.Text = numOfQuestions.ToString();
        }
        void NapDsQuestion()
        {
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            getNumOfQuestion();
        }
        public QuestionControlScreen(String username)
        {
            InitializeComponent();
            lblUsername.Text = $"Welcome, {username}";
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            StartScreen fr = new StartScreen();
            fr.Show();
            this.Hide();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private void QuestionControlScreen_Load(object sender, EventArgs e)
        {
            connection = new SQLiteConnection(str);
            connection.Open();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmCRUDQuestions frm = new frmCRUDQuestions();
            var rs = frm.ShowDialog();
            if (rs == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            String updateID_str = dataGridView1.Rows[i].Cells[0].Value.ToString();
            String updateQuestion = dataGridView1.Rows[i].Cells[1].Value.ToString();
            String updateOptionA = dataGridView1.Rows[i].Cells[2].Value.ToString();
            String upadteOptionB = dataGridView1.Rows[i].Cells[3].Value.ToString();
            String updateOptionC = dataGridView1.Rows[i].Cells[4].Value.ToString();
            String updateOptionD = dataGridView1.Rows[i].Cells[5].Value.ToString();
            String updateAnswer = dataGridView1.Rows[i].Cells[6].Value.ToString();
            Question q = new Question(updateQuestion, updateOptionA, upadteOptionB, updateOptionC, updateOptionD, updateAnswer);
            if (!String.IsNullOrEmpty(updateID_str))
            {
                frmCRUDQuestions frm = new frmCRUDQuestions(updateID_str, q);
                var rs = frm.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            String deleteID_str = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (!String.IsNullOrEmpty(deleteID_str))
            {
                var rs = MessageBox.Show($"Bạn có chắc muốn xóa câu hỏi có ID = {deleteID_str} này?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Questions WHERE ID = '" + deleteID_str + "'";
                    command.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Xóa câu hỏi thành công");
                }
            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
           
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtTimKiem.Text))
                {
                    LoadData();
                }
                else
                {
                    LoadDataAfterSearch(txtTimKiem.Text);
                }
            }
        }
    }
}
