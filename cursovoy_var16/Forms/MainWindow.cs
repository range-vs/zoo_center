using cursovoy_var16.Forms.AddUpdateDelete.Animals;
using cursovoy_var16.Forms.Query;
using cursovoy_var16.Querys;
using cursovoy_var16.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cursovoy_var16
{
    public partial class MainWindow : Form
    {
        public SqlConnection DataBase { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            // подключаемся к БД
            string connectionString = @"Data Source=LAPTOP-GOG9SDSJ\SQLEXPRESS;Initial Catalog=Zoo;Integrated Security=True";
            if (!Init(connectionString))
                Application.Exit();
        }

        public bool Init(string connectionString)
        {
            bool result = true;
            // Создание подключения
            DataBase = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                DataBase.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                result = false;
            }
            return result;
        }

        private void AnimalWindowClick(object sender, EventArgs e)
        {
            List<Pair<string, Pair<int, string>>> pairs = new List<Pair<string, Pair<int, string>>>
            {
                new Pair<string, Pair<int, string>>("id", new Pair<int, string>(0, "ID")),
                new Pair<string, Pair<int, string>>("name", new Pair<int, string>(0, "Наименование питомца")),
                new Pair<string, Pair<int, string>>("date_birth", new Pair<int, string>(2, "День рождения")),
                new Pair<string, Pair<int, string>>("sex", new Pair<int, string>(1, "Пол(м/ж)")),
                new Pair<string, Pair<int, string>>("id_diet", new Pair<int, string>(0, "ID рациона")),
                new Pair<string, Pair<int, string>>("id_zone_habiat", new Pair<int, string>(0, "ID среды обитания")),
                new Pair<string, Pair<int, string>>("id_employee", new Pair<int, string>(0, "ID сотрудника")),
                new Pair<string, Pair<int, string>>("id_veterinarian", new Pair<int, string>(0, "ID ветеринара"))
            };
            PanelQuery panelQuery = new PanelQuery(pairs, DataBase, "animal", "date_finish is NULL AND date_start is NULL AND temperatures is NULL AND hibernation_period is NULL");
            Form form = new Form
            {
                Size = new System.Drawing.Size(1341, 719)
            };
            form.Controls.Add(panelQuery);
            panelQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panelQuery.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void BirdWindowClick(object sender, EventArgs e)
        {
            List<Pair<string, Pair<int, string>>> pairs = new List<Pair<string, Pair<int, string>>>
            {
                new Pair<string, Pair<int, string>>("id", new Pair<int, string>(0, "ID")),
                new Pair<string, Pair<int, string>>("name", new Pair<int, string>(0, "Наименование питомца")),
                new Pair<string, Pair<int, string>>("date_birth", new Pair<int, string>(2, "День рождения")),
                new Pair<string, Pair<int, string>>("sex", new Pair<int, string>(1, "Пол(м/ж)")),
                new Pair<string, Pair<int, string>>("id_diet", new Pair<int, string>(0, "ID рациона")),
                new Pair<string, Pair<int, string>>("id_zone_habiat", new Pair<int, string>(0, "ID среды обитания")),
                new Pair<string, Pair<int, string>>("id_employee", new Pair<int, string>(0, "ID сотрудника")),
                new Pair<string, Pair<int, string>>("id_veterinarian", new Pair<int, string>(0, "ID ветеринара")),
                new Pair<string, Pair<int, string>>("date_start", new Pair<int, string>(2, "День отлета")),
                new Pair<string, Pair<int, string>>("date_finish", new Pair<int, string>(2, "День прилёта")),
            };
            PanelQuery panelQuery = new PanelQuery(pairs, DataBase, "animal", "temperatures is NULL AND hibernation_period is NULL AND date_finish is NOT NULL AND date_start is NOT NULL");
            Form form = new Form
            {
                Size = new System.Drawing.Size(1341, 719)
            };
            form.Controls.Add(panelQuery);
            panelQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panelQuery.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void ReptiloidWindowClick(object sender, EventArgs e)
        {
            List<Pair<string, Pair<int, string>>> pairs = new List<Pair<string, Pair<int, string>>>
            {
                new Pair<string, Pair<int, string>>("id", new Pair<int, string>(0, "ID")),
                new Pair<string, Pair<int, string>>("name", new Pair<int, string>(0, "Наименование питомца")),
                new Pair<string, Pair<int, string>>("date_birth", new Pair<int, string>(2, "День рождения")),
                new Pair<string, Pair<int, string>>("sex", new Pair<int, string>(1, "Пол(м/ж)")),
                new Pair<string, Pair<int, string>>("id_diet", new Pair<int, string>(0, "ID рациона")),
                new Pair<string, Pair<int, string>>("id_zone_habiat", new Pair<int, string>(0, "ID среды обитания")),
                new Pair<string, Pair<int, string>>("id_employee", new Pair<int, string>(0, "ID сотрудника")),
                new Pair<string, Pair<int, string>>("id_veterinarian", new Pair<int, string>(0, "ID ветеринара")),
                new Pair<string, Pair<int, string>>("temperatures", new Pair<int, string>(0, "Температура")),
                new Pair<string, Pair<int, string>>("hibernation_period", new Pair<int, string>(0, "Период спячки(месяцы)")),
            };
            PanelQuery panelQuery = new PanelQuery(pairs, DataBase, "animal", "temperatures is NOT NULL AND hibernation_period is NOT NULL AND date_finish is  NULL AND date_start is  NULL");
            Form form = new Form
            {
                Size = new System.Drawing.Size(1341, 719)
            };
            form.Controls.Add(panelQuery);
            panelQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panelQuery.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void DietWindowClick(object sender, EventArgs e)
        {
            List<Pair<string, Pair<int, string>>> pairs = new List<Pair<string, Pair<int, string>>>
            {
                new Pair<string, Pair<int, string>>("id", new Pair<int, string>(0, "ID")),
                new Pair<string, Pair<int, string>>("name", new Pair<int, string>(0, "Наименование рациона")),
                new Pair<string, Pair<int, string>>("id_type_diet", new Pair<int, string>(0, "ID типа рациона"))
            };
            PanelQuery panelQuery = new PanelQuery(pairs, DataBase, "diet");
            Form form = new Form
            {
                Size = new System.Drawing.Size(1341, 719)
            };
            form.Controls.Add(panelQuery);
            panelQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panelQuery.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void ZoneWindowClick(object sender, EventArgs e)
        {
            List<Pair<string, Pair<int, string>>> pairs = new List<Pair<string, Pair<int, string>>>
            {
                new Pair<string, Pair<int, string>>("id", new Pair<int, string>(0, "ID")),
                new Pair<string, Pair<int, string>>("name", new Pair<int, string>(0, "Наименование среды обитания")),
                new Pair<string, Pair<int, string>>("characters", new Pair<int, string>(0, "Характеристика"))
            };
            PanelQuery panelQuery = new PanelQuery(pairs, DataBase, "zone_habitat");
            Form form = new Form
            {
                Size = new System.Drawing.Size(1341, 719)
            };
            form.Controls.Add(panelQuery);
            panelQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panelQuery.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void EmployeeWindowClick(object sender, EventArgs e)
        {
            List<Pair<string, Pair<int, string>>> pairs = new List<Pair<string, Pair<int, string>>>
            {
                new Pair<string, Pair<int, string>>("id", new Pair<int, string>(0, "ID")),
                new Pair<string, Pair<int, string>>("first_name", new Pair<int, string>(0, "Фамилия")),
                new Pair<string, Pair<int, string>>("last_name", new Pair<int, string>(0, "Имя")),
                new Pair<string, Pair<int, string>>("middle_name", new Pair<int, string>(0, "Отчество")),
                new Pair<string, Pair<int, string>>("date_birth", new Pair<int, string>(2, "Дата рождения")),
                new Pair<string, Pair<int, string>>("phone", new Pair<int, string>(0, "Номер телефона")),
                new Pair<string, Pair<int, string>>("sex", new Pair<int, string>(0, "Пол(м/ж)"))
            };
            PanelQuery panelQuery = new PanelQuery(pairs, DataBase, "employee");
            Form form = new Form
            {
                Size = new System.Drawing.Size(1341, 719)
            };
            form.Controls.Add(panelQuery);
            panelQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panelQuery.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void VeterinarianWindowClick(object sender, EventArgs e)
        {
            List<Pair<string, Pair<int, string>>> pairs = new List<Pair<string, Pair<int, string>>>
            {
                new Pair<string, Pair<int, string>>("id", new Pair<int, string>(0, "ID")),
                new Pair<string, Pair<int, string>>("first_name", new Pair<int, string>(0, "Фамилия")),
                new Pair<string, Pair<int, string>>("last_name", new Pair<int, string>(0, "Имя")),
                new Pair<string, Pair<int, string>>("middle_name", new Pair<int, string>(0, "Отчество")),
                new Pair<string, Pair<int, string>>("date_birth", new Pair<int, string>(2, "Дата рождения")),
                new Pair<string, Pair<int, string>>("sex", new Pair<int, string>(0, "Пол(м/ж)"))
            };
            PanelQuery panelQuery = new PanelQuery(pairs, DataBase, "veterinarian");
            Form form = new Form
            {
                Size = new System.Drawing.Size(1341, 719)
            };
            form.Controls.Add(panelQuery);
            panelQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panelQuery.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void MaritalWindowClick(object sender, EventArgs e)
        {
            List<Pair<string, Pair<int, string>>> pairs = new List<Pair<string, Pair<int, string>>>
            {
                new Pair<string, Pair<int, string>>("id", new Pair<int, string>(0, "ID")),
                new Pair<string, Pair<int, string>>("id_hushband", new Pair<int, string>(0, "ID мужа")),
                new Pair<string, Pair<int, string>>("id_wife", new Pair<int, string>(0, "ID жены"))
            };
            PanelQueryMaritalStatus panelQuery = new PanelQueryMaritalStatus(pairs, DataBase, "marital_status");
            Form form = new Form
            {
                Size = new System.Drawing.Size(1341, 719)
            };
            form.Controls.Add(panelQuery);
            panelQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panelQuery.Dock = DockStyle.Fill;
            form.ShowDialog();
        }

        private void QueryFirstActionClick(object sender, EventArgs e)
        {
            FirstQuery fq = new FirstQuery(DataBase);
            fq.ShowDialog();
        }

        private void QuerySecondActionClick(object sender, EventArgs e)
        {
            SecondQuery sq = new SecondQuery(DataBase);
            sq.ShowDialog();
        }

        private void QueryThirdActionClick(object sender, EventArgs e)
        {
            ThirdQuery tq = new ThirdQuery(DataBase);
            tq.ShowDialog();
        }
    }
}
