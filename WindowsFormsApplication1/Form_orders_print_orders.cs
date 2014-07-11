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
    public partial class Form_orders_print_orders : Form
    {
        public Form_orders_print_orders(int order, int type_rep)
        {
            InitializeComponent();
            this.order = order;
            this.type_rep = type_rep;
        }

        int order, type_rep;

        private void Form_orders_print_orders_Load(object sender, EventArgs e)
        {
            if (type_rep == 0)
            {
                this.orderTableAdapter.FillBy(ordersDataSet.order, order);

                CrystalReport_order_print_order order_print_order = new CrystalReport_order_print_order();
                order_print_order.SetDataSource(ordersDataSet);
                crystalReportViewer1.ReportSource = order_print_order;
            }
            else
            {
                this.orderTableAdapter.FillBy(ordersDataSet.order, order);

                CrystalReport_order_print_gara order_print_dara = new CrystalReport_order_print_gara();
                order_print_dara.SetDataSource(ordersDataSet);
                crystalReportViewer1.ReportSource = order_print_dara;
            }
        }
    }
}
