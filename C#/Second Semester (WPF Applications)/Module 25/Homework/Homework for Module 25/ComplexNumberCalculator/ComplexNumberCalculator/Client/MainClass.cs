using System;
using System.ServiceModel;
using Client.ServiceReference1;



namespace Client
{
    public class MainClass
    {

        public static void Main()
        {
            
            ServiceClient client = new ServiceClient();

         

            Complex a = new Complex { Re = 1, Im = -2 };
            Complex b = new Complex { Re = 3, Im = 4 };
            Complex x = new Complex { Re = 0, Im = 0 };

            
               
                


            try
            {
                Complex c = client.Add(a, b);
                Console.WriteLine($"({a.Print()}) + ({b.Print()}) = {c.Print()}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                Complex c = client.Substract(a, b);
                Console.WriteLine($"({a.Print()}) - ({b.Print()}) = {c.Print()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                Complex c = client.Multiply(a, b);
                Console.WriteLine($"({a.Print()}) * ({b.Print()}) = {c.Print()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                Complex c = client.Divide(a, x);
                Console.WriteLine($"({a.Print()}) / ({x.Print()}) = {c.Print()}");
            }
            catch (FaultException<DivideByZeroException> fault)
            {
                Console.WriteLine(fault.Detail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                Complex c = client.Divide(a, b);
                Console.WriteLine($"({a.Print()}) / ({b.Print()}) = {c.Print()}");
            }
            catch (FaultException<DivideByZeroException> fault)
            {
                Console.WriteLine(fault.Detail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
            
            






            Console.WriteLine();

            Console.ReadKey();
        }

    }
}
