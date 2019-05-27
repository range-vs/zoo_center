using cursovoy_var16.Querys;
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

namespace cursovoy_var16.Forms.AddUpdateDelete.Animals
{
    public partial class FormTable : Form
    {
        public PanelQuery PanelQ { get; set; }

        public FormTable(PanelQuery pq)
        {
            InitializeComponent();
            PanelQ = pq;
            Controls.Add(PanelQ);
        }

        private void FormLoad(object sender, EventArgs e)
        {
            PanelQ.GridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }
    }
}
