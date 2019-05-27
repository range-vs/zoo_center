namespace cursovoy_var16
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Animal = new System.Windows.Forms.ToolStripMenuItem();
            this.Bird = new System.Windows.Forms.ToolStripMenuItem();
            this.Reptiloid = new System.Windows.Forms.ToolStripMenuItem();
            this.Diet = new System.Windows.Forms.ToolStripMenuItem();
            this.Zone = new System.Windows.Forms.ToolStripMenuItem();
            this.Employee = new System.Windows.Forms.ToolStripMenuItem();
            this.Marital = new System.Windows.Forms.ToolStripMenuItem();
            this.Veterinarian = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryFirstAction = new System.Windows.Forms.ToolStripMenuItem();
            this.QuerySecondAction = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryThirdAction = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.Diet,
            this.Zone,
            this.Employee,
            this.Marital,
            this.Veterinarian});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(86, 20);
            this.toolStripMenuItem1.Text = "База данных";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Animal,
            this.Bird,
            this.Reptiloid});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem3.Text = "Питомец";
            // 
            // Animal
            // 
            this.Animal.Name = "Animal";
            this.Animal.Size = new System.Drawing.Size(133, 22);
            this.Animal.Text = "Животное";
            this.Animal.Click += new System.EventHandler(this.AnimalWindowClick);
            // 
            // Bird
            // 
            this.Bird.Name = "Bird";
            this.Bird.Size = new System.Drawing.Size(133, 22);
            this.Bird.Text = "Птица";
            this.Bird.Click += new System.EventHandler(this.BirdWindowClick);
            // 
            // Reptiloid
            // 
            this.Reptiloid.Name = "Reptiloid";
            this.Reptiloid.Size = new System.Drawing.Size(133, 22);
            this.Reptiloid.Text = "Рептилоид";
            this.Reptiloid.Click += new System.EventHandler(this.ReptiloidWindowClick);
            // 
            // Diet
            // 
            this.Diet.Name = "Diet";
            this.Diet.Size = new System.Drawing.Size(184, 22);
            this.Diet.Text = "Рацион";
            this.Diet.Click += new System.EventHandler(this.DietWindowClick);
            // 
            // Zone
            // 
            this.Zone.Name = "Zone";
            this.Zone.Size = new System.Drawing.Size(184, 22);
            this.Zone.Text = "Среда обитания";
            this.Zone.Click += new System.EventHandler(this.ZoneWindowClick);
            // 
            // Employee
            // 
            this.Employee.Name = "Employee";
            this.Employee.Size = new System.Drawing.Size(184, 22);
            this.Employee.Text = "Сотрудники";
            this.Employee.Click += new System.EventHandler(this.EmployeeWindowClick);
            // 
            // Marital
            // 
            this.Marital.Name = "Marital";
            this.Marital.Size = new System.Drawing.Size(184, 22);
            this.Marital.Text = "Сотрудники в браке";
            this.Marital.Click += new System.EventHandler(this.MaritalWindowClick);
            // 
            // Veterinarian
            // 
            this.Veterinarian.Name = "Veterinarian";
            this.Veterinarian.Size = new System.Drawing.Size(184, 22);
            this.Veterinarian.Text = "Ветеринары";
            this.Veterinarian.Click += new System.EventHandler(this.VeterinarianWindowClick);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QueryFirstAction,
            this.QuerySecondAction,
            this.QueryThirdAction});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // QueryFirstAction
            // 
            this.QueryFirstAction.Name = "QueryFirstAction";
            this.QueryFirstAction.Size = new System.Drawing.Size(466, 22);
            this.QueryFirstAction.Text = "Информация по типу и имени питомца";
            this.QueryFirstAction.Click += new System.EventHandler(this.QueryFirstActionClick);
            // 
            // QuerySecondAction
            // 
            this.QuerySecondAction.Name = "QuerySecondAction";
            this.QuerySecondAction.Size = new System.Drawing.Size(466, 22);
            this.QuerySecondAction.Text = "Список сотрудников, состоящих в браке";
            this.QuerySecondAction.Click += new System.EventHandler(this.QuerySecondActionClick);
            // 
            // QueryThirdAction
            // 
            this.QueryThirdAction.Name = "QueryThirdAction";
            this.QueryThirdAction.Size = new System.Drawing.Size(466, 22);
            this.QueryThirdAction.Text = "Перечень питомцев, рождённых в заданную дату и номер их рационов";
            this.QueryThirdAction.Click += new System.EventHandler(this.QueryThirdActionClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn5.HeaderText = "id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "date_start";
            this.dataGridViewTextBoxColumn6.HeaderText = "date_start";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "date_finish";
            this.dataGridViewTextBoxColumn7.HeaderText = "date_finish";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "id_animal";
            this.dataGridViewTextBoxColumn8.HeaderText = "id_animal";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 319);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(67, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Зоологический центр \"Сафари\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Юридический адрес: г. Воронеж, ул. Солнечная, 236";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Телефон: +7-952-698-33-69";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Рабочий: +7-473-269-88-13";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "e-mail: zoogarden-vrn@gmail.com";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Сайт: zoogarden-vrn.com";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::cursovoy_var16.Properties.Resources.Flowers_frame__4__602145f5;
            this.pictureBox2.Location = new System.Drawing.Point(0, 414);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1013, 182);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::cursovoy_var16.Properties.Resources._18450;
            this.pictureBox1.Location = new System.Drawing.Point(595, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(418, 330);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(779, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 26);
            this.label7.TabIndex = 4;
            this.label7.Text = "Мы всегда Вам рады!";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1013, 596);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1029, 635);
            this.Name = "MainWindow";
            this.Text = "Зоопарк";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem Diet;
        private System.Windows.Forms.ToolStripMenuItem Zone;
        private System.Windows.Forms.ToolStripMenuItem Employee;
        private System.Windows.Forms.ToolStripMenuItem Veterinarian;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QueryFirstAction;
        private System.Windows.Forms.ToolStripMenuItem QuerySecondAction;
        private System.Windows.Forms.ToolStripMenuItem QueryThirdAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ToolStripMenuItem Animal;
        private System.Windows.Forms.ToolStripMenuItem Bird;
        private System.Windows.Forms.ToolStripMenuItem Reptiloid;
        private System.Windows.Forms.ToolStripMenuItem Marital;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
    }
}

