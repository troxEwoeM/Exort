using System;
using System.Linq;
using System.Windows;

namespace Exort.Wpf.FluentDesign.Resources
{
    public class ResourceDictionaryEx : ResourceDictionary
    {
        private ElementTheme? requestedTheme;

        public ElementTheme? RequestedTheme {
            get => requestedTheme;
            set { requestedTheme = value; ChangeTheme(); }
        }
        public ThemeCollection ThemeDictionaries { get; set; } = new ThemeCollection();

        public ResourceDictionaryEx()
        {
            SystemTheme.ThemeChanged += SystemTheme_ThemeChanged;
            ThemeDictionaries.CollectionChanged += ThemeDictionaries_CollectionChanged;
            GlobalThemeChanged += ResourceDictionaryEx_GlobalThemeChanged;
        }

        private void SystemTheme_ThemeChanged(object sender, EventArgs e)
        {
            ChangeTheme();
        }

        private void ThemeDictionaries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ChangeTheme();
        }

        private void ResourceDictionaryEx_GlobalThemeChanged(object sender, EventArgs e)
        {
            ChangeTheme();
        }


        private void ChangeTheme()
        {
            var theme = RequestedTheme ?? GlobalTheme;
            switch (theme)
            {
                case ElementTheme.Light:
                    ChangeTheme(ApplicationTheme.Light.ToString());
                    break;
                case ElementTheme.Dark:
                    ChangeTheme(ApplicationTheme.Dark.ToString());
                    break;
                default:
                    ChangeTheme(SystemTheme.Theme.ToString());
                    break;
            }
        }

        private void ChangeTheme(string themeName)
        {
            MergedDictionaries.Clear();
            // ReSharper disable once RedundantEnumerableCastCall
            var theme = ThemeDictionaries.OfType<ThemeDictionary>()
                                              .FirstOrDefault(o => o.ThemeName == themeName);
            if (theme != null)
            {
                MergedDictionaries.Add(theme);
            }
        }
        
        private static ElementTheme? globalTheme;
        public static ElementTheme? GlobalTheme {
            get => globalTheme;
            set { globalTheme = value; GlobalThemeChanged?.Invoke(null, null); }
        }

        public static event EventHandler<EventArgs> GlobalThemeChanged;
    }
}
