using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_самостоятельная_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form1 main = this.Owner as Form1; //становление владельцем формы2 - форма1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); //закрытие настроек
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            Form1 main = this.Owner as Form1;
            if (colorDialog1.ShowDialog() == DialogResult.OK) //открытие палитры и выбор цвета для 1кисти
                main.brush1.Color = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (colorDialog1.ShowDialog() == DialogResult.OK)//открытие палитры и выбор цвета для 2кисти
                main.brush2.Color = colorDialog1.Color;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            //установление скоростей движения фигуры в зависимости от положения ползунка на трэкбаре
            if (trackBar1.Value < 4)
                main.timer1.Interval = 300; //медленно
            if (trackBar1.Value >= 4 && trackBar1.Value < 7)
                main.timer1.Interval = 100;//средне
            if (trackBar1.Value > 7)
                main.timer1.Interval = 1;//быстро
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close(); //при нажатии любой клавиши - программа вылетает
        }     
    }
}
