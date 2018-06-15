using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Exort.Wpf.FluentDesign.Resources
{
    public class ThemeDictionary : ResourceDictionary, INotifyPropertyChanged
    {
        private string themeName;

        public string ThemeName {
            get => themeName;
            set { themeName = value; OnPropertyChanged(); }
        }
        
        public new Uri Source {
            get => base.Source;
            set { base.Source = value; OnPropertyChanged(); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}