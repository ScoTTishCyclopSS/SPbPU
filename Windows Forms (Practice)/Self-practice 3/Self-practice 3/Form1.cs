using System;
using System.Drawing;
using System.Windows.Forms;

namespace Self
{
    public partial class Form1 : Form
    {
        public enum STATUS
        {
            Left,
            Right
        }

        private readonly SolidBrush curBrush = new SolidBrush(Color.Red);

        public SolidBrush brush1 = new SolidBrush(Color.Red);
        public SolidBrush brush2 = new SolidBrush(Color.Green);
        public int dx = 5;
        public STATUS flag;
        private Rectangle rc;
        public int sec;
        public int w = 100, h = 50;
        public int x, y = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var curBrush = new SolidBrush(brush1.Color);

            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                timer1.Start();
                sec = 0;
                button1.Text = "Stop";
                button1.ForeColor = Color.Red;
            }
            else
            {
                timer1.Enabled = false;
                timer1.Stop();
                sec = 0;
                button1.Text = "Start";
                button1.ForeColor = Color.Lime;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sett = new Form2();
            sett.Owner = this;
            sett.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var main = Owner as Form1;
            sec++;
            rc = new Rectangle(x, y, w, h);
            Invalidate(rc, true);

            if (flag == STATUS.Left)
                x -= dx;
            if (flag == STATUS.Right)
                x += dx;
            if (x >= ClientSize.Width - w)
            {
                flag = STATUS.Left;
                curBrush.Color = brush1.Color;
            }
            else if (x <= 1)
            {
                flag = STATUS.Right;
                curBrush.Color = brush2.Color;
            }

            rc = new Rectangle(x, y, w, h);
            Invalidate(rc, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var r = e.Graphics;
            r.FillPolygon(curBrush,
                new[]
                {
                    new PointF(x + 50, y), new PointF(x + 100, y + 25), new PointF(x + 50, y + 50),
                    new PointF(x, y + 25)
                });
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }
    }
}