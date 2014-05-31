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
    public partial class Form_check_sale : Form
    {
        string dateTime;

        public Form_check_sale(string date)
        {
            InitializeComponent();
            dateTime = date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.Close();
            }
        }

        private void Form_check_sale_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.sale_goods". При необходимости она может быть перемещена или удалена.
            this.sale_goodsTableAdapter1.FillBy2(this.kioskDataSet1.sale_goods, Convert.ToDateTime(dateTime), (Convert.ToDateTime(dateTime).AddHours(23).AddMinutes(59)));
            dataGridView1.DataSource = kioskDataSet1.sale_goods;
        }

        public string[] RetunData()
        {
            string[] stringArray = new string[7];
            stringArray[0] = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString(); 
            stringArray[1] = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            stringArray[2] = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            stringArray[3] = dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            stringArray[4] = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            stringArray[5] = dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            stringArray[6] = dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            return stringArray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
