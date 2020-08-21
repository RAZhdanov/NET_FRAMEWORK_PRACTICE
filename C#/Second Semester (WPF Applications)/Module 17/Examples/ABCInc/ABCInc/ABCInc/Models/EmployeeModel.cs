using ABCInc.DAL;

namespace ABCInc.Models
{
    public class EmployeeModel
    {
        private readonly IEmployeeProvider _employeeProvider;
        private const string DefaultDataFilePath = "ABC Inc.xml";

        public EmployeeModel(IEmployeeProvider employeeProvider)
        {
            _employeeProvider = employeeProvider;
        }

        public Employee[] Employees { get; set; }
        public void LoadEmployees()
        {
            LoadEmployees(DefaultDataFilePath);
        }

        public void LoadEmployees(string path)
        {
            Employees = _employeeProvider.LoadEmployees(path);
        }

        public void Save()
        {
            _employeeProvider.SaveEmployees(DefaultDataFilePath, Employees);
        }

        public void Save(string path)
        {
            _employeeProvider.SaveEmployees(path, Employees);
        }
    }
}
