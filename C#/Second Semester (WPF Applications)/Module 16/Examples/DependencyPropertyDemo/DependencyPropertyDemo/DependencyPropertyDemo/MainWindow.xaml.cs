using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DependencyPropertyDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Объявление DependencyProperty (по соглашению на конце дополнительно - Property)
        public static readonly DependencyProperty MyPropProperty;
        // Обертка - обычноe свойствo .NET
        // Не вставляйте доп. логику в обертку, поскольку WPF вызывает GetValue/SetValue напрямую
        public string MyProp
        {
            get { return (string)GetValue(MyPropProperty); }
            set { SetValue(MyPropProperty, value); }
        }

        static MainWindow() // Статический конструктор
        {
            // Регистрация свойства
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata("Начальное значение");
            // Пример свойсв метаданных
            metadata.BindsTwoWayByDefault = true;
            metadata.Inherits = false;
            metadata.AffectsRender = true;
            metadata.AffectsMeasure = false;
            MyPropProperty = DependencyProperty.Register("MyProp", typeof(string), typeof(MainWindow), metadata);
        }

        public MainWindow()
        {
            InitializeComponent();
            MyProp = "Примерчик свойства";
        }

    }
}
