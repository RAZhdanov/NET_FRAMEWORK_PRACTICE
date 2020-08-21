using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                //System.Reflection.FieldInfo[] fieldInfo = myType.GetFields();
                //Assembly executingAssembly = Assembly.GetExecutingAssembly();
                //Type type = executingAssembly.GetType("ConsoleApp1.Program");
                //object instance = Activator.CreateInstance(type);
                //MemberInfo[] getMembers = type.GetMembers();
                //var typeofvarible = getMembers[0].GetType();

                //class.F
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //string[] methodParameter = new string[] { "0" };
            //string fullName = (string)getFullName.Invoke(instance, methodParameter);
        }
    }
}
