using System;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("firm", "Vendor");
            dataGridView1.Columns.Add("tact", "Freq");
            dataGridView1.Columns.Add("op", "RAM");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(Convert.ToString(comboBox1.SelectedItem), Convert.ToDouble(textBox1.Text),
                Convert.ToDouble(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                    return;
            }

            e.KeyChar = '\0';
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = (comboBox1.SelectedItem != null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = textBox1.TextLength > 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox2.TextLength > 0;
        }
    }
}