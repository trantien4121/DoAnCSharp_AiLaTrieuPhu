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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GameAiLaTrieuPhu
{
    public partial class form1 : Form
    {
        private int questionNo = 0;
        private QuestionBank bank = null;
        private Question currentQuestion = null;

        List<Button> buttons = new List<Button>();

        LinkedListNode currentPrize = null;
        LinkedListNode lastCheckpoint = null;
        LinkedList prizeList = new LinkedList();
        Random rNumber = new Random();
        public form1()
        {
            bank = new QuestionBank();
            InitializeComponent();
            buttons.Add(btnLuaChonA);
            buttons.Add(btnLuaChonB);
            buttons.Add(btnLuaChonC);
            buttons.Add(btnLuaChonD);
            // Neu đã chọn đáp án thì List button sẽ disable
            disableOptionButtons();
            prizeList.addToList(new LinkedListNode(prize1, false));
            prizeList.addToList(new LinkedListNode(prize2, false));
            prizeList.addToList(new LinkedListNode(prize3, false));
            prizeList.addToList(new LinkedListNode(prize4, false));
            prizeList.addToList(new LinkedListNode(prize5, true));
            prizeList.addToList(new LinkedListNode(prize6, false));
            prizeList.addToList(new LinkedListNode(prize7, false));
            prizeList.addToList(new LinkedListNode(prize8, false));
            prizeList.addToList(new LinkedListNode(prize9, false));
            prizeList.addToList(new LinkedListNode(prize10, true));
            prizeList.addToList(new LinkedListNode(prize11, false));
            prizeList.addToList(new LinkedListNode(prize12, false));
            prizeList.addToList(new LinkedListNode(prize13, false));
 /*           prizeList.addToList(new LinkedListNode(prize14, false));*/
            prizeList.addToList(new LinkedListNode(prize15, true));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnYKienKhanGia_Click(object sender, EventArgs e)
        {

        }

        private void btnCauHoi_Click(object sender, EventArgs e)
        {

        }

        private void form1_Load(object sender, EventArgs e)
        {

        }
        // Vo hieu hoa dap an
        private void disableOptionButtons()
        {
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }
        private void enableOptionButtons()
        {
            foreach (Button button in buttons)
            {
                button.Enabled = true;
            }
        }
        private void resetButtonBackgrounds()
        {
            foreach (Button button in buttons)
            {
                button.BackgroundImage = Properties.Resources.mocCauHoi;
            }
        }
        int i;
        private void settimer1()
        {
            if (questionNo < 10)
            {
                i = 60;
            }
            else
            {
                i = 45;
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Hiển thị form final score window và đóng form1
            if (btnPlay.Text == "Đi đến giải thưởng")
            {
                giaithuong final;
                // Nếu vượt qua được checkpoint, thì đó là giải thưởng cuối cùng, ngược lại giải thưởng cuối cùng là 0 VND
                if (lastCheckpoint != null)
                {
                    final = new giaithuong(lastCheckpoint.getPrize().Text);

                }
                else
                {
                    final = new giaithuong("0 VND");

                }
                // Chuyển tới final score window và đóng form1
                final.Show();
                this.Hide();

            }
            if (btnPlay.Text == "Chơi" || btnPlay.Text == "Câu hỏi tiếp theo")
            {
                enableOptionButtons();
                /* enableOptionButtons();*/
                if (questionNo < 15)
                {
                    enableOptionButtons();
                    // Đặt lại nền của nút và chuyển đến câu hỏi tiếp theo
                    resetButtonBackgrounds();
                    currentQuestion = bank.getQuestion(questionNo);
                    Console.WriteLine(currentQuestion.answer);
                    btnCauHoi.Text = currentQuestion.getQuestionText();

                    // Đặt lại các nút đáp án
                    var optionsAndButtons = currentQuestion.getOptions().Zip(buttons, (option, button) => new { Option = option, Button = button });

                    foreach (var ob in optionsAndButtons)
                    {

                        /* ob.Button.Text = ob.Option.Insert(0, $"{ob.Button.Text}.  ");*/
                        ob.Button.Text = ob.Button.Text.Remove(2, ob.Button.Text.Length -2).Insert(2, ob.Option);
                        MessageBox.Show(ob.Button.Text);
                    }
                }
            }
            settimer1();
            timer1.Start();
            btnPlay.Text = "Câu hỏi thứ " + (questionNo + 1);
        }

        private void lblThoiGianTraLoi_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i != 0)
            {
                i--;
                lblThoiGianTraLoi.Text = i.ToString();
            }

            else
            {
                timer1.Stop();

                btnPlay.Text = "Đi đến giải thưởng";
                // Hiển thị đáp án đúng khi hết giờ
                foreach (Button button in buttons)
                {
                    if (button.Enabled == true)
                    {
                        if (currentQuestion.checkAnswer(button.Text))
                        {
                            button.BackgroundImage = Properties.Resources.correct;
                        }
                    }
                }
                // Vô hiệu hóa các đáp án
                disableOptionButtons();
            }
        }
        private void answerCheck(Button selectedOption)
        {
            timer1.Stop();
            MessageBox.Show($"Đã chọn câu {selectedOption.Text} ");
            if (currentQuestion.checkAnswer(selectedOption.Text))
            {
                MessageBox.Show($"Đã chọn câu {selectedOption.Text} ");
                // Đặt cái ảnh nền của đáp án được lựa chọn là đúng
                selectedOption.BackgroundImage = Properties.Resources.correct;
                // Nếu là câu hỏi đầu tiên, thì giải thưởng sẽ là ở đầu danh sách liên kết
                if (questionNo == 0)
                 {
                     currentPrize = prizeList.getHead();
                 }

                 // Ngược lại thì đặt lại nền của giải thưởng hiện tại và chuyển giải thưởng hiện tại đến Node tiếp theo trong danh sách
                 else
                 {
                     currentPrize.resetBackground();
                     currentPrize = currentPrize.getNext();
                 }

                 // Đặt lại nền của giải thưởng hiện tại
                 currentPrize.setPrizeBackground();

                 // Nếu giải thưởng hiện tại là checkpoint, đặt lại checkpoint cuối cùng
                 if (currentPrize.getCheckpoint())
                 {
                     lastCheckpoint = currentPrize;
                 }
 
                // Tăng số đếm câu hỏi
                questionNo += 1;

                // Đặt nút "Câu hỏi tiếp theo" thành nút "Đi đến giải thưởng" nếu trả lời đúng câu hỏi cuối cùng (thứ 15)
                if (questionNo == 15)
                {
                    btnPlay.Text = "Đi đến giải thưởng";
                }
                else
                {
                    btnPlay.Text = "Câu hỏi tiếp theo";
                }
            }
            else
            {
                selectedOption.BackgroundImage = Properties.Resources.wrong;
                if (lastCheckpoint != null)
                {
                    lastCheckpoint.setPrizeBackground();
                }

                // Đặt nền sai vào giải thưởng hiện tại và vô hiệu hóa các đáp án
                if (currentPrize != null)
                {
                    currentPrize.setWrongBackground();
                }
                else
                {
                    prizeList.getHead().setWrongBackground();
                }

                foreach (Button button in buttons)
                {
                    if (button.Enabled == true)
                    {
                        if (currentQuestion.checkAnswer(button.Text))
                        {
                            button.BackgroundImage = Properties.Resources.correct;
                        }
                    }
                }

                btnPlay.Text = "Đi đến giải thưởng";
            }
            disableOptionButtons();


        }
        // Kiểm tra đáp án A
     

        private void btnLuaChonA_Click(object sender, EventArgs e)
        {
            answerCheck(btnLuaChonA);
        }

        private void btnLuaChonB_Click(object sender, EventArgs e)
        {
            answerCheck(btnLuaChonB);
        }

        private void btnLuaChonC_Click(object sender, EventArgs e)
        {
            answerCheck(btnLuaChonC);
        }

        private void btnLuaChonD_Click(object sender, EventArgs e)
        {
            answerCheck(btnLuaChonD);
        }
    }
}
