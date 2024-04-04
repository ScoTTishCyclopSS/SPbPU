using System;
using System.Windows.Forms;

namespace Practice1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "My first C# program";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = 23;
            label2.Text = Convert.ToString(x);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var my_a = 23;
            label5.Text = Convert.ToString(my_a);
            var my_b = 45.8;
            label6.Text = Convert.ToString(my_b);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var num1 = 3.2;
            var num2 = 9.4;
            var result = num1 * num2;
            textBox1.Text = Convert.ToString(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var num1 = 3.2;
            var num2 = 9.4;
            var result = num1 * num2;
            label10.Text = "The area of a rectangle with sides 3.2 and 9.4 cm = " + Convert.ToString(result) + " cm^2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var num1 = 3.2;
            var num2 = 9.4;
            var result = num1 * num2;
            MessageBox.Show(
                "The area of a rectangle with sides 3.2 and 9.4 cm = " + Convert.ToString(result) + " cm^2");
        }
    }
}