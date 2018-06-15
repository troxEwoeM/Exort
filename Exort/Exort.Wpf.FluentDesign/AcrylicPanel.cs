using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Exort.Wpf.FluentDesign
{
    public class AcrylicPanel : ContentControl
    {
        private bool _isChanged;

        public FrameworkElement Target {
            get => (FrameworkElement)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        public FrameworkElement Source
        {
            get => (FrameworkElement)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        public double TintOpacity
        {
            get => (double)GetValue(TintOpacityProperty);
            set => SetValue(TintOpacityProperty, value);
        }

        public double NoiseOpacity
        {
            get => (double)GetValue(NoiseOpacityProperty);
            set => SetValue(NoiseOpacityProperty, value);
        }

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(AcrylicPanel), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(FrameworkElement), typeof(AcrylicPanel), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty TintColorProperty =
            DependencyProperty.Register("TintColor", typeof(Color), typeof(AcrylicPanel), 
                new PropertyMetadata(Colors.White));

        public static readonly DependencyProperty TintOpacityProperty =
            DependencyProperty.Register("TintOpacity", typeof(double), typeof(AcrylicPanel), 
                new PropertyMetadata(0.0));

        public static readonly DependencyProperty NoiseOpacityProperty =
            DependencyProperty.Register("NoiseOpacity", typeof(double), typeof(AcrylicPanel), 
                new PropertyMetadata(0.03));
        
        static AcrylicPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AcrylicPanel), new FrameworkPropertyMetadata(typeof(AcrylicPanel)));
        }
        
        public AcrylicPanel()
        {
            Source = this;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("rect") is Rectangle rect)
            {
                rect.LayoutUpdated += (_, __) =>
                {
                    if (_isChanged) return;

                    _isChanged = true;
                    BindingOperations.GetBindingExpressionBase(rect, RenderTransformProperty)?.UpdateTarget();

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        _isChanged = false;
                    }), System.Windows.Threading.DispatcherPriority.DataBind);
                };
            }
        }
    }
}