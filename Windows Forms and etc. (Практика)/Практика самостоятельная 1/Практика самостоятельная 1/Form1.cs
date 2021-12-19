using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)  //проверка на ввод - только числа и запятой для 1ого текстбокса
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }

            if (textBox1.Text.Length >= 1 && textBox2.Text.Length >= 1)  //проверка на наличие символов в текстбоксах
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) //проверка на ввод - только числа и запятой для 2ого текстбокса
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0) 
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {


            int k = 0;
            double num1 = Convert.ToDouble(textBox1.Text);
            double x = Convert.ToDouble(textBox2.Text); // конвертация в дабл введенных переменных

            if (num1 <= 0 || num1 >= 1) //проверка на ввод диапазона
                MessageBox.Show("Введите правильный диапазон!");
            else
            { 
            // num1 = 0
                double current = 1;  // назначение первого элемента
            // частичная сумма
                double sum = current;
            for (int n = 1; ; n++)
            {
                k++;
                current *= -x / n;
                sum += current;
                if (Math.Abs(current) < num1) // возвращаем значение числа при уcловии, что оно < первой переменной
                    break;
            }
            label3.Text = "Вывод = " + Math.Round(sum, 3) + "\nКол-во членов суммы: " + k;
            /*label4.Text = "Встроенная = " + Math.Round((Math.Exp(-x)), 3);*/
            }

        }   
    }
}
