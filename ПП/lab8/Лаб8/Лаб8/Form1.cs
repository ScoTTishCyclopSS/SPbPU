using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
        }
        int n = 0;
        int m = 0;
        public int i = 0;

        private void radioButton2_Click(object sender, EventArgs e) //рандом баттон
        {
            bool ronly = radioButton2.Checked;
            Random rand = new Random();
            dataGridView1.ColumnCount = n;
            dataGridView2.ColumnCount = m;
            dataGridView1.RowCount = dataGridView2.RowCount = 1;
            string[] result = new string[n];
            string[] result2 = new string[m];
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = i.ToString();
                dataGridView1.Rows[0].Cells[i].Value = ronly ? Math.Round((rand.NextDouble() * 40 - 20), 0).ToString() : "";
                result[i] = dataGridView1.Rows[0].Cells[i].Value.ToString();
            }

            for (int i = 0; i < m; i++)
            {
                dataGridView2.Columns[i].Name = i.ToString();
                dataGridView2.Rows[0].Cells[i].Value = ronly ? Math.Round((rand.NextDouble() * 40 - 20), 0).ToString() : "";
                result2[i] = dataGridView2.Rows[0].Cells[i].Value.ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;
            if (numericUpDown1.Value > 0 && numericUpDown2.Value > 0)
            { 
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            m = (int)numericUpDown2.Value;
            if (numericUpDown1.Value > 0 && numericUpDown2.Value > 0)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = n;
            dataGridView2.ColumnCount = m;
            dataGridView1.RowCount = dataGridView2.RowCount = 1;
            string[] result = new string[n];
            string[] result2 = new string[m];
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = i.ToString();
                dataGridView1.Rows[0].Cells[i].Value = 0;
                result[i] = dataGridView1.Rows[0].Cells[i].Value.ToString();
            }

            for (int i = 0; i < m; i++)
            {
                dataGridView2.Columns[i].Name = i.ToString();
                dataGridView2.Rows[0].Cells[i].Value = 0;
                result2[i] = dataGridView2.Rows[0].Cells[i].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] A = new int[n];
            for (int i = 0; i < n; i++)
            {
                A[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);
            }
            int[] B = new int[m];
            for (int i = 0; i < m; i++)
            {
                B[i] = Convert.ToInt32(dataGridView2.Rows[0].Cells[i].Value);
            }
            int[,] Table = new int[n, m];
            int k = 0;
            int l = 0;
            
           for(k = 0; k < n; k++)
                for(l = 0; l < m; l++)
                {
                    if (A[i] != B[i])
                    {
                        Table[k++, l++] = A[i] + B[i];
                    }                   
                }

            for(k = 0; k < n; k++)
                for (l = 0; l < m; l++)
                {
                    if (A[i] == B[i])
                    {
                        Table[k++, l++] = 0;
                    }
                }
            dataGridView3.RowCount = n;
            dataGridView3.ColumnCount = m;
            for (k = 0; k < n; k++)
                for (l = 0; l < m; l++)
                {
                    dataGridView3.Rows[k].Cells[l].Value = Convert.ToInt32(Table[k, l]);
                }
            }
       }
    }


