using System;
using System.Windows.Forms;

namespace Self
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton2.Checked = true;
            numericUpDown1.Value = numericUpDown2.Value = 5;
        }

        private int Rows => (int)numericUpDown1.Value;

        private int Cols => (int)numericUpDown2.Value;

        private int Table(int i, int j)
        {
            return Convert.ToInt32(dataGridView1[i, j].Value);
        }

        private void Control_Click(object sender, EventArgs e)
        {
            var r = new Random();

            dataGridView1.ReadOnly = radioButton2.Checked;
            dataGridView1.ColumnCount = Cols;
            dataGridView1.RowCount = Rows;

            for (var i = 0; i < Cols; i++)
            {
                dataGridView1.Columns[i].Name = "";
                for (var j = 0; j < Rows; j++)
                {
                    dataGridView1[i, j].Value = dataGridView1.ReadOnly ? r.Next(-50, 50).ToString() : "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j;
            double sumEven, ssumEven = 0;

            for (i = 0; i < Cols; i++)
            {
                sumEven = 0;
                for (j = 0; j < Rows; j++)
                {
                    if (Table(i, j) % 2 == 0)
                    {
                        sumEven += Table(i, j);
                    }
                }

                ssumEven += sumEven;

                dataGridView1.Columns[i].Name = "" + sumEven;
                label3.Text = "Sum of even:" + ssumEven;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0, n = Convert.ToInt32(textBox1.Text);
            for (var i = 0; i < Cols; i++)
            {
                for (var j = 0; j < Rows; j++)
                {
                    if (Table(i, j) % n == 0)
                        count++;
                }
            }

            MessageBox.Show("In the table " + count + "el. multiple " + n);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var count = 0;
            for (var i = 0; i < Cols; i++)
            for (var j = 0; j < Rows; j++)
                if (Math.Abs(Table(i, j)) % 2 == 1)
                    count++;
            MessageBox.Show("In the table " + count + " odd elements.");
        }
    }
}