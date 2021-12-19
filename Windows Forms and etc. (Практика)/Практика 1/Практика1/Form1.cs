using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Моя первая программа на С#";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 23;
            label2.Text = System.Convert.ToString(x);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int my_a = 23;
            label5.Text = System.Convert.ToString(my_a);
            double my_b = 45.8;
            label6.Text = System.Convert.ToString(my_b);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double num1 = 3.2;
            double num2 = 9.4;
            double result = num1 * num2;
            textBox1.Text = System.Convert.ToString(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double num1 = 3.2;
            double num2 = 9.4;
            double result = num1 * num2;
            label10.Text = "Площадь прямоугольника со сторонами 3,2 и 9,4 см = " + Convert.ToString(result) + " кв.см.";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double num1 = 3.2;
            double num2 = 9.4;
            double result = num1 * num2;
            MessageBox.Show("Площадь прямоугольника со сторонами 3,2 и 9,4 см = " + Convert.ToString(result) + " кв.см.");
        }
    }
}
