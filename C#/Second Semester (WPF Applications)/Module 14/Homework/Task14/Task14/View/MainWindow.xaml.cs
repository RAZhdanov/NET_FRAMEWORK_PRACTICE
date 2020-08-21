using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.ModelView;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Shutdown(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WordWrapFunction(object sender, RoutedEventArgs e)
        {
            if(textBoxArea.TextWrapping == TextWrapping.NoWrap)
            {
                textBoxArea.TextWrapping = TextWrapping.WrapWithOverflow;
            }
            else
            {
                textBoxArea.TextWrapping = TextWrapping.NoWrap;
            }
        }

        private void SpellCheckerFunction(object sender, RoutedEventArgs e)
        {
            textBoxArea.SpellCheck.IsEnabled = !textBoxArea.SpellCheck.IsEnabled;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if(!((ViewModel)DataContext).CanDocumentBeClosed())
            {
                e.Cancel = true;
            }
        }
    }
}
