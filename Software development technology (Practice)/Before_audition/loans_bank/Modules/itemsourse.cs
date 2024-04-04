using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace loans_bank
{
    public class itemsourse
    {
        public static void dgv(Model1Container db, DataGrid dgv)
        {
            dgv.ItemsSource = new observe<credit>(db.credit.ToList()).List.ToBindingList();
        }
    }
}