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
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace GameAiLaTrieuPhu
{
    public partial class frmCRUDQuestions : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        String str = "Data Source=QuestionDataBase.db; Version = 3; New = True; Compress = True; ";
        String updateID;
        Question question;
        public frmCRUDQuestions(String updateId = null, Question question = null)
        {
            InitializeComponent();
            this.updateID = updateId;
            this.question = question;
            if (updateID != null)
            {
                txtId.Text = updateID;
                txtQuestion.Text = question.getQuestionText();
                txtOptionA.Text = question.getOptions()[0];
                txtOptionB.Text = question.getOptions()[1];
                txtOptionC.Text = question.getOptions()[2];
                txtOptionD.Text = question.getOptions()[3];
                txtAnswer.Text = question.getAnswer();
            }
        }
        public void connectDatabase()
        {
            connection = new SQLiteConnection(str);
            connection.Open();
        }

        private void frmCRUDQuestions_Load(object sender, EventArgs e)
        {

        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (this.updateID == null)
            {
                connectDatabase();
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Questions VALUES('" + txtId.Text + "' , '" + txtQuestion.Text + "', '" +
                    txtOptionA.Text + "', '" + txtOptionB.Text + "', '" + txtOptionC.Text + "', '" + txtOptionD.Text + "' , '" +
                    txtAnswer.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm câu hỏi thành công");
                DialogResult = DialogResult.OK;
            }
            else
            {
                connectDatabase();
                command = connection.CreateCommand();
                command.CommandText = "UPDATE Questions SET Question = '" + txtQuestion.Text + "', OptionA = '" + txtOptionA.Text
                     + "', OptionB = '" + txtOptionB.Text + "', OptionC = '" + txtOptionC.Text + "', OptionD = '" + txtOptionD.Text
                     + "', Answer = '" + txtAnswer.Text + "' WHERE ID = '" + updateID + "'";
                command.ExecuteNonQuery();
                MessageBox.Show("Sửa câu hỏi thành công");
                DialogResult = DialogResult.OK;
            }
        }

    }
}
