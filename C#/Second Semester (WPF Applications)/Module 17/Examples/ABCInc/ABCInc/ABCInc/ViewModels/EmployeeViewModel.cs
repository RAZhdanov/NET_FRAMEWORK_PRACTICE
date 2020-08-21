using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using ABCInc.Common;
using ABCInc.DAL;
using ABCInc.Models;

namespace ABCInc.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly EmployeeModel _employeeModel;
        private ObservableCollection<Employee> _employees;
        private Employee _selectedEmployee;

        public EmployeeViewModel(EmployeeModel employeeModel)
        {
            _employeeModel = employeeModel;
            // Load();

            LoadCommand = new RelayCommand(_ => Load());
            SaveCommand = new RelayCommand(_ => Save(), _ => CanSave());
            AddCommand = new RelayCommand(_ => Add(), _ => Employees != null);
            DeleteCommand = new RelayCommand(emp => Delete(emp as Employee), emp => emp is Employee);
            ExitCommand = new RelayCommand(_ => Application.Current.Shutdown());
        }

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            private set
            {
                _employees = value;
                RaisePropertyChanged();
            }
        }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                if (value != _selectedEmployee)
                {
                    _selectedEmployee = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<Gender> AllGenders { get; } = new ObservableCollection<Gender>(Enum.GetValues(typeof(Gender)).Cast<Gender>());

        public RelayCommand LoadCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand AddCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand ExitCommand { get; }

        public void Load()
        {
            _employeeModel.LoadEmployees();
            Employees = new ObservableCollection<Employee>(_employeeModel.Employees);
        }

        public void Save()
        {
            _employeeModel.Employees = Employees.ToArray();
            _employeeModel.Save();
        }

        public bool CanSave()
        {
            return Employees != null && Employees.Count > 0;
        }

        public void Add()
        {
            Employee emp = new Employee
            {
                Family = "Enter Family",
                Name = "Enter Name",
                Address = "Enter address",
                BirthDay = new DateTime(2000, 1, 1),
                Sex = Gender.Male
            };
            Employees.Add(emp);
            SelectedEmployee = emp;
        }
        private void Delete(Employee employee)
        {
            if (employee == null) return;
            Employees.Remove(employee);
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
