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
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            getNumOfQuestion();
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
    }
}
