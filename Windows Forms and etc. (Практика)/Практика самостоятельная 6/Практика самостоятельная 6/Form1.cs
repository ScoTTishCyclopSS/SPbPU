using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Практика_самостоятельная_6
{
    public partial class Form1 : Form
    {
        int N { get { return listBox1.Items.Count; } }
        string list(int i) { return (string)listBox1.Items[i]; }
        public Form1()
        {
            InitializeComponent();
        }
        string file_name = null;
        OpenFileDialog fd = new OpenFileDialog();
        Encoding enc = Encoding.GetEncoding(1251);


        private void button3_Click(object sender, EventArgs e)
        {
            
            if ((fd.ShowDialog() == DialogResult.OK) && (fd.FileName != "Список.txt"))
            {
                var sr = new StreamReader(fd.FileName, enc);
                {
                    var str = sr.ReadToEnd();
                    listBox1.Items.AddRange(File.ReadAllLines(fd.FileName, enc));
                    file_name = fd.FileName;
                }
            } 
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string x = textBox3.Text;
            int sel = listBox1.SelectedIndex;
            for(int i = sel != -1 ? sel + 1 : 0; i < N; i++)
            if(list(i).Contains(x))
            {
                listBox1.SelectedIndex = i;
                return;
            }
            MessageBox.Show("Не найдено");
            listBox1.SelectedIndex = -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] a = System.IO.File.ReadAllLines(fd.FileName, enc);
            string x = textBox1.Text;
            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    string au = a[i].Split(' ')[0];
                    string capacity = a[i].Split(' ')[1];
                    if (a[i][0] == x[0])
                    {
                        listBox1.Items.Add(a[i]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] a = System.IO.File.ReadAllLines(fd.FileName, enc);
            string x = textBox2.Text;
            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    string au = a[i].Split(' ')[0];
                    string capacity = a[i].Split(' ')[1];
                    //if (a[i][1] == x[0])
                    if (capacity[0] == x[0])
                    {
                        listBox1.Items.Add(a[i]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            } 
        }
    }
}
