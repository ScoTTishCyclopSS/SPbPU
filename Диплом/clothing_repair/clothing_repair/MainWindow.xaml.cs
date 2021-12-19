using System.Linq;
using System.Windows;

namespace clothing_repair
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clothing_repairEntities1 db = new clothing_repairEntities1();


        public MainWindow()
        {
            InitializeComponent();
            Check_Admin();
            label_check.Visibility = Visibility.Hidden;
        }

        private void Check_Admin()
        {
            if (db.user.FirstOrDefault(x => x.log_in == "admin" && x.pass_word == "admin") == null)
            {
                db.user.Add(new user
                {
                    username = "Admin",
                    log_in = "admin",
                    pass_word = "admin",
                    role = "admin"
                });
                db.SaveChanges();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = db.user.FirstOrDefault(u => u.log_in == login_field.Text);
            if (user != null && user.pass_word == password_field.Password && user.pass_word != null && user.log_in == login_field.Text)
            {
                if (user.role == "admin")
                {
                    Window admin = new admin_window(user.id);
                    admin.Title += " " + "["+ user.username +"]";
                    admin.Show();
                    this.Close();                  
                }
                else
                    if (user.role == "worker")
                {
                    Window worker = new worker_window(user.id);
                    worker.Title += " " + "[" + user.username + "]";
                    worker.Show();
                    this.Close();                   
                }
            }
            else
                label_check.Visibility = Visibility.Visible;
        }
    }
}
