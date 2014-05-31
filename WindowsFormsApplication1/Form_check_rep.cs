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
    public partial class Form_check_rep : Form
    {
        int check_number;

        public Form_check_rep(int data)
        {
            InitializeComponent();
            check_number = data;
        }

        private void Form_check_rep_Load(object sender, EventArgs e)
        {
            checkTableAdapter1.FillBy(kioskDataSet1.check, check_number);
            check_goodsTableAdapter1.Fill(kioskDataSet1.check_goods, check_number);

            CrystalReport_check_print check_print = new CrystalReport_check_print();
            check_print.SetDataSource(kioskDataSet1);
            crystalReportViewer1.ReportSource = check_print;
        }
    }
}
