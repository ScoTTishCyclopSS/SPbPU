using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace interYOURMOMface
{
    public class rem
    {
        public static void remainer (TextBox tb1, ComboBox cmb, TextBox tb2)
        {
            int rem = ((Convert.ToInt32(tb1.Text) / 100) * Convert.ToInt32(cmb.Text)) + Convert.ToInt32(tb1.Text);
            tb2.Text = Convert.ToString(rem);
        }
    }
}
