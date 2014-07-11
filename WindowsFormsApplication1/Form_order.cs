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
    public partial class Form_order : Form
    {
        public Form_order()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_order_new order_edit = new Form_order_new(Convert.ToInt32(this.orderTableAdapter.ScalarQuery().ToString())+1,1);
            order_edit.Owner = this;
            order_edit.ShowDialog();
            {
                Reload();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                Edit();
            }
        }

        private void Form_order_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ordersDataSet.order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter.Fill(this.ordersDataSet.order);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }

        private void Reload()
        {
            if (textBox1.Text != "")
            {
                this.orderTableAdapter.FillBy1(this.ordersDataSet.order,Convert.ToInt32(textBox1.Text));
                dataGridView1.Focus();
            }
            else
            {
                this.orderTableAdapter.Fill(this.ordersDataSet.order);
            }
        }

        private void Edit()
        {
            Form_order_new order_edit = new Form_order_new(Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString()), 0);
            order_edit.Owner = this;
            order_edit.ShowDialog();
            if (order_edit.DialogResult == DialogResult.OK)
            {
                Reload();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(13))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Reload();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.RowCount != 0)
            {
                Edit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Reload();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
