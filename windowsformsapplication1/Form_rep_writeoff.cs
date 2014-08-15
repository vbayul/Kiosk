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
    public partial class Form_rep_writeoff : Form
    {
        public Form_rep_writeoff()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
                // название
                textBox1.Text = arr[1];
                // id
                textBox2.Text = arr[4];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
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

            Form_rep_writeoff_rep rep_writeoff_rep = new Form_rep_writeoff_rep(data);
            rep_writeoff_rep.Owner = this;
            rep_writeoff_rep.ShowDialog();
        }

        private void Form_rep_writeoff_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59);
        }
    }
}
