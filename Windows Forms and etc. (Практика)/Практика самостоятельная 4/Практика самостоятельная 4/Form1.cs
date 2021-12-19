using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_самостоятельная_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int[] massiv; //задаем массив 
        int n = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            int[] massiv = new int[n]; //создание массива
            for (int i = 0; i < n; i++)
            {
                massiv[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value); //конвертация чисел в целые и вывод в нашу таблицу
            }

            int imin = -1; //нахождение первого отриц. элемента
            for (int i = 0; i < n; i++)
            {
                if (massiv[i] < 0)
                {
                    imin = i;
                    break;
                }
            }

            int imax = -1; //нахождение последнего отриц. элемента
            for (int i = 0; i < n; i++)
            {
                if (massiv[i] < 0)
                {
                    imax = i;
                }
            }
            label3.Text = "Номер первого отрицательного числа: " + imin + "\nНомер последнего отрицательного числа: " + imax;

 

            if (imax - imin > 1) //счет произведения всех чисел между ними
            {
                int proz = 1;
                for (int i = imin + 1; i < imax; i++)
                {
                    proz *= massiv[i];
                }
                label3.Text += "\nПроизведение между ними: " + proz;
            }
            else //вывод сообщения в случае ошибки
            {
                MessageBox.Show("ОШИБКА:\nВозможные причины:\n1.Отрицательный элемент всего один;\n2.Отрицательных элементов нет;\n3.Между 1ым отрицательным числом и 2ым нету других значений;");
            }
        }

        private void radioButton1_Click(object sender, EventArgs e) //создания свойства click для радиобаттона, отвечающего за создание случайного массива
        {
            n = (int)this.numericUpDown1.Value;
            bool ronly = radioButton1.Checked; //создание bool отвечающего за ReadOnly
            Random rand2 = new Random();
            dataGridView1.ReadOnly = ronly;
            dataGridView1.ColumnCount = n;
            
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = i.ToString(); 
                if (ronly) 
                {
                    dataGridView1.Rows[0].Cells[i].Value = rand2.Next(-100, 100).ToString(); //массив от -100 до 100
                }
                else
                {
                    dataGridView1.Rows[0].Cells[i].Value = 0;
                }
                
            }
        }
    }
}