using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Exort.Wpf.FluentDesign.Utils;
using static System.Windows.Media.ColorConverter;
// ReSharper disable PossibleNullReferenceException

namespace Exort.Wpf.FluentDesign.Resources
{
    public class AccentColors : ThemeHandler
    {
        private const int WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320;

        private static Color immersiveSystemAccent;
        private static Color immersiveSystemAccentDark1;
        private static Color immersiveSystemAccentDark2;
        private static Color immersiveSystemAccentDark3;
        private static Color immersiveSystemAccentLight1;
        private static Color immersiveSystemAccentLight2;
        private static Color immersiveSystemAccentLight3;
        private static Brush immersiveSystemAccentBrush;
        private static Brush immersiveSystemAccentDark1Brush;
        private static Brush immersiveSystemAccentDark2Brush;
        private static Brush immersiveSystemAccentDark3Brush;
        private static Brush immersiveSystemAccentLight1Brush;
        private static Brush immersiveSystemAccentLight2Brush;
        private static Brush immersiveSystemAccentLight3Brush;

        public static Color ImmersiveSystemAccent
        {
            get => immersiveSystemAccent;
            private set
            {
                if (Equals(immersiveSystemAccent, value)) return;
                immersiveSystemAccent = value; OnStaticPropertyChanged();
            }
        }

        public static Color ImmersiveSystemAccentDark1
        {
            get => immersiveSystemAccentDark1;
            private set
            {
                if (Equals(immersiveSystemAccentDark1, value)) return;
                immersiveSystemAccentDark1 = value; OnStaticPropertyChanged();
            }
        }

        public static Color ImmersiveSystemAccentDark2
        {
            get => immersiveSystemAccentDark2;
            private set
            {
                if (Equals(immersiveSystemAccentDark2, value)) return;
                immersiveSystemAccentDark2 = value; OnStaticPropertyChanged();
            }
        }

        public static Color ImmersiveSystemAccentDark3
        {
            get => immersiveSystemAccentDark3;
            private set
            {
                if (Equals(immersiveSystemAccentDark3, value)) return;
                immersiveSystemAccentDark3 = value; OnStaticPropertyChanged();
            }
        }

        public static Color ImmersiveSystemAccentLight1
        {
            get => immersiveSystemAccentLight1;
            private set
            {
                if (Equals(immersiveSystemAccentLight1, value)) return;
                immersiveSystemAccentLight1 = value; OnStaticPropertyChanged();
            }
        }

        public static Color ImmersiveSystemAccentLight2
        {
            get => immersiveSystemAccentLight2;
            private set
            {
                if (Equals(immersiveSystemAccentLight2, value)) return;
                immersiveSystemAccentLight2 = value; OnStaticPropertyChanged();
            }
        }

        public static Color ImmersiveSystemAccentLight3
        {
            get => immersiveSystemAccentLight3;
            private set
            {
                if (Equals(immersiveSystemAccentLight3, value)) return;
                immersiveSystemAccentLight3 = value; OnStaticPropertyChanged();
            }
        }

        public static Brush ImmersiveSystemAccentBrush
        {
            get => immersiveSystemAccentBrush;
            private set
            {
                if (Equals(immersiveSystemAccentBrush, value)) return;
                immersiveSystemAccentBrush = value; OnStaticPropertyChanged();
            }
        }

        public static Brush ImmersiveSystemAccentDark1Brush
        {
            get => immersiveSystemAccentDark1Brush;
            private set
            {
                if (Equals(immersiveSystemAccentDark1Brush, value)) return;
                immersiveSystemAccentDark1Brush = value; OnStaticPropertyChanged();
            }
        }
        public static Brush ImmersiveSystemAccentDark2Brush
        {
            get => immersiveSystemAccentDark2Brush;
            private set
            {
                if (Equals(immersiveSystemAccentDark2Brush, value)) return;
                immersiveSystemAccentDark2Brush = value; OnStaticPropertyChanged();
            }
        }
        public static Brush ImmersiveSystemAccentDark3Brush
        {
            get => immersiveSystemAccentDark3Brush;
            private set
            {
                if (Equals(immersiveSystemAccentDark3Brush, value)) return;
                immersiveSystemAccentDark3Brush = value; OnStaticPropertyChanged();
            }
        }

        public static Brush ImmersiveSystemAccentLight1Brush
        {
            get => immersiveSystemAccentLight1Brush;
            private set
            {
                if (Equals(immersiveSystemAccentLight1Brush, value)) return;
                immersiveSystemAccentLight1Brush = value; OnStaticPropertyChanged();
            }
        }
        public static Brush ImmersiveSystemAccentLight2Brush
        {
            get => immersiveSystemAccentLight2Brush;
            private set
            {
                if (Equals(immersiveSystemAccentLight2Brush, value)) return;
                immersiveSystemAccentLight2Brush = value; OnStaticPropertyChanged();
            }
        }
        public static Brush ImmersiveSystemAccentLight3Brush
        {
            get => immersiveSystemAccentLight3Brush;
            private set
            {
                if (Equals(immersiveSystemAccentLight3Brush, value)) return;
                immersiveSystemAccentLight3Brush = value; OnStaticPropertyChanged();
            }
        }

        static AccentColors()
        {
            Instance = new AccentColors();
            Initialize();
        }

        protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_DWMCOLORIZATIONCOLORCHANGED)
            {
                Initialize();
            }

            return IntPtr.Zero;
        }

        public static Color GetColorByTypeName(string name)
        {
            var colorSet = UxThemeWrapper.GetImmersiveUserColorSetPreference(false, false);
            var colorType = UxThemeWrapper.GetImmersiveColorTypeFromName(name);
            var rawColor = UxThemeWrapper.GetImmersiveColorFromColorSetEx(colorSet, colorType, false, 0);

            var bytes = BitConverter.GetBytes(rawColor);
            return Color.FromArgb(bytes[3], bytes[0], bytes[1], bytes[2]);
        }

        internal static void Initialize()
        {
            if (!SystemInfo.IsWin7())
            {
                ImmersiveSystemAccent = GetColorByTypeName("ImmersiveSystemAccent");
                ImmersiveSystemAccentDark1 = GetColorByTypeName("ImmersiveSystemAccentDark1");
                ImmersiveSystemAccentDark2 = GetColorByTypeName("ImmersiveSystemAccentDark2");
                ImmersiveSystemAccentDark3 = GetColorByTypeName("ImmersiveSystemAccentDark3");
                ImmersiveSystemAccentLight1 = GetColorByTypeName("ImmersiveSystemAccentLight1");
                ImmersiveSystemAccentLight2 = GetColorByTypeName("ImmersiveSystemAccentLight2");
                ImmersiveSystemAccentLight3 = GetColorByTypeName("ImmersiveSystemAccentLight3");
            }
            else
            {
                ImmersiveSystemAccent = (Color)ConvertFromString("#FF2990CC");
                ImmersiveSystemAccentDark1 = (Color)ConvertFromString("#FF2481B6");
                ImmersiveSystemAccentDark2 = (Color)ConvertFromString("#FF2071A1");
                ImmersiveSystemAccentDark3 = (Color)ConvertFromString("#FF205B7E");
                ImmersiveSystemAccentLight1 = (Color)ConvertFromString("#FF2D9FE1");
                ImmersiveSystemAccentLight2 = (Color)ConvertFromString("#FF51A5D6");
                ImmersiveSystemAccentLight3 = (Color)ConvertFromString("#FF7BB1D0");
            }

            ImmersiveSystemAccentBrush = CreateBrush(ImmersiveSystemAccent);
            ImmersiveSystemAccentDark1Brush = CreateBrush(ImmersiveSystemAccentDark1);
            ImmersiveSystemAccentDark2Brush = CreateBrush(ImmersiveSystemAccentDark2);
            ImmersiveSystemAccentDark3Brush = CreateBrush(ImmersiveSystemAccentDark3);
            ImmersiveSystemAccentLight1Brush = CreateBrush(ImmersiveSystemAccentLight1);
            ImmersiveSystemAccentLight2Brush = CreateBrush(ImmersiveSystemAccentLight2);
            ImmersiveSystemAccentLight3Brush = CreateBrush(ImmersiveSystemAccentLight3);
        }

        internal static Brush CreateBrush(Color color)
        {
            var brush = new SolidColorBrush(color);
            brush.Freeze();
            return brush;
        }
        
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        protected static void OnStaticPropertyChanged([CallerMemberName]string propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}