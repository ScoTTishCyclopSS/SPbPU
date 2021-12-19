using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace clothing_repair
{
    /// <summary>
    /// Логика взаимодействия для worker_window.xaml
    /// </summary>
    public partial class worker_window : Window
    {
        clothing_repairEntities1 db = new clothing_repairEntities1();

        public int worker_name;
        public double sale_c;

        public worker_window(int name_worker)
        {
            InitializeComponent();
            itemsource.cus_source(db, customers);
            itemsource.order_source(db, order_dgv);
            categories_box.ItemsSource = db.categories.ToList();
            worker_name = name_worker;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            Window new_costomer = new customer_reg();            
            if (new_costomer.ShowDialog().Equals(true))
            {
                itemsource.cus_source(db, customers);
            }               
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            int sum = 0;
            double result = 0;
            DateTime dd = DateTime.Now.AddMonths(-3);


            db.order //конченная херь
                   .Where(x => x.customer.id == ((customer)customers.SelectedItem).id)
                   .OrderBy(x => x.date_of_receipt)
                   .Where(x => x.date_of_receipt >= dd)
                   .ToList()
                   .ForEach(x => list.Add(x.price));

            for (int i = 0; i < list.Count; i++)
                sum += Convert.ToInt32(list[i]);

            if (sum >= 10000)
            {
                sale_c = 0.9;
                result = double.Parse(price_field.Text) * sale_c;
                sale_field.Content += " 10%";
            }
            else
            {
                result = double.Parse(price_field.Text);
                sale_field.Content += " нет";

            }


            db.order.Add(new order
            {
                user = db.user.FirstOrDefault(x => x.id == worker_name),
                price = Convert.ToString(result),
                date_of_receipt = DateTime.Now,
                categories = db.categories.FirstOrDefault(x => x.id == ((categories)categories_box.SelectedItem).id),
                date_of_give = null,
                customer = db.customer.FirstOrDefault(x => x.id == ((customer)customers.SelectedItem).id),
                status = "Получен",
                who_issued = null
            });
            db.SaveChanges();
            order_dgv.Items.Clear();
            db.order.ToList().ForEach(x => order_dgv.Items.Add(x));
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {        
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }

       

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            

            if (search1.Text == "")
            {
               itemsource.cus_source(db, customers);
            }
            else
            {
                customers.ItemsSource = null;
                if (db.customer.Any(x => x.tel == search1.Text))
                    customers.ItemsSource = db.customer.Where(x => x.tel == search1.Text).ToList();
            }
        }

        private void Change_customer_Click(object sender, RoutedEventArgs e)
        {
            customer c = (customer)customers.SelectedItem;
            customer_changer c_c = new customer_changer();
            c_c.customer_name_ch.Text = c.name;
            c_c.customer_mail_ch.Text = c.mail;
            c_c.customer_tel_ch.Text = c.tel;
            c_c.v = c;
            if(c_c.ShowDialog() == true)
            {
                itemsource.cus_source(db, customers);
            }
                
        }

        private void Order_dgv_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (((order)(e.Row.DataContext)).status == "Выдан")
            {
                e.Row.Background = new SolidColorBrush(Color.FromArgb(85, 145, 255, 133));
            }            
            
                if (((order)(e.Row.DataContext)).status == "Выполняется")
            {
                e.  Row.Background = new SolidColorBrush(Color.FromArgb(85, 18, 169, 206));
            }
        }

        public static List<customer> Search_customer(List<customer> list, string word) => list.Where(x => IsGood(x, word)).ToList();
        private static int Find(customer s, int istart, char c)
        {
            var fio = s.name.ToCharArray();
            for (int i = istart; i < fio.Length; i++)
                if (c == fio[i])
                    return i;
            return -1;
        }
        private static bool IsGood(customer x, string word)
        {
            int res = -1;
            for (int i = 0; i < word.Length; i++)
            {
                res = Find(x, res + 1, word[i]);
                if (res == -1)
                    return false;
            }
            return true;
        }

        private void Search1_TextChanged(object sender, TextChangedEventArgs e)
        {
            customers.Items.Clear();
            Search_customer(db.customer.ToList(), search1.Text).ForEach(x => customers.Items.Add(x));
        }

        private void Order_dgv_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var info = ((order)order_dgv.SelectedItem);
            if (info != null)
            {
                order_info w_inf = new order_info(info, worker_name);
                w_inf.Title += " [" + info.id + "]";
                if (w_inf.ShowDialog() == true)
                {
                    itemsource.order_source(db, order_dgv);
                }
            }
        }
    }
}
