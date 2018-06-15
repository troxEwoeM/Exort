using System;
using System.Windows;
using System.Windows.Interop;

namespace Exort.Wpf.FluentDesign.Resources
{
    public abstract class ThemeHandler
    {
        protected static ThemeHandler Instance { get; set; }

        protected ThemeHandler()
        {
            var win = Application.Current.MainWindow;
            if (win != null)
            {
                Initialize(win);
            }
            else
            {
                void EventHandler(object e, EventArgs args)
                {
                    Initialize(Application.Current.MainWindow);
                    Application.Current.Activated -= EventHandler;
                }

                Application.Current.Activated += EventHandler;
            }
        }

        private void Initialize(Window win)
        {
            if (win.IsLoaded)
            {
                InitializeCore(win);
            }
            else
            {
                win.Loaded += (_, __) =>
                {
                    InitializeCore(win);
                };
            }
        }

        protected virtual void InitializeCore(Window win)
        {
            var source = HwndSource.FromHwnd(new WindowInteropHelper(win).Handle);
            source?.AddHook(WndProc);
        }

        protected abstract IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled);
    }
}
