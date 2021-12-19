using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace clothing_repair
{
    /// <summary>
    /// Логика взаимодействия для order_statistic.xaml
    /// </summary>
    public partial class order_statistic : Window
    {
        clothing_repairEntities1 db = new clothing_repairEntities1();

        public order_statistic()
        {
            InitializeComponent();

            var data = db.categories;
            ColumnSeries c = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = point => point.Y.ToString()
            };
            Axis ax = new Axis()
            {
                Separator = new LiveCharts.Wpf.Separator()
                {
                    Step = 1,
                    IsEnabled = false
                }
            };
            ax.Labels = new List<string>();
            foreach(var x in data)
            {
                c.Values.Add(x.order.Count());
                ax.Labels.Add(x.category);

                tb.Text = db.order.Max(y => y.categories.category);
            }
            pie.Series.Add(c);
            pie.AxisX.Add(ax);
           pie.AxisY.Add(
                new Axis
                {
                    LabelFormatter = value => value.ToString(),
                    Separator = new LiveCharts.Wpf.Separator()
                });
        }
        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            pie.Update(true);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
