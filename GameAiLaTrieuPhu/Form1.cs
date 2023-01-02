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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GameAiLaTrieuPhu
{
    public partial class form1 : Form
    {
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@"H:\Download\Software__Dowload\sound_AiLaTrieuPhu-CSharp\BatDau_ALTP.wav");
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
            
            sound.Play();
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
           prizeList.addToList(new LinkedListNode(prize14, false));
            prizeList.addToList(new LinkedListNode(prize15, true));
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
       

        // Tạo kết quả ngẫu nhiên cho cuộc thăm dò
        private List<int> generateRandomPollResults()
        {

            List<int> randomNumbers = new List<int>();

            // Nếu nút trợ giúp 50/50 chưa được dùng thì tạo 4 số ngẫu nhiên, ngược lại thì tạo 2 số ngẫu nhiên
            if (btn5050.Enabled == true)
            {
                randomNumbers.Add(rNumber.Next(1, 25));

                randomNumbers.Add(rNumber.Next(25, 50) - randomNumbers[0]);

                randomNumbers.Add(rNumber.Next(50, 75) - randomNumbers[1]);

                randomNumbers.Add(100 - (randomNumbers[0] + randomNumbers[1] + randomNumbers[2]));
            }
            else
            {
                randomNumbers.Add(rNumber.Next(1, 50));

                randomNumbers.Add(100 - randomNumbers[0]);

            }

            // Sắp xếp lại các số ngẫu nhiên và trả về
            randomNumbers.Sort();
            return randomNumbers;

        }
        private void btnYKienKhanGia_Click(object sender, EventArgs e)
        {
            // Danh sách của kết quả thăm dò
            List<PollResults> pollResults = new List<PollResults>();

            // Danh sách để giữ các số ngẫu nhiên đã tạo (giá trị cuối cùng trong danh sách sẽ cao nhất)
            List<int> randomNumbers = generateRandomPollResults();

            // Giá trị kiểm tra cuộc thăm dò được thêm vào cho đáp án đúng
            Boolean correctAnswerPollResultAdded = false;

            // Lặp qua các nút
            for (int idx = 0; idx < buttons.Count; idx++)
            {

                // Nếu các đáp án đang được mở
                if (buttons[idx].Enabled == true)
                {

                    // Nếu nút dành cho đáp án đúng, thêm giá trị cuối cùng từ danh sách và xóa giá trị khỏi danh sách
                    if (currentQuestion.checkAnswer(buttons[idx].Text))
                    {

                        pollResults.Add(new PollResults(buttons[idx].Text.Substring(0, 1), randomNumbers[randomNumbers.Count - 1]));

                        correctAnswerPollResultAdded = true;
                        randomNumbers.RemoveAt(randomNumbers.Count - 1);

                    }
                    else
                    {
                        int randomPollResultIndex;

                        // Nếu cuộc thăm dò ý kiến ​​cho câu trả lời đúng được thêm vào, thêm số ngẫu nhiên từ tổng thể, nếu không sẽ loại trừ giá trị cuối cùng
                        if (correctAnswerPollResultAdded)
                        {
                            if (randomNumbers.Count != 1)
                            {
                                randomPollResultIndex = rNumber.Next(0, randomNumbers.Count - 1);
                            }
                            else
                            {
                                randomPollResultIndex = 0;
                            }

                        }
                        else
                        {
                            randomPollResultIndex = rNumber.Next(0, randomNumbers.Count - 2);

                        }

                        // Thêm kết quả thăm dò vào danh sách
                        pollResults.Add(new PollResults(buttons[idx].Text.Substring(0, 1), randomNumbers[randomPollResultIndex]));

                        // Xóa giá trị khỏi danh sách để ngăn lặp lại
                        randomNumbers.RemoveAt(randomPollResultIndex);
                    }
                }

            }

            // Hiển thị kết quả lên giao diện biểu đồ
            displayPollResultsOnGraph(pollResults);

            // Đặt lại nền đã dùng và vô hiệu hóa nút
            btnYKienKhanGia.BackgroundImage = Properties.Resources.YKienKhanGia_notActive;
            btnYKienKhanGia.Enabled = false;
        }

        // Thêm kết quả thăm dò vào giao diện biểu đồ
        private void displayPollResultsOnGraph(List<PollResults> pollResults)
        {
            // Xóa biểu đồ và thêm số series
            chartPollResults.Series.Clear();
            chartPollResults.Series.Add("poll");

            // Thiết kế giao diện 
            chartPollResults.Series[0].BackGradientStyle = GradientStyle.LeftRight;
            chartPollResults.Series[0].Color = Color.FromArgb(212, 175, 55);
            chartPollResults.Series[0].BackSecondaryColor = Color.Black;

            // Thêm mỗi kết quả thăm dò với chữ cái để tương ứng với nút
            foreach (PollResults poll in pollResults)
            {
                chartPollResults.Series["poll"].Points.AddXY(Convert.ToString(poll.getoptionKey()), poll.getValue());
            }

            // Hiển thị biểu đồ
            chartPollResults.Visible = true;
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
                ScoreScreen final;
                // Nếu vượt qua được checkpoint, thì đó là giải thưởng cuối cùng, ngược lại giải thưởng cuối cùng là 0 VND
                if (lastCheckpoint != null)
                {
                    final = new ScoreScreen(lastCheckpoint.getPrize().Text.Substring(6, lastCheckpoint.getPrize().Text.Length-6));

                }
                else
                {
                    final = new ScoreScreen("0 VND");

                }
                // Chuyển tới final score window và đóng form1
                final.Show();
                this.Hide();

            }
          
             if (btnPlay.Text == "Chơi" || btnPlay.Text == "Câu hỏi tiếp theo")
            {
                sound.Stop();
                enableOptionButtons();
                chartPollResults.Visible = false;
                /* enableOptionButtons();*/
                if (questionNo >= 0 && questionNo <= 5)
                {
                    System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(@"H:\Download\Software__Dowload\sound_AiLaTrieuPhu-CSharp\NhacCho_1-5_sound.wav");
                    sound1.Play();
                }
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
                            Console.WriteLine($"------- answerOption : {button.Text}");
                            // A. Huế 
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
            sound.Stop();
            MessageBox.Show($"Đã chọn câu {selectedOption.Text.Substring(0, 1)} ");

            if (currentQuestion.checkAnswer(selectedOption.Text))
            {



                System.Media.SoundPlayer sound_correct = new System.Media.SoundPlayer($@"H:\Download\Software__Dowload\sound_AiLaTrieuPhu-CSharp\Dung{selectedOption.Text.Substring(0, 1)}_XinChucMung_sound.wav");
                sound_correct.Play();
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
                System.Media.SoundPlayer sound_correct = new System.Media.SoundPlayer($"{currentQuestion.getOptionsAnswer(selectedOption.Text)}");
                sound_correct.Play();
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

        private void btn5050_Click(object sender, EventArgs e)
        {
            int firstOptionToRemove = rNumber.Next(0, buttons.Count);

            // Nếu số lấy ngẫu nhiên trùng với đáp án đúng, quay lại số ngẫu nhiên mới
            while (currentQuestion.checkAnswer(buttons[firstOptionToRemove].Text))
            {
                firstOptionToRemove = rNumber.Next(0, buttons.Count);
            }

            // Vô hiệu hóa đáp án bị loại bỏ thứ nhất
            buttons[firstOptionToRemove].Enabled = false;

            // Chọn ngẫu nhiên số giữa 0 và 3 dựa trên đáp án để loại bỏ thứ hai
            int secondOptionToRemove = rNumber.Next(0, buttons.Count);

            // Nếu số lấy ngẫu nhiên trùng với đáp án đúng hoặc trùng với đáp án loại bỏ thứ nhất, quay lại số ngẫu nhiên mới
            while (currentQuestion.checkAnswer(buttons[secondOptionToRemove].Text) || secondOptionToRemove == firstOptionToRemove)
            {
                secondOptionToRemove = rNumber.Next(0, buttons.Count);
            }

            // Vô hiệu hóa đáp án bị loại bỏ thứ hai
            buttons[secondOptionToRemove].Enabled = false;

            // Đặt lại nền của nút trợ giúp 50/50 và vô hiệu hóa
            btn5050.BackgroundImage = Properties.Resources._5050_notActive;
            btn5050.Enabled = false;

        }

        private void chartPollResults_Click(object sender, EventArgs e)
        {

        }

        

        private void btnDienThoai_click(object sender, EventArgs e)
        {
           
          
            if (btnDienThoai.Enabled = true)
            {
                btnDienThoai.BackgroundImage = Properties.Resources.DienThoai_notActive;
                Phone_Support_Screen form = new Phone_Support_Screen(currentQuestion.answer);
                form.Show();
            }
            btnDienThoai.Enabled = false;

        }
    }
}
