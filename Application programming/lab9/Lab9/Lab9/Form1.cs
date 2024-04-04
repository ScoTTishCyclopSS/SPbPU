using System;
using System.Windows.Forms;

namespace Lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d_Today = DateTime.Today;
            DateTime d_User = Convert.ToDateTime(maskedTextBox1.Text);
            
            if (d_Today < d_User)
                label14.Text = "You haven't been born yet. Enter the date correctly!";
            
            switch (d_User.Year % 12)
            {
                case 0: MessageBox.Show("Monke year!"); break;
                case 1: MessageBox.Show("Rooster year!"); break;
                case 2: MessageBox.Show("Dog year!"); break;
                case 3: MessageBox.Show("Pig year!"); break;
                case 4: MessageBox.Show("Rat year!"); break;
                case 5: MessageBox.Show("Cow year!"); break;
                case 6: MessageBox.Show("Tiger year!"); break;
                case 7: MessageBox.Show("Rabbit year!"); break;
                case 8: MessageBox.Show("Dragon year!"); break;
                case 9: MessageBox.Show("Snake year!"); break;
                case 10: MessageBox.Show("Horse year!"); break;
                case 11: MessageBox.Show("Sheep year!"); break;
            }
        }
    }
}
