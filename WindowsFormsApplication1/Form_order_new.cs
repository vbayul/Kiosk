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
    public partial class Form_order_new : Form
    {
        public Form_order_new(int order,int new_doc)
        {
            InitializeComponent();
            this.order = order;
            this.new_doc = new_doc;
        }

        int order, new_doc;

        private void button3_Click(object sender, EventArgs e)
        {
            if (new_doc == 1)
            {
                if (Save_chenges() == 1)
                {
                    Form_orders_print_orders order_print_order = new Form_orders_print_orders(Convert.ToInt32(textBox2.Text),0);
                    order_print_order.Owner = this;
                    order_print_order.ShowDialog();
                }
            }
            else
            {
                Form_orders_print_orders order_print_order = new Form_orders_print_orders(Convert.ToInt32(textBox2.Text),0);
                order_print_order.Owner = this;
                order_print_order.ShowDialog(); 
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Form_order_new_Load(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(order);
            if (new_doc == 0)
            {
                textBox1.Text = this.orderTableAdapter.GetDataBy1(order)[0][7].ToString();
                textBox5.Text = this.orderTableAdapter.GetDataBy1(order)[0][5].ToString();
                textBox3.Text = this.orderTableAdapter.GetDataBy1(order)[0][3].ToString();
                textBox4.Text = this.orderTableAdapter.GetDataBy1(order)[0][4].ToString();
                textBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                checkBox1.Checked = Convert.ToBoolean(Convert.ToInt32(this.orderTableAdapter.GetDataBy1(order)[0][6].ToString()));
            }
            else

            if (checkBox1.Checked == true)
            {
                checkBox1.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }

            if (new_doc == 0)
            {
                button4.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save_chenges();
        }

        public int Save_chenges()
        {
            if (checkBox1.Enabled == true)
            {
                if (new_doc == 1)
                {
                    if (textBox1.Text != "" && textBox4.Text != "" && textBox3.Text != "" && textBox5.Text != "")
                    {
                        this.orderTableAdapter.Insert(order, DateTime.Now, null, textBox3.Text, textBox4.Text, textBox5.Text, 0, textBox1.Text);
                        this.DialogResult = DialogResult.OK;
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("Не все поля заполненны.");
                        return 0;
                    }
                }
                else
                {
                    this.orderTableAdapter.UpdateQuery(Convert.ToInt32(checkBox1.Checked), DateTime.Now, order);
                    this.DialogResult = DialogResult.OK;
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.orderTableAdapter.GetDataBy1(Convert.ToInt32(textBox2.Text))[0][6].ToString() == "0")
            {
                this.orderTableAdapter.UpdateQuery(1, DateTime.Now, order);
            }

            Form_orders_print_orders order_print_order = new Form_orders_print_orders(Convert.ToInt32(textBox2.Text), 1);
            order_print_order.Owner = this;
            order_print_order.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }
    }
}
