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
    public partial class Form_rep_by_day_rep : Form
    {
        string[] data= new string[2];

        public Form_rep_by_day_rep(string[] d)
        {
            InitializeComponent();
            this.data = d;
        }

        private void Form_rep_by_day_rep_Load(object sender, EventArgs e)
        {
            outrepTableAdapter.Fill(kioskDataSet.outrep, data[0], data[1], data[0], data[1]);

            salerepTableAdapter.Fill(kioskDataSet.salerep, data[0], data[1]);

            CrystalReport_rep_by_day rep_by_day = new CrystalReport_rep_by_day();
            rep_by_day.SetDataSource(kioskDataSet);
            crystalReportViewer1.ReportSource = rep_by_day;
        }
    }
}
