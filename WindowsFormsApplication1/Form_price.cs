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
            Form_goods goods_price = new Form_goods("0");
            goods_price.Owner = this;
            goods_price.ShowDialog(this);

            if (goods_price.DialogResult == DialogResult.OK)
            {
                string[] arr = new string[5];
                arr = goods_price.ReturnData();
                textBox1.Text = arr[0];
                textBox2.Text = arr[1];
                textBox3.Text = arr[2];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text.Length < 13)
                textBox2.Clear();
                textBox3.Clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text.Length > 0)
            {
                // дописать запрос который выбирает нужный товар по штрихкоду и заполняет поля
                // в противном случае выдает что товар не найден.
                // переделать под массив
                if (this.goodsTableAdapter1.ScalarQuery(textBox1.Text).ToString() == "1")
                {
                    this.textBox2.Text = this.goodsTableAdapter1.GetDataBy3(textBox1.Text)[0][1].ToString();
                    this.textBox3.Text = this.goodsTableAdapter1.GetDataBy3(textBox1.Text)[0][4].ToString();
                }
                else
                {
                    MessageBox.Show("Товар не найден!");
                }
                //this.textBox1.Text = this.goodsTableAdapter1.GetDataBy(textBox2.Text)[0][1].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
                ClearText();
            }
            else
            {
                MessageBox.Show("Не все поля заполненны!");
            }
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
                dataGridView1.Rows.Clear();

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
    }
}
