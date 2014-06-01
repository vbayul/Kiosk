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
        string[] data = new string[5];

        public Form_rep_sale_rep(string[] data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Form_rep_sale_rep_Load(object sender, EventArgs e)
        {
                if (data[3] != "0")
                {
                    if (data[2] != "0")
                    {
                        // выбран товар и выбран развернутый отчет
                        sale_goodsTableAdapter1.FillBy5(kioskDataSet1.sale_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]), Convert.ToInt32(data[3]));

                        CrystalReport_sale saleReport = new CrystalReport_sale();
                        saleReport.SetDataSource(kioskDataSet1);
                        crystalReportViewer1.ReportSource = saleReport;
                    }
                    else
                    {
                        //выбран товар и сокращенный отчет
                        sale_goodsTableAdapter1.FillBy4(kioskDataSet1.sale_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]), Convert.ToInt32(data[3]));

                        CrystalReport_sale saleReport = new CrystalReport_sale();
                        saleReport.SetDataSource(kioskDataSet1);
                        crystalReportViewer1.ReportSource = saleReport;
                    }
                }

                if (data[4] != "0")
                {
                    if (data[2] != "0")
                    {
                        // выбран товар и выбран развернутый отчет
                        sale_goodsTableAdapter1.FillBy6(kioskDataSet1.sale_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]), Convert.ToInt32(data[4]));

                        CrystalReport_sale saleReport = new CrystalReport_sale();
                        saleReport.SetDataSource(kioskDataSet1);
                        crystalReportViewer1.ReportSource = saleReport;
                    }
                    else
                    {
                        //выбран товар и сокращенный отчет
                        sale_goodsTableAdapter1.FillBy7(kioskDataSet1.sale_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]), Convert.ToInt32(data[4]));

                        CrystalReport_sale saleReport = new CrystalReport_sale();
                        saleReport.SetDataSource(kioskDataSet1);
                        crystalReportViewer1.ReportSource = saleReport;
                    }
                }


                if (data[3] == "0" && data[4] == "0")
                {
                    //не выбран товар
                    if (data[2] != "0")
                    {
                        //не выбран товар и выбран развернутый
                        sale_goodsTableAdapter1.FillBy1(kioskDataSet1.sale_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]));

                        CrystalReport_sale saleReport = new CrystalReport_sale();
                        saleReport.SetDataSource(kioskDataSet1);
                        crystalReportViewer1.ReportSource = saleReport;
                    }
                    else
                    {
                        //не выбран товар и скоращенный
                        sale_goodsTableAdapter1.FillBy3(kioskDataSet1.sale_goods, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]));

                        CrystalReport_sale saleReport = new CrystalReport_sale();
                        saleReport.SetDataSource(kioskDataSet1);
                        crystalReportViewer1.ReportSource = saleReport;
                    }
                }
        }
    }
}
