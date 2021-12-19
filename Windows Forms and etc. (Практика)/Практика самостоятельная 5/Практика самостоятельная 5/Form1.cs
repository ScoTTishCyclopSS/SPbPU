using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_самостоятельная_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton2.Checked = true;
            numericUpDown1.Value = numericUpDown2.Value = 5;
        }

        //методы, предоставляющие интерфейс к параметрам datagrifview 
        int Rows
        {
            get
            {
                return (int)numericUpDown1.Value;
            }
        }
        int Cols
        {
            get
            {
                return (int)numericUpDown2.Value;
            }

        }

        int Table(int i, int j)
        {
            return Convert.ToInt32(dataGridView1[i, j].Value);
        }
        private void Control_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            dataGridView1.ReadOnly = radioButton2.Checked;
            dataGridView1.ColumnCount = Cols;
            dataGridView1.RowCount = Rows;
            for (int i = 0; i < Cols; i++)
            {
                dataGridView1.Columns[i].Name = "";
                for (int j = 0; j < Rows; j++) //инициализация таблицы 
                    dataGridView1[i, j].Value = dataGridView1.ReadOnly ? (r.Next(-50, 50).ToString()) : ""; // условное выражение 
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i, j;

            double sumEven,
            ssumEven = 0;
            for (i = 0; i < Cols; i++)
            {
                sumEven = 0;
                for (j = 0; j < Rows; j++)
                    if (Table(i, j) % 2 == 0)
                    {
                        sumEven += Table(i, j);
                    }
                ssumEven += sumEven;

                dataGridView1.Columns[i].Name = "" + sumEven;
                label3.Text = "Сумма четных.эл " + ssumEven;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0, n = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < Cols; i++)
                for (int j = 0; j < Rows; j++)
                    if (Table(i, j) % n == 0)
                        count++;
            MessageBox.Show("В таблице " + count + "эл. кратный " + n);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < Cols; i++)
                for (int j = 0; j < Rows; j++)
                    if (Math.Abs(Table(i, j)) % 2 == 1)
                        count++;
            MessageBox.Show("В таблице " + count + " нечет.эл");
        }

    }
    }