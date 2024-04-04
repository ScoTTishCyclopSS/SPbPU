using System.Linq;
using System.Windows.Controls;

namespace clothing_repair
{
    internal class itemsource
    {
        public static void order_source(clothing_repairEntities1 db, DataGrid dgv)
        {
            dgv.Items.Clear();
            db.order.ToList().ForEach(x => dgv.Items.Add(x));
        }

        public static void cats_source(clothing_repairEntities1 db, DataGrid dgv)
        {
            dgv.Items.Clear();
            db.categories.ToList().ForEach(x => dgv.Items.Add(x));
        }

        public static void cus_source(clothing_repairEntities1 db, DataGrid dgv)
        {
            dgv.Items.Clear();
            db.customer.ToList().ForEach(x => dgv.Items.Add(x));
        }

        public static void user_source(clothing_repairEntities1 db, DataGrid dgv)
        {
            dgv.Items.Clear();
            db.user.ToList().ForEach(x => dgv.Items.Add(x));
        }
    }
}