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
    public partial class Form_rep_income : Form
    {
        public Form_rep_income()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] data = new string[3];
            if (textBox2.Text == "")
            {
                data[0]="0";
            }
            else
            {
                data[0] = textBox2.Text;
            }
            data[1] = dateTimePicker1.Value.ToString();
            data[2] = dateTimePicker2.Value.ToString();

            Form_rep_income_rep rep_income_rep = new Form_rep_income_rep(data);
            rep_income_rep.Owner = this;
            rep_income_rep.ShowDialog(this);
        }

        private void Form_rep_income_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59);
        }
    }
}
