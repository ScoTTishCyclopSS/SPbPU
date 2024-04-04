using System.Linq;
using System.Windows;

namespace clothing_repair
{
    public partial class customer_changer : Window
    {
        private readonly clothing_repairEntities1 db = new clothing_repairEntities1();
        public customer v;

        public customer_changer()
        {
            InitializeComponent();
        }

        private void Cus_change_Click(object sender, RoutedEventArgs e)
        {
            var find = db.customer.FirstOrDefault(x => x.id == v.id);
            find.mail = customer_mail_ch.Text;
            find.name = customer_name_ch.Text;
            find.tel = customer_tel_ch.Text;
            db.SaveChanges();
            DialogResult = true;
        }
    }
}