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
    public partial class Form_write_off : Form
    {
        public Form_write_off()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_goods income_goods = new Form_goods("1");
            income_goods.Owner = this;
            income_goods.ShowDialog(this);

            if (income_goods.DialogResult == DialogResult.OK)
            {
                // создаем массив который принимает результаты из дочерней формы
                string[] arr = new string[5];
                // присваиваем массив из дочерней формы массиву из родительской формы который был тольк очто создан.
                arr = income_goods.ReturnData();
                // штрихкод
                textBox4.Text = arr[0];
                // название
                textBox2.Text = arr[1];
                // id
                textBox1.Text = arr[4];
            }
            textBox3.Clear();
            textBox3.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Row();

        }

        private int Find()
        {
            int ret=0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (dataGridView1[0, i].FormattedValue.ToString().StartsWith(textBox1.Text.Trim()))
                {
                    ret = 1;
                }
            return ret;
        }

        private void Add_Row()
        {
            if (textBox1.Text != "" && textBox3.Text != "")
            {
                if (Find() == 0)
                {
                    if (Convert.ToInt32(this.goodsTableAdapter1.GetDataBy3(textBox4.Text)[0][7].ToString()) >= Convert.ToInt32(textBox3.Text))
                    {
                        dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
                        button1.Focus();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                    }
                    else
                    {
                        MessageBox.Show("На остатке нет такого количества товара!");
                    }
                }
                else
                {
                    MessageBox.Show("Товар уже добавлен в списание!");
                }
            }
            else
            {
                MessageBox.Show("Товар не указан!");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Add_Row();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                int i = 0;
                while (i < dataGridView1.RowCount)
                {
                    // убираем количество с остатков
                    this.goodsTableAdapter1.UpdateQuery2(Convert.ToString(Convert.ToInt32(dataGridView1[2, i].Value.ToString())*(-1)), dataGridView1[0, i].Value.ToString());
                    // добавляем в таблицу списаний
                    this.writeoffTableAdapter.Insert(Convert.ToInt32(dataGridView1[0, i].Value.ToString()), Convert.ToInt32(dataGridView1[2, i].Value.ToString()), DateTime.Now);
                    i++;
                }
                MessageBox.Show("Товар списан успешно!");
                dataGridView1.Rows.Clear();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Clear();
                textBox3.Clear();
                textBox2.Clear();
                textBox4.Clear();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
                        //if (e.KeyCode == Keys.Enter && textBox2.Text.Length == 13)
            if (e.KeyCode == Keys.Enter && textBox4.Text.Length > 0)
            {
                // дописать запрос который выбирает нужный товар по штрихкоду и заполняет поля
                // в противном случае выдает что товар не найден.
                // переделать под массив
                if (this.goodsTableAdapter1.ScalarQuery(textBox4.Text).ToString() == "1")
                {
                    this.textBox2.Text = this.goodsTableAdapter1.GetDataBy3(textBox4.Text)[0][1].ToString();
                    this.textBox1.Text = this.goodsTableAdapter1.GetDataBy3(textBox4.Text)[0][0].ToString();
                    textBox3.Focus();
                 }
                else
                {
                    MessageBox.Show("Товар не найден!");
                }
                //this.textBox1.Text = this.goodsTableAdapter1.GetDataBy(textBox2.Text)[0][1].ToString();
            }
        }

        private void Form_write_off_Load(object sender, EventArgs e)
        {

        }
    }
}
