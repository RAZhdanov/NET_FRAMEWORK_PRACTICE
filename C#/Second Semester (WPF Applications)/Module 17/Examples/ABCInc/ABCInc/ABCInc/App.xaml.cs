using System.Windows;
using ABCInc.DAL;
using ABCInc.Models;
using ABCInc.ViewModels;
using ABCInc.Views;

namespace ABCInc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IEmployeeProvider provider = new EmployeeProvider();
            EmployeeModel model = new EmployeeModel(provider);
            EmployeeViewModel vewModel = new EmployeeViewModel(model);
            EmployeeWindow window = new EmployeeWindow {DataContext = vewModel};
            window.Show();
        }
    }
}
