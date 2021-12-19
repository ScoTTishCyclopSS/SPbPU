using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab12Fin
{
    [Serializable]
    public struct OrgInfo
    {
        public Byte[] name, address, contact;
        public int tel ;
        public OrgInfo(Byte[] Name, Byte[] Address, int Tel, Byte[] Contact)
        {
            name = new Byte[30];
            address = new Byte[30];
            contact = new Byte[30];
            tel = Tel;
                for (int i = 0; i < Name.Length; i++)
                {name[i] = Name[i];}
                for (int i = 0; i < Address.Length; i++)
                {address[i] = Address[i];}
                for (int i = 0; i < Name.Length; i++)
                { contact[i] = Contact[i]; }
                
        }
    }
    public partial class Form1 : Form
    {
        string file = "database.dat"; //имя файла
        int[] num;
        public Form1()
        {InitializeComponent();}
        long pos = 0;

        private void button1_Click(object sender, EventArgs e) //добавление
        {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Enter info in all fields");
                }
                else
                {
                    OrgInfo q = new OrgInfo(Encoding.GetEncoding(866).GetBytes(textBox1.Text), Encoding.GetEncoding(866).GetBytes(textBox2.Text), Convert.ToInt32(textBox3.Text), Encoding.GetEncoding(866).GetBytes(textBox4.Text));
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {

                        using (FileStream fs = new FileStream(file, FileMode.Append))
                        {
                            formatter.Serialize(fs, q);

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error of adding");
                    }

                    MessageBox.Show("Done successfull");
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                }
            }

        private void button2_Click(object sender, EventArgs e) //просмотр
        {
            Form2 F = new Form2(this);
            F.dbshow(file);
            F.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter the name of organization");
            }
            else
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        while (fs.Position < fs.Length)
                        {
                            pos = fs.Position;
                            var org2 = (OrgInfo)formatter.Deserialize(fs);
                            if (Convert.ToInt32(textBox1.Text) == org2.tel)
                            {
                                textBox1.Text = Encoding.GetEncoding(866).GetString(org2.name);
                                textBox2.Text = Encoding.GetEncoding(866).GetString(org2.address);
                                textBox3.Text = org2.tel.ToString();
                                textBox4.Text = Encoding.GetEncoding(866).GetString(org2.contact);
                                button3.Text = "Complete";
                                break;
                            }
                        }
                        if (button3.Text != "Complete")
                            MessageBox.Show("No matche found");
                    }

                }
                catch
                {
                    MessageBox.Show("Error of reading file");
                }
            }          
        }//поиск для корректировки

        private void button4_Click(object sender, EventArgs e) //поиск
        {
            num = new int[30];
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                int j = 0, l = 0;
                using (FileStream fs1 = new FileStream(file, FileMode.Open))
                {

                    bool t = true;


                    while (fs1.Position < fs1.Length)
                    {
                        var org3 = (OrgInfo)formatter.Deserialize(fs1);
                        t = true;

                        if (textBox1.Text != "")
                            if (textBox1.Text.ToLower() != Encoding.GetEncoding(866).GetString(org3.name).Trim('\0').ToLower())
                            {
                                t = false;
                            }

                        if (textBox2.Text != "")
                            if (textBox2.Text.ToLower() != Encoding.GetEncoding(866).GetString(org3.address).Trim('\0').ToLower())
                            {
                                t = false;
                            }

                        if (textBox3.Text != "")
                            if (textBox3.Text != org3.tel.ToString())
                            {
                                t = false;
                            }
                        if (textBox4.Text != "")
                            if (textBox4.Text.ToLower() != Encoding.GetEncoding(866).GetString(org3.contact).Trim('\0').ToLower())
                            {
                                t = false;
                            }


                        if (t)
                        {
                            num[j] = l;
                            j++;
                        }
                        l++;
                    }
                    if (j == 0) MessageBox.Show("No matches found");
                    else
                    {
                        fs1.Close();
                        Form2 F = new Form2(this);
                        F.show(num, file);
                        F.Show();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error of reading file");
            }


            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Complete")
            {
                OrgInfo q2 = new OrgInfo(Encoding.GetEncoding(866).GetBytes(textBox1.Text), Encoding.GetEncoding(866).GetBytes(textBox2.Text), Convert.ToInt32(textBox3.Text), Encoding.GetEncoding(866).GetBytes(textBox4.Text));
                try
                {

                    int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(OrgInfo));

                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs2 = new FileStream(file, FileMode.Open))
                    {
                        fs2.Seek(pos, SeekOrigin.Begin);
                        formatter.Serialize(fs2, q2);
                    }
                    MessageBox.Show("Done successfull");
                }
                catch
                {
                    MessageBox.Show("Error of correcting");
                }
                textBox1.Text = "";
            }
        }//корректировка
    }
}

