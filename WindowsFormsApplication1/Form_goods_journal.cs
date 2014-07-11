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
    public partial class Form_goods_journal : Form
    {
        public Form_goods_journal()
        {
            InitializeComponent();
        }

        private void Form_goods_journal_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
            this.goodseditTableAdapter.Fill(this.kioskDataSet.goodsedit);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //  процедура поиска по выбраному полю dataGridVeiw
            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (dataGridView1[dataGridView1.CurrentCell.ColumnIndex, i].FormattedValue.ToString().Contains(textBox1.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, i];
                    return;
                }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // передаем id В текстовое поле
            textBox8.Text = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // штрихкод
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // название
            textBox3.Text = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // цена покупки
            textBox4.Text = dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // цена продажи
            textBox5.Text = dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // название типа товара
            textBox7.Text = dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // id типа товара
            textBox6.Text = dataGridView1[9, dataGridView1.CurrentCell.RowIndex].Value.ToString();

            checkBox1.Checked = Convert.ToBoolean(Convert.ToInt32(dataGridView1[8, dataGridView1.CurrentCell.RowIndex].Value.ToString()));
            /*if (dataGridView1[8, dataGridView1.CurrentCell.RowIndex].Value.ToString() == "0")
            {
                checkBox1.Checked = false;
            }
            else 
            {
                checkBox1.Checked = true; 
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // INSERT INTO `goods` (`name`, `barcode`, `price_bay`, `price_sale`, `edit`, `type`, `count`, `status`) VALUES (?, ?, ?, ?, ?, ?, ?, ?)
            // создаем новую позицию 
            // обязательно проверяем есть ли такой штрих код в базе
            // MessageBox.Show(Convert.ToString ( Convert.ToInt32 ( Convert.ToBoolean(checkBox1.Checked.ToString()))));
            if (textBox8.Text == "")
            {
                if (textBox6.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    if (this.goodsTableAdapter1.ScalarQuery(textBox2.Text).ToString() == "0")
                    {
                        this.goodsTableAdapter1.InsertQuery(textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(Convert.ToBoolean(checkBox1.Checked.ToString())), Convert.ToInt16(textBox6.Text), 0, 1).ToString();

                        // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
                        this.goodseditTableAdapter.Fill(this.kioskDataSet.goodsedit);

                        clear_goods();
                    }
                    else
                    {
                        MessageBox.Show("Товар с таким штрихкодом уже есть в базе!");
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!");
                }
            }
            else
            {
                MessageBox.Show("Товар уже есть в базе!");
            }
            // дописать проверку заполненности всех полей в плане правильности заполненности полей.
            // сохраненный заранее запрос и мы ему передаем только нужные параметры. и он сука работает
            //this.goodsTableAdapter1.InsertQuery(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // редактируем существующую позици
            // обязательно проверяем заполнена ли позиция текстбокса7
            // меняем всё кроме штрих кода
            //this.goodsTableAdapter1.FillBy1(textBox2.Text);

            // рабочая строка
            //textBox1.Text = goodsTableAdapter1.FillBy1(textBox2.Text).ToString();
            //textBox2.Text = dt.Rows[0]["barcode"].ToString();

            // этим кодом мы вытягиваем их запроса с несколькими колонками, нужные нам данные.
            // первые квадратные ковычки это строка, вторые квадратные ковычки это колонка.
            //this.textBox1.Text = this.goodsTableAdapter1.GetDataBy2(textBox2.Text)[0][1].ToString();
            if (textBox8.Text != "" && textBox6.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                if (textBox8.Text != "")
                {

                    if (this.goodsTableAdapter1.ScalarQuery(textBox2.Text).ToString() == "1" || this.goodsTableAdapter1.ScalarQuery(textBox2.Text).ToString() == "0")
                    {
                        this.goodsTableAdapter1.UpdateQuery1(textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt16(Convert.ToBoolean(checkBox1.Checked.ToString())), Convert.ToInt16(textBox6.Text), textBox2.Text,Convert.ToInt32(textBox8.Text)).ToString();

                        // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
                        this.goodseditTableAdapter.Fill(this.kioskDataSet.goodsedit);

                        clear_goods();
                    }
                    else
                    {
                        MessageBox.Show("Товар с таким штрихкодом уже есть в базе!");
                    }
                }
                else
                {
                    MessageBox.Show("Товар не выбран!");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.goodsTableAdapter1.GetDataBy(Convert.ToInt32(textBox8.Text))[0][8].ToString());
            if (textBox8.Text != "")
            {
                if (this.goodsTableAdapter1.GetDataBy1(Convert.ToInt32(textBox8.Text))[0][8].ToString() == "1")
                {
                    this.goodsTableAdapter1.UpdateQuery(0, Convert.ToInt32(textBox8.Text)).ToString();
                    MessageBox.Show("Товар удален!");
                    
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
                    this.goodseditTableAdapter.Fill(this.kioskDataSet.goodsedit);

                    clear_goods();

                }
                else
                {
                    this.goodsTableAdapter1.UpdateQuery(1, Convert.ToInt32(textBox8.Text)).ToString();
                    MessageBox.Show("Товар восстановлен!");

                    // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
                    this.goodseditTableAdapter.Fill(this.kioskDataSet.goodsedit);

                    clear_goods();
                }
            }
            else
            {
                MessageBox.Show("Товар не выбран!");
            }
        }

        private void clear_goods()
        {
            // передаем id В текстовое поле
            textBox8.Clear();
            // штрихкод
            textBox2.Clear();
            // название
            textBox3.Clear();
            // цена покупки
            textBox4.Clear();
            // цена продажи
            textBox5.Clear();
            // название типа товара
            //textBox7.Clear();
            // id типа товара
            //textBox6.Clear();

            checkBox1.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_goods_type goods_type = new Form_goods_type();
            goods_type.Owner = this;
            goods_type.ShowDialog(this);

            if (goods_type.DialogResult == DialogResult.OK)
            { 
                string[] arr = new string[2];
                arr = goods_type.ReturnData();
                textBox6.Text = arr[0];
                textBox7.Text = arr[1];
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != ',' )
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear_goods();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                    this.goodsTableAdapter1.DeleteQuery(Convert.ToInt32(textBox8.Text));
                    MessageBox.Show("Товар удален!");
                
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
                    this.goodseditTableAdapter.Fill(this.kioskDataSet.goodsedit);
                
                    clear_goods();
            }
            else
            {
                MessageBox.Show("Товар не выбран!");
            }
        }

        private void findGoods()
        {
            // процедура поиска по выбраному полю dataGridVeiw
            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (dataGridView1[dataGridView1.CurrentCell.ColumnIndex, i].FormattedValue.ToString().Contains(textBox1.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, i];
                    return;
                } 
        }
    }
}
