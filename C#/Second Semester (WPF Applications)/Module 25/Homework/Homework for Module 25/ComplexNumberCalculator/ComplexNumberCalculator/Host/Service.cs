using System;
using System.ServiceModel;

namespace CalculatorService
{

    public class Service : IService
    {
        

        public Complex Add(Complex a, Complex b)
        {
            return a + b;
        }
   
        public Complex Substract(Complex a, Complex b)
        {
            return a - b;
        }

        public Complex Multiply(Complex a, Complex b)
        {
            return a * b;
        }

        public Complex Divide(Complex a, Complex b)
        {
            try
            {
                return  a / b;
            }
            catch(DivideByZeroException)
            {
                DivideByZeroException f = new DivideByZeroException();
                throw new FaultException<DivideByZeroException>(f, new FaultReason("Dividing By Zero Error!"));
                
            }

           
        }
    }
}