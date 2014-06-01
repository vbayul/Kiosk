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
    public partial class Form_rep_rest : Form
    {
        public Form_rep_rest()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox1.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = new string[3];

            if (radioButton1.Checked == true)
            {
                data[0] = "0";
            }
            else
            {
                data[0] = "1";
                data[1] = textBox1.Text;
            }
            if (textBox3.Text == "")
            {
                data[2] = "0";
            }
            else
            {
                data[2] = textBox3.Text;
            }



            Form_rep_rest_rep rep_rest_rep = new Form_rep_rest_rep(data);
            rep_rest_rep.Owner = this;
            rep_rest_rep.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_goods_type goods_type = new Form_goods_type();
            goods_type.Owner = this;
            goods_type.ShowDialog(this);

            if (goods_type.DialogResult == DialogResult.OK)
            {
                string[] arr = new string[2];
                arr = goods_type.ReturnData();
                textBox3.Text = arr[0];
                textBox2.Text = arr[1];
            }
        }
    }
}
