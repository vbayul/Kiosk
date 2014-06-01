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
    public partial class Form_rep_sale : Form
    {
        public Form_rep_sale()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = new string[5];

            data[0] = dateTimePicker1.Value.ToString();
            data[1] = dateTimePicker2.Value.ToString();
            data[2] = Convert.ToString(Convert.ToInt32(checkBox1.Checked));
            if (textBox2.Text == "")
            {
                data[3] = "0";
            }
            else
            {
                data[3] = textBox2.Text;
            }

            if (textBox4.Text == "")
            {
                data[4] = "0";
            }
            else
            {
                data[4] = textBox4.Text;
            }
            Form_rep_sale_rep rep_sale_rep = new Form_rep_sale_rep(data);
            rep_sale_rep.Owner = this;
            rep_sale_rep.ShowDialog(this);
        }

        private void Form_rep_sale_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_goods goods_rep_income = new Form_goods("0");
            goods_rep_income.Owner = this;
            goods_rep_income.ShowDialog(this);

            if (goods_rep_income.DialogResult == DialogResult.OK)
            {
                string[] arr = new string[5];
                arr = goods_rep_income.ReturnData();
                textBox1.Text = arr[1];
                textBox2.Text = arr[4];
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
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
                textBox4.Text = arr[0];
                textBox3.Text = arr[1];
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
