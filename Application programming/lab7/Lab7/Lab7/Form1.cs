using System;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public int i;
        private int n;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var A = new int[n];
            for (i = 0; i < n; i++) A[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);

            var B = new int[n];
            var j = 0;

            for (i = 0; i < n; i++)
                if (A[i] > 0)
                    B[j++] = A[i];
            for (i = 0; i < n; i++)
                if (A[i] < 0)
                    B[j++] = A[i];
            for (i = 0; i < n; i++)
                if (A[i] == 0)
                    B[j++] = A[i];
            for (j = 0; j < n; j++) dataGridView1.Rows[0].Cells[j].Value = Convert.ToInt32(B[j]);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            var ronly = radioButton2.Checked;
            var rand = new Random();
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = 1;
            var result = new string[n];
            for (var i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = i.ToString();
                dataGridView1.Rows[0].Cells[i].Value =
                    ronly ? Math.Round(rand.NextDouble() * 40 - 20, 0).ToString() : "";
                result[i] = dataGridView1.Rows[0].Cells[i].Value.ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;
        }
    }
}