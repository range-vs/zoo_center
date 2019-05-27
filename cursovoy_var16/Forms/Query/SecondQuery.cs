using cursovoy_var16.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cursovoy_var16.Forms.Query
{
    public partial class SecondQuery : Form
    {
        public SqlConnection DataBase { get; set; }

        public SecondQuery(SqlConnection dataBase)
        {
            InitializeComponent();
            DataBase = dataBase;
            GetFamilyDataBase();
        }

        private void GetFamilyDataBase()
        {
            // сначала получаем id семейных пар
            List<Pair<int, int>> pairs = new List<Pair<int, int>>();
            string sqlExpression = $"SELECT id_hushband, id_wife FROM marital_status";
            SqlCommand command = new SqlCommand(sqlExpression, DataBase); 
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader(); 
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка");
                return;
            }
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    object[] datas = new object[2];
                    for (int i = 0; i < datas.Length; i++)
                        datas[i] = reader.GetValue(i);
                    pairs.Add(new Pair<int, int>(int.Parse(datas[0].ToString()), int.Parse(datas[1].ToString())));
                }
            }
            else
            {
                reader.Close();
                return;
            }
            reader.Close();
            // пары собраны - получаем фио и записываем в таблицу
            foreach(var p in pairs)
            {
                sqlExpression = $"SELECT first_name, last_name, second_name FROM employee WHERE id IN({p.First}, {p.Second})";
                command = new SqlCommand(sqlExpression, DataBase);
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка");
                    return;
                }
                if (reader.HasRows) 
                {
                    List<string> data = new List<string>();
                    while (reader.Read()) 
                    {
                        object[] datas = new object[3];
                        for (int i = 0; i < datas.Length; i++)
                            datas[i] = reader.GetValue(i);
                        data.Add($"{datas[0]} {datas[1]} {datas[2]}");
                        if(data.Count == 2)
                        {
                            GridView.Rows.Add(data[0], data[1]);
                            data.Clear();
                        }
                    }
                }
                reader.Close();
            }

        }
    }
}
