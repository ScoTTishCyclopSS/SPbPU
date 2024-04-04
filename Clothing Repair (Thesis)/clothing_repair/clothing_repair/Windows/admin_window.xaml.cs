using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace clothing_repair
{
    public partial class admin_window : Window
    {
        private readonly clothing_repairEntities1 db = new clothing_repairEntities1();
        private string role;
        public int worker_name;

        public admin_window(int name_worker)
        {
            InitializeComponent();
            itemsource.user_source(db, reg_dgv);
            label_check2.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rolereg_box.Text == "Администратор")
            {
                role = "admin";
            }
            else if (rolereg_box.Text == "Мастер")
            {
                role = "worker";
            }

            if (db.user.Any(x => x.log_in == loginreg_field.Text))
            {
                label_check2.Visibility = Visibility.Visible;
            }
            else
            {
                label_check2.Visibility = Visibility.Hidden;
                db.user.Add(new user
                {
                    username = usernamereg_field.Text,
                    role = role,
                    log_in = loginreg_field.Text,
                    pass_word = passreg_field.Text
                });
                db.SaveChanges();
            }

            itemsource.user_source(db, reg_dgv);
        }
        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            Close();
            main.Show();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (search1.Text == "")
            {
                itemsource.user_source(db, reg_dgv);
            }
            else
            {
                reg_dgv.ItemsSource = null;
                if (db.user.Any(x => x.username == search1.Text))
                    reg_dgv.ItemsSource = db.user.Where(x => x.username == search1.Text).ToList();
            }
        }

        private void All_orders_button_Click(object sender, RoutedEventArgs e)
        {
            var all_ord = new all_orders();
            all_ord.Show();
        }

        private void Cat_open_Click(object sender, RoutedEventArgs e)
        {
            var cats = new category_reg();
            cats.Show();
        }


        private void Search1_TextChanged(object sender, TextChangedEventArgs e)
        {
            reg_dgv.Items.Clear();
            Search_user(db.user.ToList(), search1.Text).ForEach(x => reg_dgv.Items.Add(x));
        }

        private void Change_user_Click(object sender, RoutedEventArgs e)
        {
            var u = (user)reg_dgv.SelectedItem;
            if (u != null)
            {
                var u_c = new user_changer();
                u_c.user_username.Text = u.username;
                u_c.user_login.Text = u.log_in;
                u_c.user_password.Text = u.pass_word;
                u_c.v = u;
                if (u_c.ShowDialog() == true) itemsource.user_source(db, reg_dgv);
            }
        }

        private void Reg_dgv_LoadingRow(object sender, DataGridRowEventArgs e)
        {
        }
        
        public static List<user> Search_user(List<user> list, string word)
        {
            return list.Where(x => IsGood(x, word)).ToList();
        }

        private static int Find(user s, int istart, char c)
        {
            var fio = s.username.ToCharArray();
            for (var i = istart; i < fio.Length; i++)
                if (c == fio[i])
                    return i;
            return -1;
        }

        private static bool IsGood(user x, string word)
        {
            var res = -1;
            for (var i = 0; i < word.Length; i++)
            {
                res = Find(x, res + 1, word[i]);
                if (res == -1)
                    return false;
            }

            return true;
        }

        private void Search1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            reg_dgv.Items.Clear();
            Search_user(db.user.ToList(), search1.Text).ForEach(x => reg_dgv.Items.Add(x));
        }
    }
}