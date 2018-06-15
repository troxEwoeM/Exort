using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Exort.Wpf.FluentDesign.Resources
{
    public class SystemTheme : ThemeHandler
    {
        private const int WM_WININICHANGE = 0x001A;
        private static ApplicationTheme theme;

        public static ApplicationTheme Theme
        {
            get => theme;
            private set
            {
                if (Equals(theme, value)) return;
                theme = value; OnStaticPropertyChanged();
            }
        }
        static SystemTheme()
        {
            Instance = new SystemTheme();
            Theme = GetTheme();
        }

        protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg != WM_WININICHANGE) return IntPtr.Zero;

            var systemParmeter = Marshal.PtrToStringAuto(lParam);
            if (systemParmeter != "ImmersiveColorSet") return IntPtr.Zero;

            Theme = GetTheme();
            ThemeChanged?.Invoke(null, null);
            handled = true;

            return IntPtr.Zero;
        }

        private static ApplicationTheme GetTheme()
        {
            return ApplicationTheme.Dark;
        }
        
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        protected static void OnStaticPropertyChanged([CallerMemberName]string propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        
        public static event EventHandler ThemeChanged;
    }
}
