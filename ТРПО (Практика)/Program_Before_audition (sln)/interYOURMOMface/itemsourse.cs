using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace interYOURMOMface
{
    public class itemsourse
    {
        public static void dgv (Model1Container db, DataGrid dgv)
        {
            dgv.ItemsSource = new observe<credit>(db.credit.ToList()).List.ToBindingList();
        }       
    }
}
