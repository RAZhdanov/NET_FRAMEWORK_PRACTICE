using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ABCInc.DAL
{
    public class Employee : INotifyPropertyChanged
    {
        private string _family;
        private DateTime _birthDay;
        private Gender _sex;
        private string _name;
        private string _patronymic;
        private string _address;

        public Employee()
        {

        }

        public Employee(string family, string name, string patronymic, Gender sex, string address, DateTime birthDay)
        {
            Family = family;
            Name = name;
            Patronymic = patronymic;
            Sex = sex;
            Address = address;
            BirthDay = birthDay;
        }

        public string Family
        {
            get { return _family; }
            set
            {
                if (_family != value)
                {
                    _family = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                if (value != _patronymic)
                {
                    _patronymic = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Gender Sex
        {
            get { return _sex; }
            set
            {
                if (value != _sex)
                {
                    _sex = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime BirthDay
        {
            get { return _birthDay; }
            set
            {
                if (value != _birthDay)
                {
                    _birthDay = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Age));
                }
            }
        }

        public int Age
        {
            get { return new DateTime((DateTime.Today - BirthDay).Ticks).Year - 1; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
