using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб3
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
            int k, a = 0, s = 0, b = 0; //длина строки - к, a - буквы, s - цифры, остальные символы - b
            k = str.Length;
            for (int i = 0; i < k; i++)
            {
                if (char.IsLetter(str[i]))
                    a++;
                if (char.IsDigit(str[i]))
                    s++;
                k = str.Length;
                b = k - (a + s);

                if (radioButton1.Checked == true)
                    label2.Text = "Количество букв латинского алфавита: ?" + "\nцифр: " + s + "\nдругих знаков в строке пароля: ?";
                if (radioButton2.Checked == true)
                    label2.Text = "Количество букв латинского алфавита: " + a + "\nцифр: ?" + "\nдругих знаков в строке пароля: ?";
                if (radioButton3.Checked == true)
                    label2.Text = "Количество букв латинского алфавита: ?" + "\nцифр: ?" + "\nдругих знаков в строке пароля: " + b;
                if (radioButton4.Checked == true)
                    label2.Text = "Количество букв латинского алфавита: " + a + "\nцифр: " + s + "\nдругих знаков в строке пароля: " + b;
            }
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
