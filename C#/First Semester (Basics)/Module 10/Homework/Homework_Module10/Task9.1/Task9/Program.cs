using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Task9
{
    /*
     * Задача 9.1. Анализ текстового файла (Работа с текстовыми файлами, строками, регулярными выражениями)  
     * Имеется файл, содержащий информацию о сотрудниках, в формате CSV. 
     * Т.е. первой строкой идет строка заголовков (она содержит заголовки к полям) – name, email, phone. 
     * Дальше идут данные сотрудников. 
     * При этом строковые данные взяты в кавычки, а отдельные элементы разделены знаками табуляции.  
     * Программа должна считать файл (он задается в качестве параметров командной строки) 
     * и проверить на правильность электронные адреса и телефоны. 
     * Программа также должна выдать общее количество сотрудников, а также количество правильных и неправильных электронных адресов и телефонов. 
 
        Примечание: для обработки строк (очистки их от кавычек, разделения по табуляции и т.д.) можно использовать методы класса string. Метод Trim() убирает определенные символы с концов строки, а метод Split() разделяет строку по заданному символу (например, табуляции). Корректность можно проверять либо руками (не лучший вариант), либо при помощи регулярных выражений. 
 
     */
    
    class Program
    {
        static void PrintList(List<string> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (string str in list)
                {
                    Console.WriteLine(str);
                }
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            foreach(string str_file in args)
            {
                string fileName = str_file;

                var dstEncoding = Encoding.GetEncoding(1251);


                List<string> list_of_correct_emails = new List<string>();
                List<string> list_of_incorrect_emails = new List<string>();

                List<string> list_of_correct_phones = new List<string>();
                List<string> list_of_incorrect_phones = new List<string>();

                string line = null;
                using (StreamReader sr2 = new StreamReader(fileName, dstEncoding))
                {
                    //string between quotes + nested quotes
                    //("([^"]|"")*")
                    string pattern_for_quote = "(\"([^\"]|\"\")*\")";
                    Regex rx_quotes = new Regex(pattern_for_quote);


                    //email validation
                    //^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$
                    string pattern_for_email_validation = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                    Regex rx_for_emailvalidation = new Regex(pattern_for_email_validation);


                    //match a wide range of international phone number
                    string pattern_for_phonenumber = @"^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$";
                    Regex rx_phonenumber = new Regex(pattern_for_phonenumber);
                    int quantity_of_workers = 0;
                    while (!sr2.EndOfStream)
                    {
                        line = sr2.ReadLine();

                        //Получаем совпадения в экземпляре класса Match
                        Match match = rx_quotes.Match(line);

                        if (match.Success)
                            quantity_of_workers++;


                        while (match.Success)
                        {
                            string name_str = match.Groups[1].Value.Trim('"');

                            //Имя сотрудника
                            match = match.NextMatch();


                            //Электронная почта сотрудника
                            string email_str = match.Groups[1].Value.Trim('"');
                            Match match_email = rx_for_emailvalidation.Match(email_str);
                            if (match_email.Success && email_str.Equals(match_email.Value))
                            {
                                list_of_correct_emails.Add(email_str);
                            }
                            else
                            {
                                list_of_incorrect_emails.Add(email_str);
                            }
                            match = match.NextMatch();


                            //Телефон сотрудника
                            string phone_number_str = match.Groups[1].Value.Trim('"');
                            Match match_phonenumber = rx_phonenumber.Match(phone_number_str);
                            if (match_phonenumber.Success && phone_number_str.Equals(match_phonenumber.Value))
                            {
                                list_of_correct_phones.Add(phone_number_str);
                            }
                            else
                            {
                                list_of_incorrect_phones.Add(phone_number_str);
                            }
                            match = match.NextMatch();

                        }
                    }

                    Console.WriteLine("List of correct emails");
                    PrintList(list_of_correct_emails);

                    Console.WriteLine("List of incorrect emails");
                    PrintList(list_of_incorrect_emails);

                    Console.WriteLine("List of correct phones");
                    PrintList(list_of_correct_phones);

                    Console.WriteLine("List of incorrect phones");
                    PrintList(list_of_incorrect_phones);

                    Console.WriteLine($"quantity of workers: {quantity_of_workers}");


                }
            }
            
        }
    }
}