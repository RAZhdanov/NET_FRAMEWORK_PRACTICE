using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComplexApplication
{
    //http://www.msudotnet.ru/Lectures/Lecture2/Task2.pdf


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task #1");

            //����� ���������� ����������� ������� ��������� ����������� ����� �� ������ � ��������� (��������, static ����� ��������)
            CComplex myCmplx = CComplex.GetComplexValueThroughModulusAndArgument(8.0622, -0.51914); //������ ���������� �������� 7 - 4i


            //������������ �������� ���������� �� ������������� ����� � �����������
            CComplex a1 = 650.4;
            CComplex b1 = new CComplex(650, -8);

            //������������ ������ ���������� � ������������ �����
            double value = (double)b1;

            //������������ ����������������� �������������� ��������� ���������
            if (a1 == b1)
            {
                Console.WriteLine("equal!");
            }
            else
                Console.WriteLine("not equal!");

            //������������ ���������� ���������� ������������ �����
            Console.WriteLine(b1);

            //�� �����, ����� ��� ������, �� ��� � ������-�� ����� ������� ���-���� ���� ��������
            Console.WriteLine("HashCodes of complex variables {0} and {1}", a1.GetHashCode(), b1.GetHashCode());


            //� ������ ������� �2. ��� �������, ��� ����������� ��� �������.
            Console.WriteLine("Task #2");
            Body3D [] body3D = { new CSphere(25.3), new CTetrahedron(46.5), new CParallelepipedon(36.1,42.1,38.1) };
            foreach(var param in body3D)
            {
                Console.WriteLine(param);
            }
        }
    }
}
