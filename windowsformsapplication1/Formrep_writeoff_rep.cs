using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Formrep_writeoff_rep : Form
    {
        public Formrep_writeoff_rep()
        {
            InitializeComponent();
        }

        private void Formrep_writeoff_rep_Load(object sender, EventArgs e)
        {
            this.writeoff_goodsTableAdapter.Fill(kioskDataSet.writeoff_goods);

            CrystalReport_writeoff writeoff = new CrystalReport_writeoff();
            writeoff.SetDataSource(kioskDataSet);
            crystalReportViewer1.ReportSource = writeoff;
        }
    }
}
