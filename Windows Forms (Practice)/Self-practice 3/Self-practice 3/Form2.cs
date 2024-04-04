using System;
using System.Windows.Forms;

namespace Self
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            var main = Owner as Form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var main = Owner as Form1;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                main.brush1.Color = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var main = Owner as Form1;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                main.brush2.Color = colorDialog1.Color;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var main = Owner as Form1;

            if (trackBar1.Value < 4)
                main.timer1.Interval = 300;
            if (trackBar1.Value >= 4 && trackBar1.Value < 7)
                main.timer1.Interval = 100;
            if (trackBar1.Value > 7)
                main.timer1.Interval = 1;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }
    }
}