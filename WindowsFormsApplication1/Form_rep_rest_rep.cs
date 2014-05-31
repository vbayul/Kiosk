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
    public partial class Form_rep_rest_rep : Form
    {
        string[] data = new string[2];

        public Form_rep_rest_rep(string[] data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (data[0] == "0")
            {
                goodsTableAdapter1.FillBy3(kioskDataSet1.goods);

                CrystalReport_rest restReport = new CrystalReport_rest();
                restReport.SetDataSource(kioskDataSet1);
                crystalReportViewer1.ReportSource = restReport;
            }
            else
            {
                goodsTableAdapter1.FillBy2(kioskDataSet1.goods, Convert.ToInt32(data[1]));

                CrystalReport_rest restReport = new CrystalReport_rest();
                restReport.SetDataSource(kioskDataSet1);
                crystalReportViewer1.ReportSource = restReport;
            }
        }
    }
}
