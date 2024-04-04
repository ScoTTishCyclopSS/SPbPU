using System;
using System.Windows.Controls;

namespace loans_bank
{
    public class rem
    {
        public static void remainer(TextBox tb1, ComboBox cmb, TextBox tb2)
        {
            var rem = Convert.ToInt32(tb1.Text) / 100 * Convert.ToInt32(cmb.Text) + Convert.ToInt32(tb1.Text);
            tb2.Text = Convert.ToString(rem);
        }
    }
}