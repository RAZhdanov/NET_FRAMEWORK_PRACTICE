using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module17.DAL
{
    public class Book : INotifyPropertyChanged
    {
        /// <summary>
        /// Attributes
        /// </summary>
        private string m_title; //Название книги
        private Author[] m_authors; //Авторы
        private int m_year_of_production;

        /// <summary>
        ///  Properties
        /// </summary>
        public string Title
        {
            get { return m_title; }
            set
            {
                if (m_title != value)
                {
                    m_title = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Author[] Authors
        {
            get { return m_authors; }
            set
            {
                if (m_authors != value)
                {
                    m_authors = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Year_of_production
        {
            get { return m_year_of_production; }
            set
            {
                if (m_year_of_production != value)
                {
                    m_year_of_production = value;
                    RaisePropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
