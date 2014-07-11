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
    public partial class Form_rep_order_rep : Form
    {
        public Form_rep_order_rep(string[] date_time)
        {
            InitializeComponent();
            this.data = date_time;
        }

        string[] data = new string[3];

        private void Form_rep_order_rep_Load(object sender, EventArgs e)
        {
            if (data[2] == "2")
            {
                this.orderTableAdapter1.FillBy2(ordersDataSet1.order, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]));
            }
            else
            {
                if (data[2] == "1")
                {
                    this.orderTableAdapter1.FillBy3(ordersDataSet1.order, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]),1);
                }
                else
                {
                    this.orderTableAdapter1.FillBy3(ordersDataSet1.order, Convert.ToDateTime(data[0]), Convert.ToDateTime(data[1]),0);
                }
            }

            CrystalReport_order rep_order_rep = new CrystalReport_order();
            rep_order_rep.SetDataSource(ordersDataSet1);
            crystalReportViewer1.ReportSource = rep_order_rep;
        }
    }
}
