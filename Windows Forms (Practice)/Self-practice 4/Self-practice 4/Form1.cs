using System;
using System.Windows.Forms;

namespace Self
{
    public partial class Form1 : Form
    {
        private int[] massiv;
        private int n;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var massiv = new int[n];

            for (var i = 0; i < n; i++)
                massiv[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);

            var imin = -1;
            for (var i = 0; i < n; i++)
                if (massiv[i] < 0)
                {
                    imin = i;
                    break;
                }

            var imax = -1;
            for (var i = 0; i < n; i++)
                if (massiv[i] < 0)
                    imax = i;

            label3.Text = "Number of the first negative value: " + imin + "\nThe number of the last negative value: " +
                          imax;

            if (imax - imin > 1)
            {
                var proz = 1;
                for (var i = imin + 1; i < imax; i++) proz *= massiv[i];
                label3.Text += "\nProduct between them: " + proz;
            }
            else
            {
                MessageBox.Show(
                    "ERROR:\nPossible causes:\n1.There is only one negative element;\n2.There are no negative elements;\n3.There are no other values between the 1st negative number and the 2nd negative number;");
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;
            var ronly = radioButton1.Checked;
            var rand2 = new Random();
            dataGridView1.ReadOnly = ronly;
            dataGridView1.ColumnCount = n;

            for (var i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = i.ToString();
                if (ronly)
                    dataGridView1.Rows[0].Cells[i].Value = rand2.Next(-100, 100).ToString();
                else
                    dataGridView1.Rows[0].Cells[i].Value = 0;
            }
        }
    }
}