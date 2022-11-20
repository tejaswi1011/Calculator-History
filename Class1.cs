using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class HistoryExpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<String> his;
        private string _sample;

        public HistoryExpViewModel()
        {
            his = new ObservableCollection<String>();
        }

        public ObservableCollection<String> historyOut
        {
            get => his;
        }

        public void saveToHistory(String item)
        {
            his.Add(item);
            OnPropertyChanged("his");
            OnPropertyChanged();
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
