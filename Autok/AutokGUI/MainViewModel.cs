using AutokLogic;
using AutokData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokGUI
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Autok> Cars { get; } = new();
        public event PropertyChangedEventHandler? PropertyChanged;
        Logic logic = Logic.CreateFromCSV();
        public MainViewModel()
        {
            foreach (var szakterulet in logic.Autok)
            {
                Cars.Add(szakterulet);
            }
        }
    }
}
