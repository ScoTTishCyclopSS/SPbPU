using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_самостоятельная_2
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
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true; //проверка на ввод: только числа и запятая
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            if ((textBox1.Text != String.Empty) && (textBox2.Text != String.Empty)) //проверка на наличие символов в текстбоксах
                button1.Enabled = true;
            else
                button1.Enabled = false;
           
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true; //проверка на ввод: только числа и запятая
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            if ((textBox1.Text != String.Empty) && (textBox2.Text != String.Empty)) //проверка на наличие символов в текстбоксах
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string num1 = Convert.ToString(textBox1.Text); //конвертация вводимых символов в целые чила для 2ух переменных
            string num2 = Convert.ToString(textBox2.Text);
            int prov = 0;
            int prov2 = 0;
            for (int i = 0; i < num1.Length / 2; i++)
            {
                if (num1.Substring(i, 1) != (num1.Substring(num1.Length - 1 - i, 1))) //проверка на отсутсвие полиндрома для первого числа
                {
                    label3.Text = "Число " + num1 + " не явл. палиндромом."; //вывод сообщения об отсутсвии полиндрома
                }
                else
                    prov = 1;
            }
            if (prov == 1) //иначе мы сравниваем данные условии с переменной заданой в else в предудущей функции "иначе - число полиндром"
                label3.Text = "Число " + num1 + " явл. палиндромом.";


            for (int i = 0; i < num2.Length / 2; i++)
            {
                if (num2.Substring(i, 1) != (num2.Substring(num2.Length - 1 - i, 1))) //проверка на отсутсвие полиндрома для второго числа
                {
                    label4.Text = "Число " + num2 + " не явл. палиндромом."; //вывод сообщения об отсутсвии полиндрома
                }
                else
                    prov2 = 1;
            }
            if (prov2 == 1) //иначе мы сравниваем данные условии с переменной заданой в else в предудущей функции "иначе - число полиндром"
                label4.Text = "Число " + num2 + " явл. палиндромом."; 
            
            textBox1.Clear();
            textBox2.Clear();
        }



    }
}

