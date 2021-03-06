﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form_outcome : Form
    {
        public Form_outcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                this.outcomeTableAdapter.Insert(textBox1.Text, textBox2.Text, DateTime.Now);
                ClearText();
                MessageBox.Show("Расход добавлен!");
                this.Close();
             }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearText()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
