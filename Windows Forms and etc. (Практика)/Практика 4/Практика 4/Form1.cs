using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_4
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }
            double result2 = 0;
            bool end = false;
            double sec;
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        { }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        { }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                int num1 = 10;
                double num2 = Convert.ToDouble(textBox2.Text);
                double result = num1 * num2;
                label4.Text = "Цена:" + num1 + "р." + "\nКол-во: " + num2 + "р." + "\nСумма заказа: " + result + "р.";
            }
            if (radioButton2.Checked == true)
            {
                int num1 = 15;
                double num2 = Convert.ToDouble(textBox2.Text);
                double result = num1 * num2;
                label4.Text = "Цена:" + num1 + "р." + "\nКол-во: " + num2 + "р." + "\nСумма заказа: " + result + "р.";
            }
            if (radioButton3.Checked == true)
            {
                int num1 = 20;
                double num2 = Convert.ToDouble(textBox2.Text);
                double result = num1 * num2;
                label4.Text = "Цена:" + num1 + "р." + "\nКол-во: " + num2 + "р." + "\nСумма заказа: " + result + "р.";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            textBox1.MaxLength = 6;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            textBox3.MaxLength = 6;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 6 || textBox1.Text == String.Empty)
                MessageBox.Show("В первом поле должно быть 6 цифр!");
            if (textBox3.Text.Length < 6 || textBox3.Text == String.Empty)
                MessageBox.Show("Во втором поле должно быть 6 цифр!");
            if (comboBox1.Text == String.Empty)
                MessageBox.Show("Не выбран регион!");
            else
            {
                int num1 = Convert.ToInt32(textBox1.Text);
                int num2 = Convert.ToInt32(textBox3.Text);
                if (num1 > num2)
                    MessageBox.Show("Предыдущее показание не может быть больше текущего!");
                else
                {
                    double result = (num2 - num1);
                    if (comboBox1.SelectedItem == "Санкт - Петербург")
                        result = result * 4.3;
                    label5.Text = Convert.ToString(result);
                    if (comboBox1.SelectedItem == "Москва")
                        result = result * 5.2;
                    label5.Text = Convert.ToString(result);
                    if (comboBox1.SelectedItem == "Екатеринбург")
                        result = result * 3.4;
                    label5.Text = Convert.ToString(result);
                    if (comboBox1.SelectedItem == "Техас?")
                        result = result * 10.5;
                    label5.Text = Convert.ToString(result) + "р.";
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label12.Text = "R:";
            label14.Text = "I:";
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label12.Text = "U:";
            label14.Text = "I:";
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label12.Text = "U:";
            label14.Text = "R:";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == String.Empty)
                MessageBox.Show("Введите переменную в 1ое поле!");
            if (textBox5.Text == String.Empty)
                MessageBox.Show("Введите переменную в 2ое поле!");
            else
            {
                if (radioButton4.Checked == true)
                {
                    double num1 = Convert.ToDouble(textBox4.Text);
                    double num2 = Convert.ToDouble(textBox5.Text);
                    double result = num1 * num2;
                    label13.Text = "Результат: U = " + Math.Round(result, 3);
                }
                if (radioButton5.Checked == true)
                {
                    double num1 = Convert.ToDouble(textBox4.Text);
                    double num2 = Convert.ToDouble(textBox5.Text);
                    double result = num1 / num2;
                    label13.Text = "Результат: R = " + Math.Round(result, 3);
                }
                if (radioButton6.Checked == true)
                {
                    double num1 = Convert.ToDouble(textBox4.Text);
                    double num2 = Convert.ToDouble(textBox5.Text);
                    double result = num1 / num2;
                    label13.Text = "Результат: I = " + Math.Round(result, 3);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Enabled = true;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        { }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == String.Empty || comboBox2.Text == String.Empty || textBox8.Text == String.Empty)
                MessageBox.Show("Не введены данные!");
            else
            {
                double num1 = Convert.ToDouble(textBox7.Text);
                double num2 = Convert.ToDouble(textBox8.Text);
                double num4;
                if (num1 == 0)
                    MessageBox.Show("Первоначальная сумма не может быть равна 0!");
                if (num2 == 0)
                    MessageBox.Show("Процент годовых не может быть равен 0!");
                else
                {
                    for (int num3 = Convert.ToInt32(comboBox2.SelectedItem); num3 > 0; num3--)
                    {
                        num1 = num1 * (1 + num2 / 100);
                        num4 = num1 - Convert.ToDouble(textBox7.Text);
                        label20.Text = "Доход по вкладу: " + Math.Round(num1, 3) + "р." + "\nУвеличенная сумма: " + Math.Round(num4, 3) + "р.";
                    }

                }
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            panel4.Enabled = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            int days = Convert.ToInt16(maskedTextBox1.Text.Substring(0, 2));
            int months = Convert.ToInt16(maskedTextBox1.Text.Substring(3, 2));
            int age = Convert.ToInt16(maskedTextBox1.Text.Substring(6, 4));
            if (days > 31 || months > 12 || age > 2017 || age == 0 || days == 0 || months == 0 || (months == 2) && (days > 28))
                MessageBox.Show("Дата введена неверно!");
            else
            {
                DateTime bornDate = new DateTime(age, months, days);
                DateTime currentDate = DateTime.Now;
                DateTime span = new DateTime((currentDate - bornDate).Ticks);
                days = span.Day - 1;
                months = span.Month - 1;
                age = span.Year - 1;
                label28.Text = "Ваш возраст:\n-> полных лет: " + Convert.ToString(age) + "\n-> месяцев: " + Convert.ToString(months) + "\n-> дней: " + Convert.ToString(days);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
        }



        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(textBox6.Text);
            int num2 = Convert.ToInt32(numericUpDown1.Text);
            string tovar = Convert.ToString(comboBox3.Text);
            double sale = 0;
            double saleresult = 0;
            double result = num1 * num2;
            richTextBox1.Text = richTextBox1.Text + tovar + ": " + Convert.ToString(numericUpDown1.Text) + "шт. по цене: " + result + "р.\n";
            result2 += num1 * num2;
            if ((result2 > 500) && (result2 <= 1000))
            {
                sale = 3;
            }
            saleresult = result2 * (100 - sale) / 100;
            label33.Text = "Общая сумма\nсо скидкой " + sale.ToString() + "%: " + saleresult + "р.";
            if (result2 > 1000)
            {
                sale = 5;
            }
            saleresult = result2 * (100 - sale) / 100;
            label33.Text = "Общая сумма\nсо скидкой " + sale.ToString() + "%: " + saleresult + "р.";

            if (result2 <= 500)
            {
                label33.Text = "Скидка отстутсвует! \nСделайте заказ на сумму\nсвыше 500 руб!";
            }
            label31.Text = "Общая сумма: \n" + result2 + "р.";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox6.Text = null;
            numericUpDown1.Text = null;
            comboBox3.Text = null;
            richTextBox1.Text = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Value = 0;
            end = false;
            sec = 0;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (sec <= 90)
            {
                sec++;
                progressBar1.PerformStep();
            }
            else
                end = true;

            if (end)
            {
                DateTime time = DateTime.Now;
                string h = Convert.ToString(time.Hour);
                double summ = 0, price = 0;

                if (radioButton7.Checked == true)
                    price = 0.15;

                if (radioButton8.Checked == true)
                    price = 0.3;

                if (radioButton9.Checked == true)
                    price = 1;

                if (Convert.ToInt32(h) < 13 && Convert.ToInt32(h) > 8)
                {
                    summ = price * 0.6;
                    label39.Text = "Утренний тариф - Вы наговорили на: " + Math.Round((summ / sec), 3) + " руб.";
                }
                else
                    summ = price;
                label39.Text = "Вы наговорили на: " + Math.Round((summ / sec), 3) + " руб.";
                    progressBar1.Enabled = false;
                    timer1.Enabled = false;
            }
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            end = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;
        }


        Random c = new Random();
        public int a = 0, count = -1, tr = 0;

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox9.MaxLength = 3;
            if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (e.KeyChar == '\b') return;
            e.KeyChar = '\0';
        }

        private void button20_Click(object sender, EventArgs e)
        {
            a = c.Next(1, 100);
            timer2.Enabled = true;
            count = 60;
            label37.Text = "Игра началась";
            textBox9.Enabled = true;
            tr = 0;
            label42.Text = "Число попыток:" + tr;
        }


        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            int b;
            if (e.KeyCode == Keys.Enter)
            {
                tr++;
                label42.Text = "Число попыток:" + tr;
                b = Convert.ToInt32(textBox9.Text);
                if (b < a)
                    label43.Text = "Число меньше загаданного!";
                if (b > a)
                    label43.Text = "Число больше загаданного!";
                if (b == a)
                {
                    label37.Text = "ПОБЕДА";
                    timer2.Enabled = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (count != 0 && count > 0)
                        {
                            count--;
                            toolStripStatusLabel1.Text = " Осталось " + count + "сек";
                        }
                        else if (count == 0)
                        {
                            label37.Text = "ПОРАЖЕНИЕ";
                            textBox9.Enabled = false;
                            timer2.Stop();
                            MessageBox.Show(Convert.ToString(a), "Поражение");

                        }
        }
    }
}

    

