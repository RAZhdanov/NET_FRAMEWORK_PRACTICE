using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CalculatorService
{
    public class MainClass
    {

        public static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(Service));
            host.Opening += (sender, arguments) => Console.WriteLine("Opening..");
            host.Opened += (sender, arguments) => Console.WriteLine("Opened");
            host.Closing += (sender, arguments) => Console.WriteLine("Closing..");
            host.Closed += (sender, arguments) => Console.WriteLine("Closed");

            host.Open();          
            Console.ReadKey();
            host.Close();
            Console.ReadKey();
            
        }

        
    }
}
