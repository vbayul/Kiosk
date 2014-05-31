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
    public partial class Form_rep_sale_rep : Form
    {
        string[] data = new string[3];

        public Form_rep_sale_rep(string[] data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Form_rep_sale_rep_Load(object sender, EventArgs e)
        {
            if (data[2] == "1")
            {
                sale_goodsTableAdapter1.FillBy1(kioskDataSet1.sale_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]));

                CrystalReport_sale saleReport = new CrystalReport_sale();
                saleReport.SetDataSource(kioskDataSet1);
                crystalReportViewer1.ReportSource = saleReport;
            }
            else
            {
                sale_goodsTableAdapter1.FillBy3(kioskDataSet1.sale_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]));
                //заменить на группировку товара по продажам

                CrystalReport_sale saleReport = new CrystalReport_sale();
                saleReport.SetDataSource(kioskDataSet1);
                crystalReportViewer1.ReportSource = saleReport;
            }
        }
    }
}
