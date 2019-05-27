using System.Windows.Forms;
using System.Collections.Generic;
using System;
using cursovoy_var16.Utils;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;

namespace cursovoy_var16.Querys
{
    public class PanelQuery: Panel
    {
        public Label [] LabelName { get; set; }
        public Control [] ValueName { get; set; }
        public Panel PanelValueReplaceName { get; set; }
        public Control [] ValueReplaceName { get; set; }
        public Button[] Actions { get; set; }
        public DataGridView GridView { get; set; }
        public List<Pair<string, Pair<int, string>>> Columns { get; set; }
        public SqlConnection DataBase { get; set; }
        public string NameTable { get; set; }
        public string FindColumns { get; set; }
        public string SpeqQuery { get; set; }

        public PanelQuery(List<Pair<string, Pair<int, string>>> pairs, SqlConnection dataBase, string table, string spec_query = "1=1") :base()
        {
            Columns = pairs;
            DataBase = dataBase;
            NameTable = table;
            SpeqQuery = spec_query;
            Init(Columns, DataBase);
        }

        public PanelQuery() { }

        public void Init(List<Pair<string, Pair<int, string>>> pairs, SqlConnection dataBase)
        {
            foreach (var p in pairs)
            {
                FindColumns += $"{p.First}, ";
            }
            FindColumns = FindColumns.Remove(FindColumns.Length - 2);
            this.AutoScroll = true;
            //this.Dock = DockStyle.Fill;
            int w1 = 100;
            int w2 = 100;
            int w3 = 200;
            // шапка
            Controls.Add(new Label { Location = new Point(10, 20), Text = "Имя столбца", Size = new Size(w1, 20) });
            Controls.Add(new Label { Location = new Point(120, 20), Text = "Значение столбца", Size = new Size(w2, 20) });
            // панель для изменения данных
            PanelValueReplaceName = new Panel { Location = new Point(230, 20), Size = new Size(230, pairs.Count * 40) };
            PanelValueReplaceName.Controls.Add(new Label { Location = new Point(5, 0), Text = "Заменяемое значение столбца", Size = new Size(w3, 20) });
            // генерируем массивы контролов и сразу добавляем в контейнер контролов
            LabelName = new Label[pairs.Count];
            ValueName = new Control[pairs.Count];
            ValueReplaceName = new Control[pairs.Count];
            int y = 20 + 30;
            for (int i = 0; i < pairs.Count; i++, y += 30)
            {
                // имя столбца
                var n = new Label { Location = new Point(10, y), Text = pairs[i].Second.Second, Size = new Size(w1, 20) };
                LabelName[i] = n;
                Controls.Add(n);
                switch (pairs[i].Second.First)
                {
                    case 0:
                    case 1: // текстовое поле
                        var tb = new TextBox { Location = new Point(120, y), Size = new Size(w2, 20) };
                        ValueName[i] = tb;
                        Controls.Add(tb);
                        if (pairs[i].Second.First == 1) // пол
                        {
                            tb.KeyPress += KeyPressSex;
                        }
                        if (pairs[i].First != "id" && pairs[i].First.IndexOf(".id") != pairs[i].First.Length - 3)
                        {
                            var tbr = new TextBox { Location = new Point(5, y - 20), Size = new Size(w3, 20) };
                            ValueReplaceName[i] = tbr;
                            PanelValueReplaceName.Controls.Add(tbr);
                            if (pairs[i].Second.First == 1) // пол
                            {
                                tbr.KeyPress += KeyPressSex;
                            }
                        }
                        break;

                    case 2: // дата
                        var dtp = new DateTimePicker { Location = new Point(120, y), Size = new Size(w2, 20), ShowCheckBox = true, Checked = false };
                        ValueName[i] = dtp;
                        Controls.Add(dtp);
                        if (pairs[i].First != "id" && pairs[i].First.IndexOf(".id") != pairs[i].First.Length - 3)
                        {
                            var dtpr = new DateTimePicker { Location = new Point(5, y - 20), Size = new Size(w3, 20), ShowCheckBox = true, Checked = false };
                            ValueReplaceName[i] = dtpr;
                            PanelValueReplaceName.Controls.Add(dtpr);
                        }
                        break;
                }
            }
            Controls.Add(PanelValueReplaceName);
            // кнопки для запросов
            Actions = new Button[5];
            string[] names = new string[] { "Показать", "Показать всё", "Добавить", "Удалить", "Изменить" };
            EventHandler[] events = new EventHandler[] { Show, ShowAll, Add, Del, Update };
            y += 30;
            for (int i = 0; i < 5; i++, y += 30)
            {
                Actions[i] = new Button { Text = names[i], Location = new Point(10, y), Size = new Size(100, 30) };
                Actions[i].Click += events[i];
                Controls.Add(Actions[i]);
            }
            // БД
            GridView = new DataGridView
            {
                Location = new Point(500, 20),
                Size = new Size(800, 600),
            };
            foreach (var name in Columns)
                GridView.Columns.Add(name.First, name.Second.Second);
            GridView.AllowUserToDeleteRows = false;
            GridView.AllowUserToAddRows = false;
            GridView.RowHeadersVisible = false;
            GridView.ReadOnly = true;
            Controls.Add(GridView);
        }

        protected void KeyPressSex(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                e.Handled = false;
            else if(! ((sender as TextBox).Text.Length < 1 && (e.KeyChar == 'Ж' || e.KeyChar == 'ж' | e.KeyChar == 'М' || e.KeyChar == 'м')))
            {
                e.Handled = true;
            }
        }

        protected string GetValueSelect(Control control, int type)
        {
            if(control is DateTimePicker)
            {
                DateTimePicker dtp = control as DateTimePicker;
                if (!dtp.Checked)
                    return "";
                return $" = '{(control as DateTimePicker).Value.ToString("yyyy-MM-dd")}'";
            }
            string text = (control as TextBox).Text;
            if (text.Length == 0)
                return "";
            switch (type)
            {
                case 0:
                    return $" LIKE '%{text}%'";

                case 1:
                    if (text.ToLower() == "м")
                        return $" = 1";
                    else
                        return $" = 0";

                case 2:
                    return $" = '{text}'";
            }
            return "";
        }

        protected string GetValueAdd(Control control, int type)
        {
            if (control is DateTimePicker)
            {
                string val = (control as DateTimePicker).Value.ToString("yyyy-MM-dd");
                if(val != "")
                    return $"'{val}'";
                return "";
            }
            string text = (control as TextBox).Text;
            if (text == "")
                return "";
            switch (type)
            {
                case 1:
                    if (text.ToLower() == "м")
                        return "1";
                    else if(text.ToLower() == "ж")
                        return "0";
                    return "";

                default:
                    return $"'{text}'";
            }
        }

        protected bool IsEmpty(Control control)
        {
            if(control is DateTimePicker)
            {
                DateTimePicker dtp = control as DateTimePicker;
                if (!dtp.Checked)
                    return false;
                return true;
            }
            string text = (control as TextBox).Text;
            if (text.Length == 0)
                return false;
            return true;
        }

        public virtual void Show(object sender, EventArgs eventArgs)
        {
            GridView.Rows.Clear();
            string sqlExpression = null;
            if ((ValueName[0] as TextBox).Text.Length != 0)
            {
                sqlExpression = $"SELECT {FindColumns} FROM {NameTable} WHERE {Columns[0].First} = {(ValueName[0] as TextBox).Text} AND {SpeqQuery}"; 
            }
            else
            {
                sqlExpression = $"SELECT {FindColumns} FROM {NameTable} WHERE {SpeqQuery} AND ";
                for (int i = 1;i < Columns.Count;i++)
                {
                    string result = GetValueSelect(ValueName[i], Columns[i].Second.First);
                    if (result != "")
                        sqlExpression += $"{Columns[i].First}  {result} AND ";
                }
                sqlExpression = sqlExpression.Remove(sqlExpression.Length - 5);
            }
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
                    object[] datas = new object[Columns.Count];
                    for (int i = 0; i < datas.Length; i++)
                        datas[i] = reader.GetValue(i);
                    GridView.Rows.Add(datas);

                }
            }
            reader.Close();
        }

        public virtual void ShowAll(object sender, EventArgs eventArgs)
        {
            GridView.Rows.Clear();
            string sqlExpression = $"SELECT * FROM {NameTable} WHERE {SpeqQuery}"; // создали запрос
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
                // выводим названия столбцов
                //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                while (reader.Read()) // построчно считываем данные
                {
                    object[] datas = new object[Columns.Count];
                    for (int i = 0; i < datas.Length; i++)
                        datas[i] = reader.GetValue(i);
                    GridView.Rows.Add(datas);
                }
            }
            reader.Close();
        }

        public virtual void Add(object sender, EventArgs eventArgs)
        {
            for (int i = 1; i < Columns.Count; i++) // первичный ключ не учитывается
            {
                if(!IsEmpty(ValueName[i]))
                {
                    MessageBox.Show("Одно или несколько полей не заполнены!", "Ошибка");
                    return;
                }
            }
            string sqlExpression = $"INSERT INTO {NameTable} ( ";
            for(int i = 1; i < Columns.Count;i++)
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
            catch(SqlException ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка");
                return;
            }
            MessageBox.Show("Запись добавлена", "Информация");
        }

        public virtual void Del(object sender, EventArgs eventArgs)
        {
            string sqlExpression = null;
            if ((ValueName[0] as TextBox).Text.Length != 0)
            {
                sqlExpression = $"DELETE FROM {NameTable} WHERE {Columns[0].First} = {(ValueName[0] as TextBox).Text}";
            }
            else
            {
                sqlExpression = $"DELETE FROM {NameTable} WHERE ";
                for (int i = 1; i < Columns.Count; i++)
                {
                    string result = GetValueSelect(ValueName[i], Columns[i].Second.First);
                    if (result != "")
                        sqlExpression += $"{Columns[i].First}  {result} AND ";
                }
                sqlExpression = sqlExpression.Remove(sqlExpression.Length - 5);
            }
            SqlCommand command = new SqlCommand(sqlExpression, DataBase); // связали запрос с базой
            int count = 0;
            try
            {
                count = command.ExecuteNonQuery(); // добавили строку
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка");
                return;
            }
            string outText = null;
            switch(count)
            {
                case 0:
                    outText = "Записи для удаления не найдены";
                    break;

                case 1:
                    outText = "Запись была удалена";
                    break;

                default:
                    outText = "Записи были удалены";
                    break;
            }
            MessageBox.Show(outText, "Информация");
        }

        public virtual void Update(object sender, EventArgs eventArgs)
        {
            bool result = false;
            for (int i = 1; i < Columns.Count; i++) // первичный ключ не учитывается
            {
                if (IsEmpty(ValueReplaceName[i]))
                {
                    result = true;
                    break;
                }
            }
            if(!result)
            {
                MessageBox.Show("Ни одно поле для обновления не заполнено!", "Ошибка");
                return;
            }
            string sqlExpression = $"UPDATE {NameTable} SET ";
            for (int i = 1; i < Columns.Count; i++)
            {
                string val = GetValueAdd(ValueReplaceName[i], Columns[i].Second.First);
                if(val != "")
                    sqlExpression += $"{Columns[i].First} = {val}, ";
            }
            sqlExpression = sqlExpression.Remove(sqlExpression.Length - 2) + $" WHERE {SpeqQuery} AND ";
            for (int i = 1; i < Columns.Count; i++)
            {
                string res = GetValueSelect(ValueName[i], Columns[i].Second.First);
                if (res != "")
                    sqlExpression += $"{Columns[i].First}  {res} AND ";
            }
            sqlExpression = sqlExpression.Remove(sqlExpression.Length - 5);
            SqlCommand command = new SqlCommand(sqlExpression, DataBase); // связали запрос с базой
            int count = 0;
            try
            {
                count = command.ExecuteNonQuery(); // обновили строку
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка");
                return;
            }
            string outText = null;
            switch (count)
            {
                case 0:
                    outText = "Записи для обновления не найдены";
                    break;

                case 1:
                    outText = "Запись была обновлена";
                    break;

                default:
                    outText = "Записи были обновлены";
                    break;
            }
            MessageBox.Show(outText, "Информация");
        }

    }
}