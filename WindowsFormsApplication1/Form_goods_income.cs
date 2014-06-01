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
    public partial class Form_goods_income : Form
    {

        public Form_goods_income()
        {
            InitializeComponent();
        }

        private void Form_goods_income_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox4.Text != "")
            {
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                ClearTextBox();
            }
            else
            {
                MessageBox.Show("Товар не указан!");
            }
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
                textBox2.Text = arr[0];
                // название
                textBox3.Text = arr[1];
                // id
                textBox1.Text = arr[4];
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // очищаем поля, когда штрих код начинают редактировать.
            //if (textBox2.Text.Length < 13 && textBox1.Text != "")
            if (textBox1.Text != "")
            {
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && textBox2.Text.Length == 13)
            if (e.KeyCode == Keys.Enter && textBox2.Text.Length > 0)
            {
                // дописать запрос который выбирает нужный товар по штрихкоду и заполняет поля
                // в противном случае выдает что товар не найден.
                // переделать под массив
                if (this.goodsTableAdapter1.ScalarQuery(textBox2.Text).ToString() == "1")
                {
                    this.textBox1.Text = this.goodsTableAdapter1.GetDataBy3(textBox2.Text)[0][1].ToString();
                    this.textBox3.Text = this.goodsTableAdapter1.GetDataBy3(textBox2.Text)[0][0].ToString();
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
            ClearTextBox();
        }

        private void ClearTextBox()
        {
            textBox1.Clear();
            textBox2.Clear(); 
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // очищаем грид 
            dataGridView1.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // проверка на наличие какх либо записей
            if (dataGridView1.RowCount > 0)
            {
                int i = 0;
                while (i < dataGridView1.RowCount)
                {
                    // добавить товара в таблицу призодов
                    this.in_artTableAdapter.Insert(dataGridView1[0, i].Value.ToString(), dataGridView1[3, i].Value.ToString(), DateTime.Now);
                    // добавление товара на остатки в таблицу товаров
                    this.goodsTableAdapter1.UpdateQuery2(dataGridView1[3, i].Value.ToString(), dataGridView1[0, i].Value.ToString());
                    i++;
                }
                // очищаем грид от предыдущих данных
                dataGridView1.Rows.Clear();

                MessageBox.Show("Товар добавлен в базу!");
            }
            else
            {
                MessageBox.Show("Товар не внесен!");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
