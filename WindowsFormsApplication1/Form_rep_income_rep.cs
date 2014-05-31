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
    public partial class Form_rep_income_rep : Form
    {
        string[] data = new string[3];

        public Form_rep_income_rep(string[] data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Form_rep_income_rep_Load(object sender, EventArgs e)
        {
            if (data[0] == "0")
            {
                income_artTableAdapter1.FillBy1(kioskDataSet1.income_art, Convert.ToDateTime(data[1]), Convert.ToDateTime(data[2]));

                CrystalReport_income incomeReport = new CrystalReport_income();
                incomeReport.SetDataSource(kioskDataSet1);
                crystalReportViewer1.ReportSource = incomeReport;
            }
            else
            {
                income_artTableAdapter1.FillBy(kioskDataSet1.income_art, Convert.ToInt32(data[0]),Convert.ToDateTime(data[1]), Convert.ToDateTime(data[2]));

                CrystalReport_income incomeReport = new CrystalReport_income();
                incomeReport.SetDataSource(kioskDataSet1);
                crystalReportViewer1.ReportSource = incomeReport;
            }
            //MessageBox.Show(data[0]+", "+data[1]+", "+data[2]);
        }
    }
}
