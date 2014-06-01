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
    public partial class From_main : Form
    {
        // переменные диапазано начала и окончания текущего дня.
        DateTime currdaystart;
        DateTime currdayend;        

        public From_main()
        {
            // string[] arr = new string[2];
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            // открываем форму логина
            Form_login login = new Form_login();
            login.Owner = this;
            login.ShowDialog(this);

            if (login.DialogResult == DialogResult.OK)
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.sale_goods". При необходимости она может быть перемещена или удалена.
                this.sale_goodsTableAdapter.FillBy(this.kioskDataSet.sale_goods, currdaystart, currdayend);

                Data.arr = login.ReturnData();

                currdaystart = DateTime.Now.Date;
                currdayend = currdaystart.AddHours(23).AddMinutes(59);

                //MessageBox.Show(Convert.ToString(currdaystart) + " " + Convert.ToString(currdayend));
                //MessageBox.Show(Data.arr[0]+" "+Data.arr[1]);
                timer1.Enabled = Enabled;

                if (Data.arr[1] == "1")
                {
                    cправочникиToolStripMenuItem.Visible = false;
                    настройкиToolStripMenuItem.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // создаем дочернюю форму с товарами.            
            Form_goods goods_bay = new Form_goods("0");
            goods_bay.Owner = this;
            goods_bay.ShowDialog(this);

            // принимаем результат с 2ой формы при нажатии кнопки "ок" в массив и заполняем поля
            if (goods_bay.DialogResult == DialogResult.OK) 
            {
                // создаем массив который принимает результаты из дочерней формы
                string[] arr = new string[5];
                // присваиваем массив из дочерней формы массиву из родительской формы который был тольк очто создан.
                arr = goods_bay.ReturnData();
                textBox1.Text = arr[0];
                textBox2.Text = arr[1];
                textBox3.Text = arr[2];
                if (arr[3] == "1")
                {
                    textBox3.Enabled = true;
                }
                else
                {
                    textBox3.Enabled = false;
                }
                textBox5.Text = arr[4];
                // передаем фоку полю с количеством товара
                textBox4.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // идет поверка на числовую запись в колях, в противнмо случае удаляем значения.
            try
            {
                double s1 = Convert.ToDouble(textBox3.Text);
                double s2 = Convert.ToDouble(textBox4.Text);
            }
            catch (System.FormatException)
            {
                textBox4.Clear();
                label7.Text = "0";
            }
            // проверка на заполененность поля
            if (textBox4.Text != "")
            {
                label7.Text = Convert.ToString(Convert.ToDouble(textBox3.Text)*Convert.ToDouble(textBox4.Text));
            }
            else
            {
                label7.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // очищаем поля, когда штрих код начинают редактировать.
            //if (textBox1.Text.Length < 13 && textBox2.Text != "")
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                label7.ResetText();
                textBox3.Enabled = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && textBox1.Text.Length == 13) 
            if (e.KeyCode == Keys.Enter && textBox1.Text.Length > 0)
            {
                // дописать запрос который выбирает нужный товар по штрихкоду и заполняет поля
                // в противном случае выдает что товар не найден.
                // переделать под массив
                if (this.goodsTableAdapter1.ScalarQuery(textBox1.Text).ToString() == "1")
                {
                    this.textBox2.Text = this.goodsTableAdapter1.GetDataBy3(textBox1.Text)[0][1].ToString();
                    this.textBox3.Text = this.goodsTableAdapter1.GetDataBy3(textBox1.Text)[0][4].ToString();
                    this.textBox5.Text = this.goodsTableAdapter1.GetDataBy3(textBox1.Text)[0][0].ToString();
                    textBox3.Enabled = Convert.ToBoolean(Convert.ToInt32(this.goodsTableAdapter1.GetDataBy3(textBox1.Text)[0][5].ToString()));
                    textBox4.Focus();
                }
                else
                {
                    MessageBox.Show("Товар не найден!");
                }
                //this.textBox1.Text = this.goodsTableAdapter1.GetDataBy(textBox2.Text)[0][1].ToString();
            }
        }

        private void товарToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_goods_journal goods_edit = new Form_goods_journal();
            goods_edit.Owner = this;
            goods_edit.ShowDialog(this);
        }

        private void приходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_rep_income rep_income = new Form_rep_income();
            rep_income.Owner = this;
            rep_income.ShowDialog(this);
        }

        private void приходыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_goods_income income = new Form_goods_income();
            income.Owner = this;
            income.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goodsSale();
        }

        private void goodsSale()
        {
            // проверку на заполненность
            if (textBox3.Text != "" && textBox5.Text != "" && textBox4.Text != "" && label7.Text != "0")
            {
                // добавиьт хук с проверкой на тип товара
                // и записывать продажу безснятия товара с остатков
                // запись продажи товара 
                saleTableAdapter.Insert(textBox5.Text, DateTime.Now, textBox4.Text, textBox3.Text);

                // снятие товара с остатков

                goodsTableAdapter1.UpdateQuery3(textBox4.Text, textBox5.Text);

                // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.sale_goods". При необходимости она может быть перемещена или удалена.
                this.sale_goodsTableAdapter.FillBy(this.kioskDataSet.sale_goods, currdaystart, currdayend);

                debit();

                clearText();
            }
            else
            {
                MessageBox.Show("Не все поля заполенны!");
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void clearText()
        {
            // функция очистки заполненых текстбоксов
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label7.ResetText();
            textBox3.Enabled = false;
            textBox1.Focus();
        }

        private void расходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_outcome outcome = new Form_outcome();
            outcome.Owner = this;
            outcome.ShowDialog(this);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // разрешение ввода лишь цифр
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void ценникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_price pricelist = new Form_price();
            pricelist.Owner = this;
            pricelist.ShowDialog(this);
        }

        private void расходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_rep_outcome rep_outcome = new Form_rep_outcome();
            rep_outcome.Owner = this;
            rep_outcome.ShowDialog(this);
        }

        private void остаткиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_rep_rest rep_rest = new Form_rep_rest();
            rep_rest.Owner = this;
            rep_rest.ShowDialog(this);
        }

        public void debit()
        {
            // перещест текущей прибыли, расходов и остатка денег в кассе на текущий день
            if (saleTableAdapter.ScalarQuery(currdaystart, currdayend).ToString() == "0")
            {
                label2.Text = "0";
            }
            else
            {
                label2.Text = saleTableAdapter.ScalarQuery1(currdaystart, currdayend).ToString(); 
            }
            if (outcomeTableAdapter1.ScalarQuery(currdaystart, currdayend).ToString() == "0")
            {
                label4.Text = "0";
            }
            else
            {
                label4.Text = outcomeTableAdapter1.ScalarQuery1(currdaystart, currdayend).ToString();
            }
            label6.Text = Convert.ToString(Convert.ToDouble(label2.Text) - Convert.ToDouble(label4.Text));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            debit();
        }

        private void продажиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_rep_sale rep_sale = new Form_rep_sale();
            rep_sale.Owner = this;
            rep_sale.ShowDialog();
        }

        private void чекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_check check = new Form_check();
            check.Owner = this;
            check.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_settings settings = new Form_settings();
            settings.Owner = this;
            settings.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                goodsSale();
            }
        }
    }
}
