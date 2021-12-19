﻿using System.Linq;
using System.Windows;

namespace clothing_repair
{
    /// <summary>
    /// Логика взаимодействия для category_reg.xaml
    /// </summary>
    public partial class category_reg : Window
    {
        clothing_repairEntities1 db = new clothing_repairEntities1();

        public category_reg()
        {
            InitializeComponent();
            itemsource.cats_source(db, cat_dgv);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.categories.Add(new categories
            {
                category = category_name_field.Text
            });
           
            db.SaveChanges();
            itemsource.cats_source(db, cat_dgv);
        }
    }
}
