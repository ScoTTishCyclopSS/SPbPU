using System;
using System.Windows.Forms;

namespace Practice_4
{
    public partial class Form1 : Form
    {
        public int a, count = -1, tr;


        private readonly Random c = new Random();
        private bool end;

        private double result2;
        private double sec;

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
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var num1 = 10;
                var num2 = Convert.ToDouble(textBox2.Text);
                var result = num1 * num2;
                label4.Text = "Price:" + num1 + "rub." + "\nQuantity: " + num2 + "pcs." + "\nOrder value: " + result +
                              "rub.";
            }

            if (radioButton2.Checked)
            {
                var num1 = 15;
                var num2 = Convert.ToDouble(textBox2.Text);
                var result = num1 * num2;
                label4.Text = "Price:" + num1 + "rub." + "\nQuantity: " + num2 + "pcs." + "\nOrder value: " + result +
                              "rub.";
            }

            if (radioButton3.Checked)
            {
                var num1 = 20;
                var num2 = Convert.ToDouble(textBox2.Text);
                var result = num1 * num2;
                label4.Text = "Price:" + num1 + "rub." + "\nQuantity: " + num2 + "pcs." + "\nOrder value: " + result +
                              "rub.";
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
            if (textBox1.Text.Length < 6 || textBox1.Text == string.Empty)
                MessageBox.Show("The first field must have 6 digits in it!");
            if (textBox3.Text.Length < 6 || textBox3.Text == string.Empty)
                MessageBox.Show("The second field must have 6 digits in it!");
            if (comboBox1.Text == string.Empty)
            {
                MessageBox.Show("No region selected!");
            }
            else
            {
                var num1 = Convert.ToInt32(textBox1.Text);
                var num2 = Convert.ToInt32(textBox3.Text);
                if (num1 > num2)
                {
                    MessageBox.Show("The previous value cannot be greater than the current!");
                }
                else
                {
                    double result = num2 - num1;
                    if (comboBox1.SelectedItem == "St. Petersburg")
                        result = result * 4.3;
                    label5.Text = Convert.ToString(result);
                    if (comboBox1.SelectedItem == "Moscow")
                        result = result * 5.2;
                    label5.Text = Convert.ToString(result);
                    if (comboBox1.SelectedItem == "Yekaterinburg")
                        result = result * 3.4;
                    label5.Text = Convert.ToString(result);
                    if (comboBox1.SelectedItem == "Texas?")
                        result = result * 10.5;
                    label5.Text = Convert.ToString(result) + "rub.";
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
            if (e.KeyChar == ',') e.Handled = false;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',') e.Handled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == string.Empty)
                MessageBox.Show("Enter the variable in the 1st field!");
            if (textBox5.Text == string.Empty)
            {
                MessageBox.Show("Enter the variable in the 2nd field!");
            }
            else
            {
                if (radioButton4.Checked)
                {
                    var num1 = Convert.ToDouble(textBox4.Text);
                    var num2 = Convert.ToDouble(textBox5.Text);
                    var result = num1 * num2;
                    label13.Text = "Result: U = " + Math.Round(result, 3);
                }

                if (radioButton5.Checked)
                {
                    var num1 = Convert.ToDouble(textBox4.Text);
                    var num2 = Convert.ToDouble(textBox5.Text);
                    var result = num1 / num2;
                    label13.Text = "Result: R = " + Math.Round(result, 3);
                }

                if (radioButton6.Checked)
                {
                    var num1 = Convert.ToDouble(textBox4.Text);
                    var num2 = Convert.ToDouble(textBox5.Text);
                    var result = num1 / num2;
                    label13.Text = "Result: I = " + Math.Round(result, 3);
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
        {
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == ',') e.Handled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == string.Empty || comboBox2.Text == string.Empty || textBox8.Text == string.Empty)
            {
                MessageBox.Show("No data entered!");
            }
            else
            {
                var num1 = Convert.ToDouble(textBox7.Text);
                var num2 = Convert.ToDouble(textBox8.Text);
                double num4;
                if (num1 == 0)
                    MessageBox.Show("The initial amount cannot be equal to 0!");
                if (num2 == 0)
                    MessageBox.Show("The annual percentage cannot be equal to 0!");
                else
                    for (var num3 = Convert.ToInt32(comboBox2.SelectedItem); num3 > 0; num3--)
                    {
                        num1 = num1 * (1 + num2 / 100);
                        num4 = num1 - Convert.ToDouble(textBox7.Text);
                        label20.Text = "Deposit Income: " + Math.Round(num1, 3) + "rub." + "\nIncreased amount: " +
                                       Math.Round(num4, 3) + "rub.";
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
            if (days > 31 || months > 12 || age > 2017 || age == 0 || days == 0 || months == 0 ||
                (months == 2 && days > 28))
            {
                MessageBox.Show("Date entered incorrectly!");
            }
            else
            {
                var bornDate = new DateTime(age, months, days);
                var currentDate = DateTime.Now;
                var span = new DateTime((currentDate - bornDate).Ticks);
                days = span.Day - 1;
                months = span.Month - 1;
                age = span.Year - 1;
                label28.Text = "Your age:\n-> full years: " + Convert.ToString(age) + "\n-> months: " +
                               Convert.ToString(months) + "\n-> days: " + Convert.ToString(days);
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
            if (e.KeyChar == ',') e.Handled = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var num1 = Convert.ToDouble(textBox6.Text);
            var num2 = Convert.ToInt32(numericUpDown1.Text);
            var tovar = Convert.ToString(comboBox3.Text);
            double sale = 0;
            double saleresult = 0;
            var result = num1 * num2;
            richTextBox1.Text = richTextBox1.Text + tovar + ": " + Convert.ToString(numericUpDown1.Text) +
                                "pcs. by value of: " + result + "rub.\n";
            result2 += num1 * num2;
            if (result2 > 500 && result2 <= 1000) sale = 3;

            saleresult = result2 * (100 - sale) / 100;
            label33.Text = "Total amount\nwith discount " + sale + "%: " + saleresult + "rub.";
            if (result2 > 1000) sale = 5;

            saleresult = result2 * (100 - sale) / 100;
            label33.Text = "Total amount\nwith discount " + sale + "%: " + saleresult + "rub.";

            if (result2 <= 500) label33.Text = "No discount! \nMake an order over 500 rub.!";

            label31.Text = "Total amount: \n" + result2 + "rub.";
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
            {
                end = true;
            }

            if (end)
            {
                var time = DateTime.Now;
                var h = Convert.ToString(time.Hour);
                double summ = 0, price = 0;

                if (radioButton7.Checked)
                    price = 0.15;

                if (radioButton8.Checked)
                    price = 0.3;

                if (radioButton9.Checked)
                    price = 1;

                if (Convert.ToInt32(h) < 13 && Convert.ToInt32(h) > 8)
                {
                    summ = price * 0.6;
                    label39.Text = "Morning Fare - You've spoken up to: " + Math.Round(summ / sec, 3) + " rub.";
                }
                else
                {
                    summ = price;
                }

                label39.Text = "You've spoken up to: " + Math.Round(summ / sec, 3) + " rub.";
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
            label37.Text = "The game has begun";
            textBox9.Enabled = true;
            tr = 0;
            label42.Text = "Number of attempts:" + tr;
        }


        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            int b;
            if (e.KeyCode == Keys.Enter)
            {
                tr++;
                label42.Text = "Number of attempts:" + tr;
                b = Convert.ToInt32(textBox9.Text);
                if (b < a)
                    label43.Text = "The number is less than the mystery number!";
                if (b > a)
                    label43.Text = "The number is bigger than the mystery number!";
                if (b == a)
                {
                    label37.Text = "VICTORY";
                    timer2.Enabled = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (count != 0 && count > 0)
            {
                count--;
                toolStripStatusLabel1.Text = " Left: " + count + " sec";
            }
            else if (count == 0)
            {
                label37.Text = "LOSS";
                textBox9.Enabled = false;
                timer2.Stop();
                MessageBox.Show(Convert.ToString(a), "Loss");
            }
        }
    }
}
