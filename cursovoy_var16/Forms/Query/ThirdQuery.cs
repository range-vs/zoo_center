using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cursovoy_var16.Forms.Query
{
    public partial class ThirdQuery : Form
    {
        public SqlConnection DataBase { get; set; }

        public ThirdQuery(SqlConnection dataBase)
        {
            InitializeComponent();
            DataBase = dataBase;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridView.Rows.Clear();
            string sqlExpression = $"SELECT name, id_diet FROM animal WHERE date_birth = '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}' ";
            SqlCommand command = new SqlCommand(sqlExpression, DataBase); // связали запрос с базой
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader(); // получили результаты и ыполнили запрос
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
                    GridView.Rows.Add(datas);
                }
            }
            reader.Close();
        }
    }
}
