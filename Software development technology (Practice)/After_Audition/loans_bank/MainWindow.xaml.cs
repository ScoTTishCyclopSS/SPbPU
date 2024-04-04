using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace loans_bank
{
    public partial class MainWindow : Window
    {
        private readonly creditbdContainer db;
        private DateTime passDate, birthDate, creditStart, creditEnd, cardStart, cardEnd;
        private string sex;

        public MainWindow()
        {
            InitializeComponent();
            db = new creditbdContainer();
            
            percent.Items.Add("8");
            percent.Items.Add("10");
            percent.Items.Add("12");
            
            currency.Items.Add("RUB");
            currency.Items.Add("DOLLAR");
            currency.Items.Add("EURO");

            family_status.Items.Add("в браке");
            family_status.Items.Add("не в браке");
            
            education.Items.Add("полное среднее");
            education.Items.Add("среднее специальное");
            education.Items.Add("полное специальное");
            
            card_type.Items.Add("VISA");
            card_type.Items.Add("MASTERCARD");
            card_type.Items.Add("MAESTRO");

            dgv.ItemsSource = new observe<credit>(db.credit.ToList()).List.ToBindingList();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            var r = (credit)dgv.SelectedItem;
            var s = decimal.Parse(r.remainer);
            r.remainer = (s - decimal.Parse(month_check.Text)).ToString();

            db.SaveChanges();
            dgv.ItemsSource = new observe<credit>(db.credit.ToList()).List.ToBindingList();
        }

        private void insert_month_Click(object sender, RoutedEventArgs e)
        {
            var mon = Convert.ToInt32(month_check.Text);
            var some = Convert.ToInt32(some_month.Text);
            var r = (credit)dgv.SelectedItem;
            var s = decimal.Parse(r.remainer);
            r.remainer = (s - mon * some).ToString();

            db.SaveChanges();
        }

        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var r = (credit)dgv.SelectedItem;
            if (r != null) month_check.Text = r.month_sum;
        }

        private void res_month_insert_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var sum = Convert.ToInt32(sum_credit.Text);
            var month = Convert.ToInt32(sum_month.Text);
            var res = sum / month;
            res_month_incert.Text = res.ToString();
        }

        private void random_check_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var mon = Convert.ToInt32(month_check.Text);
            var some = Convert.ToInt32(some_month.Text);
            random_check.Text = (mon * some).ToString();
        }

        private void fio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsLetter(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void passport_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            passport_number.MaxLength = 12;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void tel_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            tel_number.MaxLength = 11;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void education_place_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void work_place_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            work_place_number.MaxLength = 11;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void month_income_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void sum_credit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void sum_month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            sum_month.MaxLength = 2;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void some_month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            some_month.MaxLength = 2;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void check_word_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsLetter(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void system_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            system_code.MaxLength = 1;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void bank_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bank_code.MaxLength = 5;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void bill_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bill_number.MaxLength = 9;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void check_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            check_number.MaxLength = 1;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void cvv_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            cvv.MaxLength = 1;
            if (char.IsDigit(e.Text, 0)) e.Handled = false;
            else e.Handled = true;
        }

        private void to_card_Click(object sender, RoutedEventArgs e)
        {
            var res_to_card = MessageBox.Show("Принять заявку и перейти к регистрации К/К?", "Подтвердить?",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            
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
            var reset = MessageBox.Show("Отменить регистрацию клиента и вернуться на главную страницу?", "Отмена",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            
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
            if (male.IsChecked == true)
            {
                sex = "male";
            }
            else if (female.IsChecked == true)
            {
                sex = "female";
            }

            passDate = passport_date.SelectedDate.Value.Date;
            birthDate = birthdate.SelectedDate.Value.Date;
            creditStart = start.SelectedDate.Value.Date;
            creditEnd = end.SelectedDate.Value.Date;
            cardStart = card_start.SelectedDate.Value.Date;
            cardEnd = card_end.SelectedDate.Value.Date;
            
            var new_credit = new credit
            {
                percent_set = percent.Text,
                currency = currency.Text,
                credit_start = creditStart,
                credit_end = creditEnd,
                sum = sum_credit
                    .Text,
                remainer = sum_credit.Text,
                month_sum = res_month_incert.Text,
                months = sum_month.Text
            };
            
            var new_customer = new customer
            {
                fio = fio.Text,
                passport_number = passport_number.Text,
                passport_date = passDate,
                passport_info = passport_info.Text,
                sex = sex,
                family_status = family_status.Text,
                birthdate = birthDate,
                tel_number = tel_number.Text,
                email = email.Text,
                education = education.Text,
                education_place_code = education_place_code.Text,
                live_place = live_place.Text,
                work_place = work_place.Text,
                work_tel_number = work_place_number.Text,
                work_post = work_post.Text,
                month_income = month_income.Text,
                credit_reason = credit_reason.Text
            };
            
            var new_card = new card
            {
                IL = IL.Text,
                card_type = card_type.Text,
                system_code = system_code.Text,
                bank_code = bank_code.Text,
                bill_number = bill_number.Text,
                check_number = check_number.Text,
                cvv = cvv.Text,
                card_start = cardStart,
                card_end = cardEnd,
                check_word = check_word.Text
            };
            
            db.credit.Add(new_credit);
            db.customer.Add(new_customer);
            db.card.Add(new_card);

            new_credit.customer = new_customer;
            new_credit.card = new_card;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationError in ex.EntityValidationErrors)
                {
                    Console.Write("Object: " + validationError.Entry.Entity);
                    Console.Write("");
                    foreach (var err in validationError.ValidationErrors) Console.Write(err.ErrorMessage + "");
                }
            }

            main_reg.IsEnabled = true;
            rem_reg.IsEnabled = true;
            main_tabcon.SelectedItem = main_reg;
        }
    }
}