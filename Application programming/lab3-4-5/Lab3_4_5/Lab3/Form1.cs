using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            int str_l = str.Length;
            
            int letters = 0, digits = 0;
            
            for (int i = 0; i < str_l; i++)
            {
                if (char.IsLetter(str[i]))
                    letters++;
                
                if (char.IsDigit(str[i]))
                    digits++;
            }
            
            int other = str_l - (letters + digits);

            if (radioButton1.Checked)
                label2.Text = "Latin letters: x" + "\nDigits: " + digits + "\nOther symbols: x";
            if (radioButton2.Checked)
                label2.Text = "Latin letters: " + letters + "\nDigits: x" + "\nOther symbols: x";
            if (radioButton3.Checked)
                label2.Text = "Latin letters: x" + "\nDigits: x" + "\nOther symbols: " + other;
            if (radioButton4.Checked)
                label2.Text = "Latin letters: " + letters + "\nDigits: " + digits + "\nOther symbols: " + other;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar <= 'z' && e.KeyChar >= 'a' || e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                return;
            if (e.KeyChar <= 'я' && e.KeyChar >= 'а' || e.KeyChar >= 'A' && e.KeyChar <= 'Я')
                e.Handled = true;
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 3)
                button1.Enabled = true;
            if (textBox1.Text.Length < 3)
                button1.Enabled = false;
        }
    }
}
