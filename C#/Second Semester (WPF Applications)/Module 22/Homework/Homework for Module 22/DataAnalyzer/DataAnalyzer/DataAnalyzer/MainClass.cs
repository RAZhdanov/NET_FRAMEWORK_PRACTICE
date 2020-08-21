using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace DataAnalyzer
{
    public class MainClass
    {
        

        static void Main()
        {
            string cmdText =

                         @"SELECT
                         Orders.ShipCity AS City,
                         Orders.ShipCountry AS Country,
                         Orders.Freight AS Freight FROM Orders;"
                        ;
                        

            string connectionString = ConfigurationManager.ConnectionStrings["sqlProvider"].ConnectionString;

            List<Order> list = new List<Order>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            City = reader["City"] as string,
                            Country = reader["Country"] as string,
                            Freight = reader["Freight"] as decimal?

                        };
                        list.Add(order);

                    }

                }

                connection.Close();
            }

           

            Console.WriteLine("Number of countries: " + list.Select(o => o.Country).Distinct().Count());

            Console.WriteLine("\nNumber of cities in every country, where some good has been delivered:\n");

            foreach (IGrouping<string,Order> item in list.GroupBy(o=>o.Country))
            {                
                Console.WriteLine(item.Key + " - " + item.Select(o => o.City).Distinct().Count());
            }

            Console.WriteLine("\nOverall transportation cost of all goods in USA: " + list.Where(o => o.Country == "USA").Sum(o => o.Freight) + "\n");

            Console.WriteLine("Overall transportation cost of all goods with the cost less than 100$: "+ list.Where(o => o.Freight < 100).Sum(o => o.Freight) +"\n");

            Console.Write("Average transportation cost of all goods being delivered in Germany: ");

            decimal? average = list.Where(o => o.Country == "Germany").Average(o => o.Freight);           

            if (average != null)
            {
                Console.WriteLine(Math.Round(average.Value, 2));
            }



            Console.ReadKey();
        }
    }
}
