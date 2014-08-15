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
    public partial class Form_rep_writeoff_rep : Form
    {
        string[] data = new string[5];

        public Form_rep_writeoff_rep(string[] data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Formrep_writeoff_rep_Load(object sender, EventArgs e)
        {
            if (data[2] != "0")
            {
                if (data[3] == "0")
                {
                    this.writeoff_goodsTableAdapter.FillBy(kioskDataSet.writeoff_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]));

                    CrystalReport_writeoff writeoff = new CrystalReport_writeoff();
                    writeoff.SetDataSource(kioskDataSet);
                    crystalReportViewer1.ReportSource = writeoff;
                }
                else
                {
                    this.writeoff_goodsTableAdapter.FillBy2(kioskDataSet.writeoff_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]),Convert.ToInt32(data[3]));

                    CrystalReport_writeoff writeoff = new CrystalReport_writeoff();
                    writeoff.SetDataSource(kioskDataSet);
                    crystalReportViewer1.ReportSource = writeoff;
                }
            }
            else
            {
                if (data[3] == "0")
                {
                    this.writeoff_goodsTableAdapter.FillBy1(kioskDataSet.writeoff_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]));

                    CrystalReport_writeoff writeoff = new CrystalReport_writeoff();
                    writeoff.SetDataSource(kioskDataSet);
                    crystalReportViewer1.ReportSource = writeoff;
                }
                else
                {
                    this.writeoff_goodsTableAdapter.FillBy3(kioskDataSet.writeoff_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]), Convert.ToInt32(data[3]));

                    CrystalReport_writeoff writeoff = new CrystalReport_writeoff();
                    writeoff.SetDataSource(kioskDataSet);
                    crystalReportViewer1.ReportSource = writeoff;
                }
            }
        }
    }
}
