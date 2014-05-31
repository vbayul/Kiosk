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
    public partial class Form_goods_type : Form
    {
        public Form_goods_type()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public string[] ReturnData() 
        {
            string[] stringArray = new string[2];
            stringArray[0] = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            stringArray[1] = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString(); 
            return stringArray;
        }

        private void Form_goods_type_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goods_type". При необходимости она может быть перемещена или удалена.
            this.goods_typeTableAdapter.Fill(this.kioskDataSet.goods_type);

        }
    }
}
