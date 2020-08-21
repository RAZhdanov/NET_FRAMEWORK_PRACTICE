using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.Linq.SqlClient;

namespace Module_11
{
    
    class Program
    {
        /*
         * Задание 11. База сотрудников предприятия (Файлы, сериализация) 
         * 
         * Вы IT специалист некоего предприятия.
         * 
         * Специалист отдела кадров попросил вас написать программу, позволяющую быстро ИСКАТЬ информацию
         * о сотруднике по части его данных. 
         * 
         * Например, по фамилии, имени, отчеству, номеру телефона или адресу сотрудника. 
         * 
         * Необходимо реализовать такую программу.
         * 
         * Программа должна позволять ВВЕСТИ данные нового сотрудника.
         * 
         * Должна предоставлять ПОИСК по фамилии, имени, отчеству, номеру телефона или адресу сотрудника:
         * 
         * выводить полную информацию о найденных сотрудниках. 
         * 
         * Допускается реализация единого поиска сразу по всем данным о сотруднике. 
         * 
         * Информация о сотрудниках должна сохраняться между запусками программы.
         * 
         * Примечание: для удобства работы с сохраненными данными о сотрудниках удобно использовать сериализацию. 
         * 
         */

        public enum ETypeOfOperation
        {
            ETypeOfOperation_FindInformation = 1,
            ETypeOfOperation_AddInformation,
            ETypeOfOperation_PrintInfo,
            ETypeOfOperation_Exit
        }
        private static readonly string VectorArrayXmlFileName = Path.Combine(Environment.CurrentDirectory, "PersonsArrayStore.xml");


        static void Main(string[] args)
        {
            
            List<Person> persons = null;
            IProvider<List<Person>> vectorListProvider = new PersonListProvider(VectorArrayXmlFileName);

            if (File.Exists(VectorArrayXmlFileName)) //Попытка десериализации
            {
                try
                {
                    persons = Deserialization(vectorListProvider);
                }
                catch(System.InvalidOperationException e)
                {
                    Console.WriteLine("File is corrupted");
                }
            }
            else
            {
                persons = new List<Person>();
                //Данные по умолчанию
                persons.Add(new Person("Мария", "Жданова", "Васильевна", "89192226344", "ул.Шахновича"));
                persons.Add(new Person("Эдуард", "Пчелкин", "Андреевич", "89162228564", "ул. Книповича"));
                persons.Add(new Person("Рамзес", "Жданов", "Александрович", "89197298834", "ул.Ленина"));
                persons.Add(new Person("Андрей", "Сорокин", "Сорокович", "89142328335", "ул. Книповича"));
                persons.Add(new Person("Мария", "Антуанетова", "Антуанетовна", "89194626344", "ул.Шахновича"));
                Serialization(vectorListProvider, persons);
            }

            int int_result = 0;
            ETypeOfOperation type_of_information = (ETypeOfOperation)int_result;
            string first_name, last_name, patronimic_name, phone_number, address;

            while (type_of_information != ETypeOfOperation.ETypeOfOperation_Exit)
            {
                Console.WriteLine("Выберете тип операции: ");
                Console.WriteLine("Поиск по фамилии, имени, отчеству, номеру телефона или адресу сотрудника [1]");
                Console.WriteLine("Добавить нового сотрудника [2]");
                Console.WriteLine("Вывести на экран все имеющиеся данные [3]");
                Console.WriteLine("Выйти из программы [4]");

                int.TryParse(Console.ReadLine(), out int_result);
                type_of_information = (ETypeOfOperation)int_result;
                switch (type_of_information)
                {
                    case ETypeOfOperation.ETypeOfOperation_FindInformation:
                        {
                            Console.WriteLine("Произвести единый поиск по всем параметрам [1] или по отдельности [2]? ");
                            IEnumerable<Person> result = null;
                            int.TryParse(Console.ReadLine(), out int_result);
                            if (int_result == 1)
                            {
                               
                                FillInfo(out first_name, out last_name, out patronimic_name, out phone_number, out address);

                                result = persons.Where(x => 

                                    x.FirstName.Contains(first_name) &&
                                    x.LastName.Contains(last_name) &&
                                    x.Patronymic.Contains(patronimic_name) &&
                                    x.PhoneNumber.Contains(phone_number) &&
                                    x.Address.Contains(address)
                                );
                            }
                            else
                            {
                                Console.WriteLine("По какому параметру производить поиск? ");
                                Console.WriteLine("По имени [1].\nпо фамилии [2].\nпо отчеству [3].\nпо номеру телефона [4].\nпо адресу [5]. ");

                                int parameter = 0;
                                int.TryParse(Console.ReadLine(), out parameter);
                                string str_parameter;
                                switch (parameter)
                                {
                                    case 1:
                                        str_parameter = Console.ReadLine();
                                        result = persons.Where(x => x.FirstName.Contains(str_parameter));
                                        break;
                                    case 2:
                                        str_parameter = Console.ReadLine();
                                        result = persons.Where(x => x.LastName.Contains(str_parameter));
                                        break;
                                    case 3:
                                        str_parameter = Console.ReadLine();
                                        result = persons.Where(x => x.Patronymic.Contains(str_parameter));
                                        break;
                                    case 4:
                                        str_parameter = Console.ReadLine();
                                        result = persons.Where(x => x.PhoneNumber.Contains(str_parameter));
                                        break;
                                    case 5:
                                        str_parameter = Console.ReadLine();
                                        result = persons.Where(x => x.Address.Contains(str_parameter));
                                        break;
                                    default:
                                        return;
                                }
                            }

                            if (result != null)
                            {
                                Console.WriteLine("Найдены следующие элементы:");
                                foreach (Person var in result)
                                {
                                    Console.WriteLine(var + "\n");
                                }
                            }
                        }
                        break;

                    case ETypeOfOperation.ETypeOfOperation_AddInformation:
                        FillInfo(out first_name, out last_name, out patronimic_name, out phone_number, out address);
                        persons.Add(new Person(first_name, last_name, patronimic_name, phone_number, address));
                        Serialization(vectorListProvider, persons);
                        break;

                    case ETypeOfOperation.ETypeOfOperation_PrintInfo:
                        foreach (Person var in persons)
                        {
                            Console.WriteLine(var + "\n");
                        }
                        break;

                    default:
                        break;
                }
            }
        }

     

        private static void Serialization<T>(IProvider<T> provider, T value)
        {
            //Сериализация объекта
            provider.Save(value);
        }
        private static void Serialization<T>(IProvider<T[]> provider, T[] value)
        {
            //Сериализация объекта
            provider.Save(value);
        }

        private static T Deserialization<T>(IProvider<T> provider)
        {
            //Десериализация объекта
            return provider.Load();
        }
        private static T[] Deserialization<T>(IProvider<T[]> provider)
        {
            //Десериализация объекта
            return provider.Load();
        }

        private static void FillInfo(
            out string first_name, 
            out string last_name, 
            out string patronimic_name, 
            out string phone_number, 
            out string address)
        {
            //Ввод данных нового сотрудника
            Console.WriteLine("Enter first name: ");
            first_name = Console.ReadLine();

            Console.WriteLine("Enter last name: ");
            last_name = Console.ReadLine();

            Console.WriteLine("Enter patronimic name: ");
            patronimic_name = Console.ReadLine();

            Console.WriteLine("Enter phone number: ");
            phone_number = Console.ReadLine();

            Console.WriteLine("Enter address: ");
            address = Console.ReadLine();
        }

    }
}
