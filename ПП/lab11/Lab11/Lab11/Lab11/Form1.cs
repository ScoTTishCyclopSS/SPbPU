using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace Lab11
{
    public partial class Form1 : Form
    {
        TextFile txt = null;
        public Form1()
        {
            InitializeComponent();
            Width = 355;
        }
        public string ftxt; // переменная для создания временного файла
        public bool savef = false; //переменная для проверки сохранения
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TextFile txt = new TextFile(ftxt)
            {
                MyText = richTextBox1.Text
            };
            if (!File.Exists(txt.MyText))
            {
                saveFileDialog1.Filter = "Текстовый файл(*.txt)|*.txt|Файл rtf(*.rtf)|*.rtf|Все файлы(*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                txt = new TextFile(filename)
                {
                    MyText = richTextBox1.Text
                };
            }
            txt.SaveFile();
            savef = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear(); //очищение
            richTextBox2.Clear();
            openFileDialog1.Filter = "Текстовый файл(*.txt)|*.txt|Файл rtf(*.rtf)|*.rtf|Все файлы(*.*)|*.*"; //фильтр
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            if (Width == 355) 
            {
                for(int i = 0;i < 19; i++)
                Width += 19;
            }
            
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            ftxt = filename;
            TextFile txt = new TextFile(filename);
            // читаем файл в строку
            txt.ReadFile();
            richTextBox1.AppendText(txt.MyText);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            StreamWriter textFile = new StreamWriter("rbt.txt");
            string text = richTextBox1.Text;
            string text1 = richTextBox2.Text;
            string[] str = text.Split('\n');
            string[] str1 = text1.Split('\n');
            string[] buf = new string[richTextBox1.Lines.Count()];
            for (int i = 0; i < richTextBox1.Lines.Count(); i++)
            {
                buf[i] = str[i] + " " + str1[i];
                textFile.WriteLine(buf[i]);
            }
            textFile.Close();
            string fileName = saveFileDialog1.FileName;
            if (fileName == "")
            { TextFile txt = new TextFile("rbt.txt"); Print(txt); }
            else
            { TextFile txt = new TextFile(fileName); Print(txt); } 
        }
        void Print(TextFile txt)
        {
            if (richTextBox1.Text == "")
                return;
            else
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                    txt.PrintResult(richTextBox1.Font);
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string sl = toolStripTextBox1.Text.ToLower();
            string filename = openFileDialog1.FileName;
            TextFile txt = new TextFile(filename)
            {
                MyText = richTextBox1.Text.ToLower()
            };
            txt.SearchWords(sl, richTextBox2);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(savef == false)
            {
             DialogResult test = MessageBox.Show("Сохранить?", "Сохранение", MessageBoxButtons.YesNo);       
                            if (test == DialogResult.Yes)
                                if (richTextBox1.Text != "")
                                    toolStripButton4_Click(sender, e);
            }
           
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            if (File.Exists(ftxt))
            {
                txt = new TextFile(ftxt);
                txt.SAVE(richTextBox1);
                savef = true;
            }
           else
            {
                toolStripButton1.PerformClick();
            }
        }

            

    }
}
