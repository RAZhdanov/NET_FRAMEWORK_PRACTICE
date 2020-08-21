using System;
using System.Text;
using System.Windows;
using System.Windows.Input;

// Программа демонстрации событий в WPF
// В XAML очень много подписчиков на события. Они могут затруднить понимание работы событий
// Комментируйте (или удаляйте) лишние подписки на события для лучшего анализа и понимания событий в WPF


namespace Events
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lb.Items.Clear();
        }

        private void SomeOne_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sender: " + sender);
            sb.AppendLine("Source: " + e.Source);
            sb.AppendLine("OriginalSource: " + e.OriginalSource);
            sb.AppendLine("RoutedEvent: " + e.RoutedEvent);
            lb.Items.Add(sb.ToString());
            e.Handled = cb.IsChecked.Value;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Кликнули на какой-то кнопочке внути StackPanel. Обработали событие на уровне StackPanel, у которой нет события Click");
            sb.AppendLine("Sender: " + sender);
            sb.AppendLine("Source: " + e.Source);
            sb.AppendLine("OriginalSource: " + e.OriginalSource);
            sb.AppendLine("RoutedEvent: " + e.RoutedEvent);
            MessageBox.Show(sb.ToString());
        }
    }
}
