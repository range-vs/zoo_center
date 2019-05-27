using cursovoy_var16.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cursovoy_var16.Querys
{
    class PanelQueryMaritalStatus: PanelQuery
    {
        public PanelQueryMaritalStatus(List<Pair<string, Pair<int, string>>> pairs, SqlConnection dataBase, string table, string spec_query = "1=1") : base(pairs, dataBase, table, spec_query)
        {
            Actions[4].Hide();
        }

        public override void Add(object sender, EventArgs eventArgs)
        {
            string sqlExpression = null;
            for (int i = 1; i < Columns.Count; i++) // первичный ключ не учитывается
            {
                if (!IsEmpty(ValueName[i]))
                {
                    MessageBox.Show("Одно или несколько полей не заполнены!", "Ошибка");
                    return;
                }
            }
            // тут проверяем, что такие ключи существуют в таблице сотрудник
            for(int i = 1; i< Columns.Count;i++)
            {
                sqlExpression = $"SELECT * from employee where id = {(ValueName[i] as TextBox).Text}";
                SqlCommand comm = new SqlCommand(sqlExpression, DataBase); // связали запрос с базой
                SqlDataReader reader = null;
                try
                {
                    reader = comm.ExecuteReader(); // получили результаты и ыполнили запрос
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка");
                    return;
                }
                if (!reader.HasRows) // если есть данные
                {
                    MessageBox.Show($"Записи с таким ID({(ValueName[i] as TextBox).Text}) не обнаружено.", "Ошибка");
                    reader.Close();
                    return;
                }
                reader.Close();
            }
            // добавляем
            sqlExpression = $"INSERT INTO {NameTable} ( ";
            for (int i = 1; i < Columns.Count; i++)
            {
                sqlExpression += (Columns[i].First + ", ");
            }
            sqlExpression = sqlExpression.Remove(sqlExpression.Length - 2) + ") VALUES (";
            for (int i = 1; i < Columns.Count; i++)
            {
                sqlExpression += (GetValueAdd(ValueName[i], Columns[i].Second.First) + ", ");
            }
            sqlExpression = sqlExpression.Remove(sqlExpression.Length - 2) + ")";
            SqlCommand command = new SqlCommand(sqlExpression, DataBase); // связали запрос с базой
            try
            {
                command.ExecuteNonQuery(); // добавили строку
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка");
                return;
            }
            MessageBox.Show("Запись добавлена", "Информация");
        }

    }
}
