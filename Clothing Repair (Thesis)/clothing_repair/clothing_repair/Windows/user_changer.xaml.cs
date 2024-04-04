using System.Linq;
using System.Windows;

namespace clothing_repair
{
    public partial class user_changer : Window
    {
        private readonly clothing_repairEntities1 db = new clothing_repairEntities1();
        public user v;

        public user_changer()
        {
            InitializeComponent();
        }

        private void Cus_change_Click(object sender, RoutedEventArgs e)
        {
            var find = db.user.FirstOrDefault(x => x.id == v.id);
            find.username = user_username.Text;
            find.log_in = user_login.Text;
            find.pass_word = user_password.Text;
            db.SaveChanges();
            DialogResult = true;
        }
    }
}