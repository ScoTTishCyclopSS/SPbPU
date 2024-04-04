using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace clothing_repair
{
    public partial class all_orders : Window
    {
        private readonly clothing_repairEntities1 db = new clothing_repairEntities1();

        public all_orders()
        {
            InitializeComponent();
            itemsource.order_source(db, all_orders_dgv);
        }

        private void All_orders_dgv_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (((order)e.Row.DataContext).status == "Выдан")
                e.Row.Background = new SolidColorBrush(Color.FromArgb(85, 145, 255, 133));

            if (((order)e.Row.DataContext).status == "Выполняется")
                e.Row.Background = new SolidColorBrush(Color.FromArgb(85, 18, 169, 206));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                if (search_box.SelectedIndex > -1)
                    switch (search_box.SelectedIndex)
                    {
                        case 0:
                            all_orders_dgv.Items.Clear();
                            Search_on_order(db.order.ToList(), search_tb.Text, "order_n")
                                .ForEach(x => all_orders_dgv.Items.Add(x));

                            break;
                        case 1:
                            all_orders_dgv.Items.Clear();
                            Search_on_order(db.order.ToList(), search_tb.Text, "customer")
                                .ForEach(x => all_orders_dgv.Items.Add(x));
                            break;
                        case 2:
                            all_orders_dgv.Items.Clear();
                            Search_on_order(db.order.ToList(), search_tb.Text, "user")
                                .ForEach(x => all_orders_dgv.Items.Add(x));
                            break;
                    }
                if (search_tb.Text == "")
                    itemsource.order_source(db, all_orders_dgv);
            }
        }

        public static List<order> Search_on_order(List<order> list, string word, string type)
        {
            return list.Where(x => IsGood(x, word, type)).ToList();
        }

        private static int Find(order o, int istart, char c, string type)
        {
            var search = ""; //вне свича
            switch (type)
            {
                case "order_n":
                    search = o.id.ToString();
                    break;
                case "customer":
                    search = o.customer.name;
                    break;
                case "user":
                    search = o.user.username;
                    break;
            }

            for (var i = istart; i < search.Length; i++)
                if (c == search[i])
                    return i;
            return -1;
        }

        private static bool IsGood(order x, string word, string type)
        {
            var res = -1;
            for (var i = 0; i < word.Length; i++)
            {
                res = Find(x, res + 1, word[i], type);
                if (res == -1)
                    return false;
            }

            return true;
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            var os = new order_statistic();
            os.Show();
        }
    }
}