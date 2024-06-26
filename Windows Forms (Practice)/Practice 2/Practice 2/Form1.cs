﻿using System;
using System.Windows.Forms;

namespace Practice_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "a=" + Convert.ToInt32(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "a=" + Convert.ToInt32(textBox2.Text) + "  b=" + Convert.ToDouble(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a=" + Convert.ToInt32(textBox4.Text) + "  b=" + Convert.ToDouble(textBox5.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToInt32(textBox6.Text);
            double result = num1 * 2 * Math.PI;
            label9.Text = "The length of the circle is: " + Math.Round(result, 3) + " cm";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(textBox7.Text);
            int num2 = Convert.ToInt32(textBox8.Text);
            double result = num1 * num2;
            label14.Text = "Cost of purchase: " + Math.Round(result, 3) + "rub";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(textBox9.Text);
            int num2 = Convert.ToInt32(textBox10.Text);
            double num3 = Convert.ToDouble(textBox11.Text);
            double result = num2 * num3 + num1;
            label19.Text = "The height of a " + num2 + "floors house is " + Math.Round(result, 2) + "m";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double n1, n2;
            String num1 = textBox12.Text;
            String num2 = textBox13.Text;
            bool isStrnum1 = Double.TryParse(num1, out n1);
            bool isStrnum2 = Double.TryParse(num2, out n2);
            if (check(isStrnum1, isStrnum2) == false)
                MessageBox.Show("Incorrect data format!");
            else
            {
                double result = n1 * n2;
                double result2 = Math.Sqrt(Math.Pow(n1, 2) + Math.Pow(n2, 2));
                label24.Text = "The area of a rectangle: " + Math.Round(result, 2) + "sq.cm./n Diagonal length: " +
                               Math.Round(result2, 2) + "cm";
            }
        }

        private bool check(bool isStrnum1, bool isStrnum2)
        {
            if (isStrnum1 == false)
                return false;
            else if (isStrnum2 == false)
                return false;
            else
                return true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(textBox14.Text);
            double num2 = Convert.ToDouble(textBox15.Text);

            if (num2 == 0)
                linkLabel1.Text = "You can't divide by 0!";
            else
            {
                double result = num1 / num2;
                double result2 = result - Math.Truncate(result);
                linkLabel1.Text = "Partial: " + Math.Round(result, 3) + "\nA whole lot of particial: " +
                                  Math.Truncate(result) + "\nThe remainder of the division: " + Math.Round(result2, 3);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double num1, num2, num3, num4, num5;
            if (textBox16.Text.Length == 2)
            {
                num1 = Convert.ToDouble(textBox16.Text);
                num2 = num1 % 10;
                num3 = Math.Floor(num1 / 10);
                num4 = num3 + num2;
                num5 = num3 * num2;

                textBox17.Text = Convert.ToString(num3);
                textBox18.Text = Convert.ToString(num2);
                textBox19.Text = Convert.ToString(num4);
                textBox20.Text = Convert.ToString(num5);
            }
            else
            {
                MessageBox.Show("The number must be two digits!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(textBox21.Text);
            double num2 = Convert.ToDouble(textBox22.Text);
            double result = num1 + num2;
            double result2 = num1 - num2;
            double result3 = num1 * num2;
            double result4 = num1 / num2;
            if (num2 == 0)
                label33.Text = num1 + " + " + num2 + " = " + result + "\n" + num1 + " - " + num2 + " = " + result2 +
                               "\n" + num1 + " * " + num2 + " = " + result3 + "\nYou can't divide by 0!";
            else
                label33.Text = num1 + " + " + num2 + " = " + result + "\n" + num1 + " - " + num2 + " = " + result2 +
                               "\n" + num1 + " * " + num2 + " = " + result3 + "\n" + num1 + " / " + num2 + " = " +
                               result4;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox23.Text);
            double x2 = Convert.ToDouble(textBox24.Text);
            double y1 = Convert.ToDouble(textBox25.Text);
            double y2 = Convert.ToDouble(textBox26.Text);

            double result = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            label36.Text = "| A(" + x1 + " ; " + y1 + ") : B(" + x2 + " ; " + y2 + ") | = " + Math.Round(result, 2);
        }
    }
}
