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
    public partial class Form_price : Form
    {
        public Form_price()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goods_insert();
        }
          
        private void button5_Click(object sender, EventArgs e)
        {
            // проверка на наличие какх либо записей
            if (dataGridView1.RowCount > 0)
            {
                int i = 0;
                while (i < dataGridView1.RowCount)
                {
                    // добавить товара в таблицу ценников
                    this.pricelistTableAdapter1.Insert(dataGridView1[0, i].Value.ToString(), dataGridView1[1, i].Value.ToString(), dataGridView1[2, i].Value.ToString());
                    i++;
                }
                // очищаем грид от предыдущих данных
                //dataGridView1.Rows.Clear();

                Form_price_rep price_pr = new Form_price_rep();
                price_pr.Owner = this;
                price_pr.ShowDialog(this);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
        }

        private void Form_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                Goods_insert();
            }
        }

        private void Goods_insert()
        {
            Form_goods goods_price = new Form_goods("0");
            goods_price.Owner = this;
            goods_price.ShowDialog(this);

            if (goods_price.DialogResult == DialogResult.OK)
            {
                string[] arr = new string[5];
                arr = goods_price.ReturnData();
                dataGridView1.Rows.Add(arr[0], arr[1], arr[2]);
            }
        }
    }
}
