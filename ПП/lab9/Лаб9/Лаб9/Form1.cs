using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d_Today, d_User;
            d_Today = DateTime.Today;		// сегодняшняя дата
            d_User = Convert.ToDateTime(maskedTextBox1.Text);  // ввод даты рождения
            if (d_Today < d_User)
                label14.Text = " Вы ещё не родились. Введите дату правильно!";
            switch (d_User.Year % 12)
            {
                case 0: MessageBox.Show("Год Monkey"); break;
                case 1: MessageBox.Show("Год Петуха"); break;
                case 2: MessageBox.Show("Год Собаки"); break;
                case 3: MessageBox.Show("Год Свиньи"); break;
                case 4: MessageBox.Show("Год Rat"); break;
                case 5: MessageBox.Show("Год Коровы"); break;
                case 6: MessageBox.Show("Год Тигра"); break;
                case 7: MessageBox.Show("Год Зайца"); break;
                case 8: MessageBox.Show("Год Дракона"); break;
                case 9: MessageBox.Show("Год Змеи"); break;
                case 10: MessageBox.Show("Год Лошади"); break;
                case 11: MessageBox.Show("Год Овцы"); break;
            }
        }
    }
}
