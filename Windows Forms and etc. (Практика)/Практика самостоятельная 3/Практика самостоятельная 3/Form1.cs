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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Rectangle rc;   //задаем параметры прямоугольной области
        public int sec = 0;     
        public int w = 100, h = 50;
        public int x = 0, y = 100;
        public int dx = 5;
        
        public enum STATUS { Left, Right };  //режимы движения
        public STATUS flag;
        public SolidBrush brush1 = new SolidBrush(Color.Red);// кисть смены 1   
        public SolidBrush brush2 = new SolidBrush(Color.Green);// кисть смены 2
        SolidBrush curBrush = new SolidBrush(Color.Red);// кисть основная

        private void button1_Click(object sender, EventArgs e)
        {      
            SolidBrush curBrush = new SolidBrush(brush1.Color); // кисть основная зависти от выбора цвета для кисти смены 1
            if (timer1.Enabled == false) //функции для смены вида кнопок старт/стоп при нажатии на них
            { 
                timer1.Enabled = true;
                timer1.Start();
                sec = 0;
                button1.Text = "Стоп";
                button1.ForeColor = Color.Red;
            }
            else
            {
                timer1.Enabled = false;
                timer1.Stop();
                sec = 0;
                button1.Text = "Старт";
                button1.ForeColor = Color.Lime;
            }
        }
        private void button2_Click(object sender, EventArgs e) //становление 2ой формы с настройками
        {
            Form2 sett = new Form2();
            sett.Owner = this; //становление владельцем - форма 1
            sett.ShowDialog(); //вызов настроек
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1; //отмечаем что владелец форма 1
            sec++;  // секунды
            rc = new Rectangle(x, y, w, h); // размер прямоугольной области
            this.Invalidate(rc, true);      // вызываем прорисовку этой области

            if (flag == STATUS.Left) // движение влево
            {
                x -= dx;
            }
            if (flag == STATUS.Right) // движение вправо
            {
                x += dx;
            }
            if (x >= (this.ClientSize.Width - w)) // если достигли правого края формы
            {
                flag = STATUS.Left; // меняем статус движения на левый
                curBrush.Color = brush1.Color;

            }
            else
                if (x <= 1) // если достигли левого края формы
                {
                    flag = STATUS.Right;    // меняем статус движения на правый
                    curBrush.Color = brush2.Color;
                }
            rc = new Rectangle(x, y, w, h); // новая прямоугольная область
            this.Invalidate(rc, true);  // снова вызываем прорисовку этой области
        }

        private void Form1_Paint(object sender, PaintEventArgs e) // событие перерисовки формы
        {
        Graphics r = e.Graphics;                   
        r.FillPolygon(curBrush, new PointF[] { new PointF(x+50, y), new PointF(x + 100, y + 25), new PointF(x + 50, y + 50), new PointF(x, y+25) });
            // вызов многоугольника (ромба) на экран
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
               this.Close(); 
        }    
    }
}
