using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module17.DAL
{
    public class Author : INotifyPropertyChanged
    {
        private string m_name;

        public Author()
        {
            m_name = "";
        }

        public Author(string _name)
        {
            this.m_name = _name;
        }
        public string AuthorName
        {
            get { return m_name; }
            set
            {
                m_name = value;
                RaisePropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
