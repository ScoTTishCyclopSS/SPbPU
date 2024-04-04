using System.Windows;

namespace clothing_repair
{
    public partial class customer_reg : Window
    {
        private readonly clothing_repairEntities1 db = new clothing_repairEntities1();

        public customer_reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            db.customer.Add(new customer
            {
                name = customer_name.Text,
                mail = customer_mail.Text,
                tel = customer_tel.Text
            });

            db.SaveChanges();
            Close();
        }
    }
}