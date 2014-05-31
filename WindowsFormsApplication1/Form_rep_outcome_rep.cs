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
    public partial class Form_rep_outcome_rep : Form
    {
        string[] data = new string[2];

        public Form_rep_outcome_rep(string[] data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Form_rep_outcome_rep_Load(object sender, EventArgs e)
        {
            outcomeTableAdapter1.FillBy(kioskDataSet1.outcome, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]));

            CrystalReport_outcome outcomeReport = new CrystalReport_outcome();
            outcomeReport.SetDataSource(kioskDataSet1);
            crystalReportViewer1.ReportSource = outcomeReport;
        }
    }
}
