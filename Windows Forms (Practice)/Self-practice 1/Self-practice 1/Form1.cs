using System;
using System.Windows.Forms;

namespace Практика_самостоятельная_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }


        private void
            textBox1_KeyPress(object sender,
                KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',') e.Handled = false;

            if (textBox1.Text.Length >= 1 && textBox2.Text.Length >= 1)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void
            textBox2_KeyPress(object sender,
                KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',') e.Handled = false;

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var k = 0;
            var num1 = Convert.ToDouble(textBox1.Text);
            var x = Convert.ToDouble(textBox2.Text);

            if (num1 <= 0 || num1 >= 1)
            {
                MessageBox.Show("Enter the correct range!");
            }
            else
            {
                double current = 1;
                var sum = current;
                
                for (var n = 1;; n++)
                {
                    k++;
                    current *= -x / n;
                    sum += current;
                    if (Math.Abs(current) < num1)
                        break;
                }

                label3.Text = "Result = " + Math.Round(sum, 3) + "\nNumber of members of the sum: " + k;
            }
        }
    }
}