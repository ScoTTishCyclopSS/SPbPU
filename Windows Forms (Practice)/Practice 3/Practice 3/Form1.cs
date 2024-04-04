using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practice_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
            label1.Text = "The left button worked!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
            label1.Text = "The right button worked!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Location = new Point(94, 102);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label2.Top -= 5;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Top += 5;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label2.Left += 5;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label2.Left -= 5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Left -= 5;
            label2.Top -= 5;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Left += 5;
            label2.Top -= 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Left += 5;
            label2.Top += 5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Left -= 5;
            label2.Top += 5;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var num1 = Convert.ToDouble(textBox1.Text);
            var num2 = Convert.ToDouble(textBox2.Text);
            var result = num1 + num2;
            label5.Text = num1 + " + " + num2 + " = " + Math.Round(result, 3);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var num1 = Convert.ToDouble(textBox1.Text);
            var num2 = Convert.ToDouble(textBox2.Text);
            var result = num1 - num2;
            label5.Text = num1 + " - " + num2 + " = " + Math.Round(result, 3);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var num1 = Convert.ToDouble(textBox1.Text);
            var num2 = Convert.ToDouble(textBox2.Text);
            var result = num1 * num2;
            label5.Text = num1 + " * " + num2 + " = " + Math.Round(result, 3);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var num1 = Convert.ToDouble(textBox1.Text);
            var num2 = Convert.ToDouble(textBox2.Text);
            if (num2 == 0)
            {
                label5.Text = "You can't divide by 0!";
            }
            else
            {
                var result = num1 / num2;
                label5.Text = num1 + " / " + num2 + " = " + Math.Round(result, 3);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.BackColor = Color.LightSteelBlue;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Red;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Blue;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Green;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label6.BackColor = Color.Pink;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label6.BackColor = Color.DodgerBlue;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label6.BackColor = Color.DarkOliveGreen;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var a = Convert.ToString(textBox3.Text);
            textBox3.Text = a.ToLower();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var a = Convert.ToString(textBox3.Text);
            textBox3.Text = a.ToUpper();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            button19.SetBounds(e.X, e.Y, 90, 50);
            label13.Text = "X: " + e.X + " Y: " + e.Y;
        }

        private void button20_MouseMove(object sender, MouseEventArgs e)
        {
            button20.SetBounds(0, 0, e.X, e.Y);
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            button20.SetBounds(0, 0, e.X, e.Y);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            label14.Text = null;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            label14.Text = label14.Text + "Getting Focus*";
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            label14.Text = label14.Text + "Loss of focus*";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            label14.Text = label14.Text + "Click*";
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            label14.Text = label14.Text + "Double click*";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label14.Text = label14.Text + "Change in field*";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            textBox8.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            textBox7.BackColor = Color.White;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.Pink;
            textBox7.BackColor = Color.White;
            textBox8.BackColor = Color.White;
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.BackColor = Color.Pink;
            textBox6.BackColor = Color.White;
            textBox8.BackColor = Color.White;
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            textBox8.BackColor = Color.Pink;
            textBox6.BackColor = Color.White;
            textBox7.BackColor = Color.White;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '\b') e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') && e.KeyChar != 8 && e.KeyChar != '-') e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != '-') e.Handled = true;
        }

        private void label18_MouseMove(object sender, MouseEventArgs e)
        {
            label18.BackColor = Color.Pink;
            label25.Text = "3.10 Mouse in Quadrant 1";
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            label18.BackColor = Color.Black;
            label25.Text = "3.10 Mouse position";
        }

        private void label19_MouseMove(object sender, MouseEventArgs e)
        {
            label19.BackColor = Color.Pink;
            label25.Text = "3.10 Mouse in Quadrant 2";
        }

        private void label19_MouseLeave(object sender, EventArgs e)
        {
            label19.BackColor = Color.Black;
            label25.Text = "3.10 Mouse position";
        }

        private void label23_MouseMove_1(object sender, MouseEventArgs e)
        {
            label23.BackColor = Color.Pink;
            label25.Text = "3.10 Mouse in Quadrant 3";
        }

        private void label23_MouseLeave_1(object sender, EventArgs e)
        {
            label23.BackColor = Color.Black;
            label25.Text = "3.10 Mouse position";
        }

        private void label24_MouseMove_1(object sender, MouseEventArgs e)
        {
            label24.BackColor = Color.Pink;
            label25.Text = "3.10 Mouse in Quadrant 4";
        }

        private void label24_MouseLeave_1(object sender, EventArgs e)
        {
            label24.BackColor = Color.Black;
            label25.Text = "3.10 Mouse position";
        }

        private void panel4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && pictureBox1.Left > 4) pictureBox1.Left -= 5;
            if (e.KeyCode == Keys.Right && pictureBox1.Left <= 214) pictureBox1.Left += 5;
            if (e.KeyCode == Keys.Up && pictureBox1.Top > 4) pictureBox1.Top -= 5;
            if (e.KeyCode == Keys.Down && pictureBox1.Top <= 177) pictureBox1.Top += 5;
            if (e.KeyCode == Keys.Enter) pictureBox1.Location = new Point(0, 0);
        }
    }
}
