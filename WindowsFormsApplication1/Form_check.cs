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
    public partial class Form_check : Form
    {
        public Form_check()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_check_sale check_sale = new Form_check_sale(dateTimePicker1.Value.ToString());
            check_sale.Owner = this;
            check_sale.ShowDialog(this);
            if (check_sale.DialogResult == DialogResult.OK)
            {
                string[] retArray = new string[7];
                retArray = check_sale.RetunData();
                dataGridView1.Rows.Add(retArray[6],retArray[0],retArray[1],retArray[2],retArray[3],retArray[4],retArray[5]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                int new_count_check;
                new_count_check = Convert.ToInt32(checkTableAdapter1.ScalarQuery().ToString()) + 1;
                int i = 0;
                while (i < dataGridView1.RowCount)
                {
                    // добавить товара в таблицу ценников
                    this.checkTableAdapter1.Insert(new_count_check, Convert.ToInt32(dataGridView1[0, i].Value.ToString()), Convert.ToDateTime(dateTimePicker1.Value.ToString()));
                    i++;
                }

                Form_check_rep check_print = new Form_check_rep(new_count_check);
                check_print.Owner = this;
                check_print.ShowDialog(this);

                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Не указаны продажи.");
            }
        }

        private void Form_check_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
        }
    }
}
