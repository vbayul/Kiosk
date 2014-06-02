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
    public partial class Form_rep_by_day : Form
    {
        public Form_rep_by_day()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] date_time = new string[2];
            date_time[0] = dateTimePicker1.Value.ToString();
            date_time[1] = dateTimePicker2.Value.ToString();
            Form_rep_by_day_rep rep_by_day_rep = new Form_rep_by_day_rep(date_time);
            rep_by_day_rep.Owner = this;
            rep_by_day_rep.Show();
            //MessageBox.Show(date_time[0]+ "  "+ date_time[1]);
        }

        private void Form_rep_by_day_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddHours(23).AddMinutes(59);
        }
    }
}
