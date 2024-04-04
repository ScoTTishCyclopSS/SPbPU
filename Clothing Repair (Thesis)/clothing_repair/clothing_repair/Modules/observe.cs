using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace clothing_repair
{
    internal class observe<T> : INotifyPropertyChanged
    {
        public observe()
        {
            List = new ObservableCollection<T>();
        }

        public observe(List<T> list)
            : this()
        {
            list.ForEach(x => List.Add(x));
        }

        public ObservableCollection<T> List { get; set; }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => ((INotifyPropertyChanged)List).PropertyChanged += value;
            remove => ((INotifyPropertyChanged)List).PropertyChanged -= value;
        }
    }
}