using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace SQLDataEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private DataSet dataSet;
        private SqlDataAdapter adapter;
        DataTable table;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataSet = new DataSet("dataSet");
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["sqlProvider"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ConnectionString);

            //SELECT QUERY
            string strSelectQuery = 
                @"SELECT
                  EmployeeID,
                  LastName,
                  FirstName,
                  Title,
                  TitleOfCourtesy,
                  BirthDate,
                  HireDate,
                  Address,
                  City,
                  Region,
                  PostalCode,
                  Country,
                  HomePhone,
                  Extension,
                  Photo,
                  Notes,
                  ReportsTo,
                  PhotoPath FROM Employees";

            adapter = new SqlDataAdapter(strSelectQuery, connection);


            table = new DataTable("Employees");
            adapter.Fill(table);
            dataSet.Tables.Add(table);

            //PREPARING INSERT COMMAND
            SqlCommand cmd = new SqlCommand();
            adapter.InsertCommand = connection.CreateCommand();

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.DeleteCommand = builder.GetDeleteCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.InsertCommand = builder.GetInsertCommand();


            DataContext = dataSet;

        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            table.RejectChanges();
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                table.Clear();
                adapter.Fill(table);                
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                adapter.Update(table);

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            table.Dispose();
            adapter.Dispose();
            dataSet.Dispose();
        }
    }
}

