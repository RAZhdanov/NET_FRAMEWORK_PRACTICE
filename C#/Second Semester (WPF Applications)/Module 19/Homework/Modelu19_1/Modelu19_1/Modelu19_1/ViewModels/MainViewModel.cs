using Modelu19_1.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Modelu19_1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public RelayCommand<object> LoadCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private Color foregroundColor = Colors.Black;
        private Color backgroundColor = Colors.White;

        public Color ForegroundColor
        {
            get
            {
                return foregroundColor;
            }
            set
            {
                foregroundColor = value;
                RaisePropertyChanged();
            }
        }


        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
