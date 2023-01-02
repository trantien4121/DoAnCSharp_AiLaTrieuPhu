﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAiLaTrieuPhu
{
    public class Question
    {
        // Thuộc tính
        public string questionText;
        public string[] options;
        public string answer;

        // Cấu trúc câu hỏi, thêm các đáp án vào mảng và câu trả lời
        public Question(string questionText, string optionA, string optionB, string optionC, string optionD, string answer)
        {
            this.options = new string[4];
            this.questionText = questionText;
            this.options[0] = optionA;
            this.options[1] = optionB;
            this.options[2] = optionC;
            this.options[3] = optionD;
            this.answer = answer;
        }

        // Kiểm tra nếu đáp án được lựa chọn là đúng
         public bool checkAnswer(string selectedOption)
        {
            string answer = selectedOption.Substring(2, selectedOption.Length - 2);
            if (this.answer == answer)
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        public String getOptionsAnswer(String selectedOption)
        {
            string answer = selectedOption.Substring(0, selectedOption.Length - 2);
            String answerOption = this.answer.Substring(0,1);
           

            if (this.answer == answer )
            {
                
                return $"D:\\sound_AiLaTrieuPhu-CSharp\\Dung{selectedOption.Substring(0, 1)}_XinChucMung_sound.wav";
            }

            else
            {
                if(this.answer == options[0])
                {
                    return $"D:\\sound_AiLaTrieuPhu-CSharp\\SaiA_RatTiec_sound.wav";
                }
                else if (this.answer == options[1])
                {
                    return $"D:\\sound_AiLaTrieuPhu-CSharp\\SaiB_RatTiec_sound.wav";
                }
                else if (this.answer == options[2])
                {
                    return $"D:\\sound_AiLaTrieuPhu-CSharp\\SaiC_RatTiec_sound.wav";
                }
                return $"D:\\sound_AiLaTrieuPhu-CSharp\\SaiD_RatTiec_sound.wav";


            }
        }
        //Thay câu hỏi
        public string getQuestionText()
        {
            return questionText;
        }

        //Thay 4 đáp án
        public string[] getOptions()
        {
            return options;
        }
        public String getAnswer()
        {
            return answer;
        }
    }
}

