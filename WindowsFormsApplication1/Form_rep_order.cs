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
    public partial class Form_rep_order : Form
    {
        public Form_rep_order()
        {
            InitializeComponent();
        }

        private void Form_rep_order_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddHours(23).AddMinutes(59);
        }

        string type;

        private void button1_Click(object sender, EventArgs e)
        {
            type_str();
            string[] date_time = new string[3];
            date_time[0] = dateTimePicker1.Value.ToString();
            date_time[1] = dateTimePicker2.Value.ToString();
            date_time[2] = type;
            Form_rep_order_rep rep_by_day_rep = new Form_rep_order_rep(date_time);
            rep_by_day_rep.Owner = this;
            rep_by_day_rep.Show();
        }

        private void type_str()
        {
            if (radioButton1.Checked == true) type = "2";
            if (radioButton2.Checked == true) type = "0";
            if (radioButton3.Checked == true) type = "1";
        }
    }
}
