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
    public partial class Form_price_rep : Form
    {
        public Form_price_rep()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pricelistTableAdapter1.Fill(kioskDataSet1.pricelist);

            CrystalReport_pricelist priceReport = new CrystalReport_pricelist();
            priceReport.SetDataSource(kioskDataSet1);
            crystalReportViewer1.ReportSource = priceReport;

            pricelistTableAdapter1.DeleteQuery();
        }

    }
}
