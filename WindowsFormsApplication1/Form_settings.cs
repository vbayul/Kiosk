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
    public partial class Form_settings : Form
    {
        public Form_settings()
        {
            InitializeComponent();
        }

        private void Form_settings_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.kioskDataSet.users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                this.usersTableAdapter.UpdateQuery(textBox1.Text, textBox2.Text, Convert.ToInt16(Convert.ToBoolean(checkBox1.Checked.ToString())), Convert.ToInt32(textBox3.Text));

                // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.users". При необходимости она может быть перемещена или удалена.
                this.usersTableAdapter.Fill(this.kioskDataSet.users);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            textBox3.Text = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(Convert.ToInt32(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString()));
        }
    }
}
