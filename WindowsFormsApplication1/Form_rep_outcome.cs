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
    public partial class Form_rep_outcome : Form
    {
        public Form_rep_outcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = new string[2];
            data[0] = dateTimePicker1.Value.ToString();
            data[1] = dateTimePicker2.Value.ToString();

            Form_rep_outcome_rep rep_outcome_rep = new Form_rep_outcome_rep(data);
            rep_outcome_rep.Owner = this;
            rep_outcome_rep.ShowDialog(this);
        }

        private void Form_rep_outcome_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59);
        }
    }
}
