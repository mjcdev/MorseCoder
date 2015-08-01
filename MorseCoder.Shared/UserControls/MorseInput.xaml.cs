using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MorseCoder.UserControls
{
    public sealed partial class MorseInput : UserControl
    {
        public MorseInput()
        {
            this.InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
        }
      
        public ICommand DotCommand
        {
            get { return (ICommand)GetValue(DotCommandProperty); }
            set { SetValueDp(DotCommandProperty, value); }
        }

        public ICommand DashCommand
        {
            get { return (ICommand)GetValue(DashCommandProperty); }
            set { SetValueDp(DashCommandProperty, value); }
        }

        public ICommand SpaceCommand
        {
            get { return (ICommand)GetValue(SpaceCommandProperty); }
            set { SetValueDp(DashCommandProperty, value); }
        }

        public static readonly DependencyProperty DotCommandProperty = DependencyProperty.Register("DotCommand", typeof(ICommand), typeof(MorseInput), null);
        public static readonly DependencyProperty DashCommandProperty = DependencyProperty.Register("DashCommand", typeof(ICommand), typeof(MorseInput), null);
        public static readonly DependencyProperty SpaceCommandProperty = DependencyProperty.Register("SpaceCommand", typeof(ICommand), typeof(MorseInput), null);

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetValueDp(DependencyProperty property, object value, [CallerMemberName] string propertyName = null)
        {
            SetValue(property, value);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
