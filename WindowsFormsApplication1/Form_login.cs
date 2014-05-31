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
    public partial class Form_login : Form
    {
        string pass;
        
        public Form_login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.kioskDataSet.users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedValue.ToString());
            passCheck();
        }

        private void passCheck()
        {
            pass = this.usersTableAdapter.ScalarQuery(Convert.ToInt32(comboBox1.SelectedValue.ToString())).ToString();

            if (textBox1.Text == pass)
            {
                // MessageBox.Show("Пароль прошел");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Пароль введен неправильно.");
            }
        }

        public string[] ReturnData()
        {
            string[] stringArray = new string[2];
            stringArray[0] = comboBox1.SelectedValue.ToString();
            stringArray[1] = this.usersTableAdapter.ScalarQuery1(Convert.ToInt32(comboBox1.SelectedValue.ToString())).ToString(); 
            return stringArray;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passCheck();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text != pass)
            {
                Application.Exit();
            }
        }
    }
}
