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
    public partial class Form_goods : Form
    {
        string type;
        public Form_goods(string t)
        {
            InitializeComponent();
            type = t;
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            // кнопка которая подтверждает возврат данных в родительскую форму.
            this.DialogResult = DialogResult.OK;
        }

        // процедура возвращающа в родительскую форму массив с данными.
        public string[] ReturnData()
        {
            string[] stringArray = new string[5];
            // штрихкод 
            stringArray[0] = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // название
            stringArray[1] = dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // цена
            stringArray[2] = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // возможность редактирования цены
            stringArray[3] = dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            // id
            stringArray[4] = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            return stringArray; // Возвращаем массив значений
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //  процедура поиска по выбраному полю dataGridVeiw
            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (dataGridView1[dataGridView1.CurrentCell.ColumnIndex, i].FormattedValue.ToString().Contains(textBox1.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, i];
                    return;
                }  
        }


        private void Form_goods_Load(object sender, EventArgs e)
        {
            if (type == "1")
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
                this.goodseditTableAdapter.FillBy1(this.kioskDataSet.goodsedit, 1);
            }
            else if (type == "0")
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
                this.goodseditTableAdapter.FillBy(this.kioskDataSet.goodsedit);
            }
            else if (type == "2")
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "kioskDataSet.goodsedit". При необходимости она может быть перемещена или удалена.
                this.goodseditTableAdapter.FillBy2(this.kioskDataSet.goodsedit,1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
