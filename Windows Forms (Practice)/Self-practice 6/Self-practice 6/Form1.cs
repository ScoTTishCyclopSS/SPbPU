using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Self
{
    public partial class Form1 : Form
    {
        private readonly Encoding enc = Encoding.GetEncoding(1251);
        private readonly OpenFileDialog fd = new OpenFileDialog();
        private string file_name;

        public Form1()
        {
            InitializeComponent();
        }

        private int N => listBox1.Items.Count;

        private string list(int i)
        {
            return (string)listBox1.Items[i];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fd.ShowDialog() == DialogResult.OK && fd.FileName != "input.in")
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
            var x = textBox3.Text;
            var sel = listBox1.SelectedIndex;

            for (var i = sel != -1 ? sel + 1 : 0; i < N; i++)
            {
                if (list(i).Contains(x))
                {
                    listBox1.SelectedIndex = i;
                    return;
                }
            }

            MessageBox.Show("Not found.");
            listBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var a = File.ReadAllLines(fd.FileName, enc);
            var x = textBox1.Text;
            
            try
            {
                for (var i = 0; i < a.Length; i++)
                {
                    var au = a[i].Split(' ')[0];
                    var capacity = a[i].Split(' ')[1];
                    if (a[i][0] == x[0]) listBox1.Items.Add(a[i]);
                }
            }
            catch
            {
                MessageBox.Show("Err!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var a = File.ReadAllLines(fd.FileName, enc);
            var x = textBox2.Text;
            
            try
            {
                for (var i = 0; i < a.Length; i++)
                {
                    var au = a[i].Split(' ')[0];
                    var capacity = a[i].Split(' ')[1];
                    
                    if (capacity[0] == x[0]) listBox1.Items.Add(a[i]);
                }
            }
            catch
            {
                MessageBox.Show("Err!");
            }
        }
    }
}
