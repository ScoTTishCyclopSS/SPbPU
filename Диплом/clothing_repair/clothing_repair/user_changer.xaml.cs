using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace clothing_repair
{
    /// <summary>
    /// Логика взаимодействия для user_changer.xaml
    /// </summary>
    public partial class user_changer : Window
    {
        clothing_repairEntities1 db = new clothing_repairEntities1();
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
