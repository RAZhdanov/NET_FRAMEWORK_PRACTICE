namespace ABCInc.DAL
{
    public interface IEmployeeProvider
    {
        Employee[] LoadEmployees(string path);
        void SaveEmployees(string path, Employee[] employees);
    }
}