using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace clothing_repair
{
    public partial class order_info : Window
    {
        private readonly clothing_repairEntities1 db = new clothing_repairEntities1();
        public order o;
        public int w_i;


        public order_info(order info, int wn)
        {
            InitializeComponent();
            o = info;
            w_i = wn;

            if (info != null)
            {
                num.Text = info.id.ToString();
                pr.Text = info.price;
                cat.Text = info.categories.category;
                cl.Text = info.customer.name;
                mat.Text = info.user.username;
                fd.Text = info.date_of_receipt.ToLongDateString();
                st.Text = info.status;
                ed.Text = info.date_of_give.ToString();
                wi.Text = info.who_issued;
            }
        }

        private void Order_button_Click(object sender, RoutedEventArgs e)
        {
            switch (order_button.Content)
            {
                case "Принять заказ ✓":
                    if (o != null)
                    {
                        st.Text = "Выполняется";
                        db.order.FirstOrDefault(x => x.id == o.id).status = "Выполняется";
                        db.order.FirstOrDefault(x => x.id == o.id).user = db.user.FirstOrDefault(x => x.id == w_i);
                        db.SaveChanges();
                        DialogResult = true;
                    }

                    break;

                case "Оповестить заказчика ✉":
                    if (o != null)
                    {
                        st.Text = "Выполнен";
                        db.order.FirstOrDefault(x => x.id == o.id).status = "Выполнен";
                        db.SaveChanges();
                        email.send_email(db, o, "Ателье строчкин", "pentagon_0001@mail.ru", "pentagon_0001@mail.ru",
                            "1qaz2wsx.0001");
                        DialogResult = true;
                    }

                    break;

                case "Выдать заказ ✓":
                    if (o != null)
                    {
                        st.Text = "Выдан";
                        db.order.FirstOrDefault(x => x.id == o.id).status = "Выдан";
                        db.order.FirstOrDefault(x => x.id == o.id).who_issued =
                            db.user.FirstOrDefault(x => x.id == w_i).username;
                        db.order.FirstOrDefault(x => x.id == o.id).date_of_give = DateTime.Now;
                        db.SaveChanges();
                        DialogResult = true;
                    }

                    break;
            }
        }

        private void Order_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (o != null)
                st.Text = "Отказ";
            db.order.FirstOrDefault(x => x.id == o.id).status = "Отказ";
            db.SaveChanges();
            DialogResult = true;
        }

        private void St_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (st.Text)
            {
                case "Получен":
                    order_button.Content = "Принять заказ ✓";
                    break;

                case "Выполняется":
                    order_button.Content = "Оповестить заказчика ✉";
                    order_cancel.Visibility = Visibility.Hidden;
                    break;

                case "Выполнен":
                    order_button.Content = "Выдать заказ ✓";
                    order_cancel.Visibility = Visibility.Hidden;

                    break;

                case "Выдан":
                    order_button.Visibility = Visibility.Hidden;
                    order_cancel.Visibility = Visibility.Hidden;
                    break;

                case "Отказ":
                    order_button.Visibility = Visibility.Hidden;
                    order_cancel.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}