using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Catalog
{
    class VeiwModelM : INotifyPropertyChanged
    {
        string name = string.Empty;
        public string Name 
        {
            get => name;
            set
            {
                if (name == value)
                { return; }

                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName => $"Name Entered: {Name}";



        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
