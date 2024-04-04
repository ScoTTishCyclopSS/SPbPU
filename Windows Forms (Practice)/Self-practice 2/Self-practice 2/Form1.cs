using System;
using System.Windows.Forms;

namespace Self
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b')
                e.Handled = true;
            if (e.KeyChar == ',')
                e.Handled = false;

            if (textBox1.Text != string.Empty &&
                textBox2.Text != string.Empty)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b')
                e.Handled = true;
            if (e.KeyChar == ',')
                e.Handled = false;

            if (textBox1.Text != string.Empty &&
                textBox2.Text != string.Empty)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var num1 = Convert.ToString(textBox1.Text);
            var num2 = Convert.ToString(textBox2.Text);
            var prov = 0;
            var prov2 = 0;

            for (var i = 0; i < num1.Length / 2; i++)
            {
                if (num1.Substring(i, 1) != num1.Substring(num1.Length - 1 - i, 1))
                    label3.Text = "The number " + num1 + " is not a palindrome.";
                else
                    prov = 1;
            }

            if (prov == 1)
                label3.Text = "The number " + num1 + " is a palindrome.";
            
            for (var i = 0; i < num2.Length / 2; i++)
                if (num2.Substring(i, 1) != num2.Substring(num2.Length - 1 - i, 1))
                    label4.Text = "The number " + num2 + " is not a palindrome.";
                else
                    prov2 = 1;

            if (prov2 == 1)
                label4.Text = "The number " + num2 + " is a palindrome.";

            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
