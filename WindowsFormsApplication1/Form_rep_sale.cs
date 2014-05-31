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
            string[] data = new string[4];

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
            Form_goods goods_rep_income = new Form_goods();
            goods_rep_income.Owner = this;
            goods_rep_income.ShowDialog(this);

            if (goods_rep_income.DialogResult == DialogResult.OK)
            {
                string[] arr = new string[5];
                arr = goods_rep_income.ReturnData();
                textBox1.Text = arr[1];
                textBox2.Text = arr[4];
            }
        }
    }
}
