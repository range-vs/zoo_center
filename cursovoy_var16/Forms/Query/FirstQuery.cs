using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cursovoy_var16.Forms.Query
{
    public partial class FirstQuery : Form
    {
        public string[] QuerySelect { get; set; }
        public SqlConnection DataBase { get; set; }
        public List<string> Columns { get; set; } = new List<string>();
        public List<string[]> NameColumns { get; set; } = new List<string[]>();
        public FirstQuery(SqlConnection dataBase)
        {
            InitializeComponent();
            DataBase = dataBase;
            comboBox1.SelectedIndex = 0;
            QuerySelect = new string[] 
            {
                "date_finish is NULL AND date_start is NULL AND temperatures is NULL AND hibernation_period is NULL",
                "temperatures is NULL AND hibernation_period is NULL AND date_finish is NOT NULL AND date_start is NOT NULL",
                "temperatures is NOT NULL AND hibernation_period is NOT NULL AND date_finish is  NULL AND date_start is  NULL"
            };
            Columns.Add("id, name, date_birth, sex, id_diet, id_zone_habiat, id_employee, id_veterinarian");
            Columns.Add("id, name, date_birth, sex, id_diet, id_zone_habiat, id_employee, id_veterinarian, date_start, date_finish");
            Columns.Add("id, name, date_birth, sex, id_diet, id_zone_habiat, id_employee, id_veterinarian, temperatures, hibernation_period");
            NameColumns.Add(new string[]
            {
                "ID питомца", "Наименование", "День рождения", "Пол", "ID рациона", "ID среды обитания", "ID сотрудника", "ID ветеринара"
            });
            NameColumns.Add(new string[]
            {
                "ID питомца", "Наименование", "День рождения", "Пол", "ID рациона", "ID среды обитания", "ID сотрудника", "ID ветеринара", "Дата вылета", "Дата прилёта"
            });
            NameColumns.Add(new string[]
            {
                "ID питомца", "Наименование", "День рождения", "Пол", "ID рациона", "ID среды обитания", "ID сотрудника", "ID ветеринара", "Температура", "Период спячки"
            });
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            GridView.Rows.Clear();
            GridView.Columns.Clear();
            string sqlExpression = $"SELECT {Columns[comboBox1.SelectedIndex]} FROM animal WHERE {QuerySelect[comboBox1.SelectedIndex]} AND name LIKE '%{textBox1.Text}%' ";
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
                int countColumns = NameColumns[comboBox1.SelectedIndex].Length;
                for(int i = 0;i<countColumns;i++)
                {
                    GridView.Columns.Add($"Column{i}", NameColumns[comboBox1.SelectedIndex][i]);
                }

                while (reader.Read()) // построчно считываем данные
                {
                    object[] datas = new object[countColumns];
                    for (int i = 0; i < datas.Length; i++)
                        datas[i] = reader.GetValue(i);
                    GridView.Rows.Add(datas);
                }
            }
            reader.Close();
        }
    }
}
