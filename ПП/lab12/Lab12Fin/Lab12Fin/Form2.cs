using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Lab12Fin
{
    public partial class Form2 : Form
    {
        Form1 form;
        public Form2(Form1 _form)
        {
            InitializeComponent();
            form = _form;
        }
        public void dbshow(string file)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                dataGridView1.ColumnCount = 4; dataGridView1.RowCount = 1;
                dataGridView1.Columns[0].HeaderText = "Name";
                dataGridView1.Columns[1].HeaderText = "Address";
                dataGridView1.Columns[2].HeaderText = "Telephone";
                dataGridView1.Columns[3].HeaderText = "Contact";

                using (FileStream fs = new FileStream(file, FileMode.Open))
                {

                    while (fs.Position < fs.Length)
                    {

                        var org = (OrgInfo)bf.Deserialize(fs);
                        dataGridView1.Rows.Add(Encoding.GetEncoding(866).GetString(org.name), Encoding.GetEncoding(866).GetString(org.address), org.tel, Encoding.GetEncoding(866).GetString(org.contact));
                    }
                }


            }
            catch
            {
                MessageBox.Show("Error of reading file");
            }
        }
        public void show(int[] mas, string file2)
        {
            dataGridView1.ColumnCount = 4; dataGridView1.RowCount = 1;
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderText = "Address";
            dataGridView1.Columns[2].HeaderText = "Telephone";
            dataGridView1.Columns[3].HeaderText = "Contact";
            try
            {

                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs2 = new FileStream(file2, FileMode.Open))
                {

                    int a = 0, b = 0;
                    while (fs2.Position < fs2.Length)
                    {

                        var org = (OrgInfo)formatter.Deserialize(fs2);

                        string t1 = "";


                        t1 += org.address;
                        if (mas[b] == a)
                        {
                            dataGridView1.Rows.Add(Encoding.GetEncoding(866).GetString(org.name), Encoding.GetEncoding(866).GetString(org.address), org.tel, Encoding.GetEncoding(866).GetString(org.contact));
                            b++;
                        }

                        a++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}