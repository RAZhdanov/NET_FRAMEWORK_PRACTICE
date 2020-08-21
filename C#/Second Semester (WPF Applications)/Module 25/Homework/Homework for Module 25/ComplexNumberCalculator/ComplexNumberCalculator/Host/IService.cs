using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    [ServiceContract]
    interface IService
    {

        [OperationContract]
        Complex Add(Complex a, Complex b);

        [OperationContract]
        Complex Substract(Complex a, Complex b);

        [OperationContract]
        Complex Multiply(Complex a, Complex b);

        [OperationContract]
        [FaultContract(typeof(DivideByZeroException))]
        Complex Divide(Complex a, Complex b);

        

    }
}
