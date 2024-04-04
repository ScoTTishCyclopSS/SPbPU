using System;
using System.Windows;
using System.Windows.Controls;

namespace loans_bank
{
    public class date
    {
        public static void date_rem(DatePicker end_pick, DatePicker start_pick, TextBox sum, DatePicker card_st,
            DatePicker card_ed)
        {
            var res_month = (end_pick.SelectedDate.Value.Year - start_pick.SelectedDate.Value.Year) * 12 +
                end_pick.SelectedDate.Value.Month - start_pick.SelectedDate.Value.Month;
            if (res_month == 1 || res_month == 0)
            {
                MessageBox.Show("Loans minimum of 2 months!!!");
            }
            else
            {
                sum.Text = Convert.ToString(res_month);
                card_st.SelectedDate = start_pick.SelectedDate.Value.Date;
                card_ed.SelectedDate = end_pick.SelectedDate.Value.Date;
            }
        }
    }
}