﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace GameAiLaTrieuPhu
{
    public class database
    {
        private OleDbConnection connection = null;

        // Kết nối
        private SQLiteConnection connect()
        {
            // Tạo mới 1 csdl
            SQLiteConnection connection = new SQLiteConnection("Data Source=QuestionDataBase.db; Version = 3; New = True; Compress = True;");
            // Kết nối
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return connection;
        }

        // Nhập n câu hỏi từ csdl
        public SQLiteDataReader importNQuestions(int n)
        {
            // Kết nối đến csdl và tạo mới lệnh
            SQLiteConnection connection = connect();
            SQLiteCommand command = connection.CreateCommand();

            // Tạo hàng chờ và xử lý
            command.CommandText = "SELECT * FROM Questions WHERE ID IN (SELECT ID FROM Questions ORDER BY RANDOM() LIMIT " + n + ")";
            SQLiteDataReader dataReader = command.ExecuteReader();


            // Ngắt kết nối và trả dữ liệu về csdl
            disconnect();
            return dataReader;

        }

        // Nếu kết nối không được mở
        private void disconnect()
        {
            if (connection != null && connection.State == ConnectionState.Open) connection.Close();
        }

    }
}
