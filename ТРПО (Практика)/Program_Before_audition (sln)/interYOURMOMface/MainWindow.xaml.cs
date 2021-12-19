using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace interYOURMOMface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        String sex;
        Model1Container db;
        DateTime passDate,  birthDate, creditStart, creditEnd, cardStart, cardEnd;
        public MainWindow()
        {

            InitializeComponent();
            db = new Model1Container();

            //добавление процентов в комбобокс
            percent.Items.Add("8");
            percent.Items.Add("10");
            percent.Items.Add("12");

            //добавление валют в комбобокс
            currency.Items.Add("RUB");
            currency.Items.Add("DOLLAR");
            currency.Items.Add("EURO");

            //добавление вариантов семейного положения в комбобокс
            family_status.Items.Add("в браке");
            family_status.Items.Add("не в браке");

            //добавление вариантов образования в комбобокс
            education.Items.Add("полное среднее");
            education.Items.Add("среднее специальное");
            education.Items.Add("полное специальное");

            //добавление типов карт в комбобокс
            card_type.Items.Add("VISA");
            card_type.Items.Add("MASTERCARD");
            card_type.Items.Add("MAESTRO");

            dgv.ItemsSource = new observe<credit>(db.credit.ToList()).List.ToBindingList();
           
        }

        private void incert_Click(object sender, RoutedEventArgs e)
        {
            var r = ((credit)dgv.SelectedItem);
            decimal s = decimal.Parse( r.remainer);
            r.remainer = (s - decimal.Parse(month_check.Text)).ToString();
  
            db.SaveChanges();
            itemsourse.dgv(db, dgv);            
        }
  
        private void incert_month_Click(object sender, RoutedEventArgs e)
        {
            int mon = Convert.ToInt32(month_check.Text);
            int some = Convert.ToInt32(some_month.Text);
            var r = ((credit)dgv.SelectedItem);
            decimal s = decimal.Parse(r.remainer);
            r.remainer = (s -(mon*some)).ToString();

            db.SaveChanges();
        }
        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var r = ((credit)dgv.SelectedItem);
            if(r!=null)
            {
                dogovor.Items.Clear();
                usloviya.Items.Clear();

                month_check.Text = r.month_sum.ToString();
                client_fio.Text = r.customer.fio.ToString();

                dogovor.Items.Add(r.customer.fio);
                dogovor.Items.Add(r.customer.birthdate);
                dogovor.Items.Add(r.customer.live_place);
                dogovor.Items.Add(r.customer.passport_info);
                dogovor.Items.Add(r.customer.passport_number);
                dogovor.Items.Add(r.customer.credit_reason);

                usloviya.Items.Add(r.percent_set);
                usloviya.Items.Add(r.currency);
                usloviya.Items.Add(r.credit_start);
                usloviya.Items.Add(r.credit_end);
                usloviya.Items.Add(r.sum);
                usloviya.Items.Add(r.card.card_type);
                }
        }
        private void res_month_incert_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int per =  Convert.ToInt32(percent.Text);
            int sum = Convert.ToInt32(sum_credit.Text);
            int month = Convert.ToInt32(sum_month.Text);
            int res = (((sum/100)*per)+sum)/ month;
            res_month_incert.Text = res.ToString();
        }
        private void random_check_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int mon = Convert.ToInt32(month_check.Text);
            int some = Convert.ToInt32(some_month.Text);
            random_check.Text = (mon * some).ToString();
        }
        private void fio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void passport_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            passport_number.MaxLength = 12;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void tel_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            tel_number.MaxLength = 11;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void education_place_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void work_place_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            work_place_number.MaxLength = 11;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void month_income_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void sum_credit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void sum_month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            sum_month.MaxLength = 2;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void some_month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            some_month.MaxLength = 2;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void check_word_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void system_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            system_code.MaxLength = 1;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void bank_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bank_code.MaxLength = 5;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void bill_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            bill_number.MaxLength = 9;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void check_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            check_number.MaxLength = 1;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }
        private void cvv_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            cvv.MaxLength = 1;
            if (Char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void to_card_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res_to_card = MessageBox.Show("Принять заявку и перейти к регистрации К/К?", "Подтвердить?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res_to_card == MessageBoxResult.Yes)
            {
                main_tabcon.SelectedItem = card_reg;
                main_reg.IsEnabled = false;
                rem_reg.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Заявка отклонена!");
            }
        }

        private void full_reset_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reset = MessageBox.Show("Отменить регистрацию клиента и вернуться на главную страницу?", "Отмена", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (reset == MessageBoxResult.Yes)
            {
                main_reg.IsEnabled = true;
                rem_reg.IsEnabled = true;
                main_tabcon.SelectedItem = main_reg;
                card_reg.IsEnabled = false;
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //проверка на пол
            if (male.IsChecked == true) { sex = "men"; }
            else if (female.IsChecked == true) { sex = "female"; }
            //переменная выбранной даты для пасспорта и даты рождения, начала и конца кредитования, действия карты
            passDate = passport_date.SelectedDate.Value.Date;
            birthDate = birthdate.SelectedDate.Value.Date;
            creditStart = start.SelectedDate.Value.Date;
            creditEnd = end.SelectedDate.Value.Date;
            cardStart = card_start.SelectedDate.Value.Date;
            cardEnd = card_end.SelectedDate.Value.Date;
            //информация о деталях кредита
            db.Database.ExecuteSqlCommand("INSERT INTO customer VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}) ",
                                             fio.Text, passport_number.Text, passDate, passport_info.Text, sex, family_status.Text, birthDate, tel_number.Text, email.Text, education.Text, education_place_code.Text, live_place.Text, work_place.Text, work_place_number.Text, work_post.Text, month_income.Text, credit_reason.Text);
            db.Database.ExecuteSqlCommand("INSERT INTO card VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}) ",
                                             IL.Text, card_type.Text, system_code.Text, bank_code.Text, bill_number.Text, check_number.Text, cvv.Text, cardStart, cardEnd, check_word.Text);            
            db.Database.ExecuteSqlCommand("INSERT INTO credit VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}) ",
                                            percent.Text, currency.Text, creditStart, creditEnd, remainer.Text, sum_credit.Text, res_month_incert.Text, sum_month.Text, db.card.ToList().Last().card_id, db.customer.ToList().Last().customer_id);
            
            main_reg.IsEnabled = true;
            rem_reg.IsEnabled = true;
            dgv.ItemsSource = new observe<credit>(db.credit.ToList()).List.ToBindingList();
            main_tabcon.SelectedItem = main_reg;
            MessageBox.Show("Кредитная запись добавлена!");
        }

        private void sum_month_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
            if (DateTime.Today < end.SelectedDate)
            {
                date.date_rem(end, start, sum_month, card_start, card_end);
            }
            else
            {
                MessageBox.Show("Конечная дата должна быть позже начала!");
            }
            
        }

        private void exit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void card_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(card_type.SelectedItem == "VISA")
            {
                img.Source = new BitmapImage(new Uri("pack://application:,,,/res/visa.png"));
                img_Copy.Source = new BitmapImage(new Uri("pack://application:,,,/res/visa.png"));
            }
            else
            if (card_type.SelectedItem == "MASTERCARD")
            {
                img.Source = new BitmapImage(new Uri("pack://application:,,,/res/mastercard.png"));
                img_Copy.Source = new BitmapImage(new Uri("pack://application:,,,/res/mastercard.png"));
            }
            else
            if (card_type.SelectedItem == "MAESTRO")
            {
                img.Source = new BitmapImage(new Uri("pack://application:,,,/res/maestro.png"));
                img_Copy.Source = new BitmapImage(new Uri("pack://application:,,,/res/maestro.png"));
            }
        }

        private void to_card1_Click(object sender, RoutedEventArgs e)
        {
            res_card.Text = "///////////////////////////  " + Convert.ToString(cvv.Text);
            system_code_Copy.Text = Convert.ToString(system_code.Text);
            bank_code_Copy.Text = Convert.ToString(bank_code.Text);
            bill_number_Copy.Text = Convert.ToString(bill_number.Text);
            check_number_Copy.Text = Convert.ToString(check_number.Text);
            card_period_start.Text = Convert.ToString(card_start.SelectedDate.Value.Month) + "/" + Convert.ToString(card_start.SelectedDate.Value.Year);
            card_period_end.Text = Convert.ToString(card_end.SelectedDate.Value.Month) + "/" + Convert.ToString(card_end.SelectedDate.Value.Year);
            card_fio.Text = Convert.ToString(fio.Text);
        }

        private void dogovor1_Click(object sender, RoutedEventArgs e)
        {
             PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                //use either one of the below      
                pd.PrintVisual(dogovor as Visual, "printing as visual");
            }
        }

        private void usloviya1_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                //use either one of the below      
                pd.PrintVisual(usloviya as Visual, "printing as visual");
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if(search.Text == "")
            {
                dgv.ItemsSource = new observe<credit>(db.credit.ToList()).List.ToBindingList();
            }
            else
            {
                dgv.ItemsSource = null;
                if (db.credit.Any(x => x.customer.fio == search.Text))
                    dgv.ItemsSource = db.credit.Where(x => x.customer.fio == search.Text).ToList();
            }
            
        }

        private void remainer_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(sum_credit.Text != "")
            {
                rem.remainer(sum_credit, percent, remainer);
            }
        }

    }
}
