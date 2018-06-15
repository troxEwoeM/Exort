using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Exort.Wpf.FluentDesign.Resources
{
    public sealed class ThemeCollection : ObservableCollection<ThemeDictionary>
    {
        private readonly IList<ThemeDictionary> _previousList;

        public ThemeCollection()
        {
            _previousList = new List<ThemeDictionary>();
            CollectionChanged += ThemeCollection_CollectionChanged;
        }

        private void ThemeCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                foreach (var item in _previousList)
                    item.PropertyChanged -= Item_PropertyChanged;
                _previousList.Clear();
            }

            if (e.OldItems != null)
            {
                foreach (ThemeDictionary item in e.OldItems)
                {
                    _previousList.Remove(item);
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }

            if (e.NewItems != null)
            {
                foreach (ThemeDictionary item in e.NewItems)
                {
                    _previousList.Add(item);
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var args = new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset);
            OnCollectionChanged(args);
        }
    }
}