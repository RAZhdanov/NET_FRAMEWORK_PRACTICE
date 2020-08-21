using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Module_11
{
    [Serializable]
    public class Person
    {
        // Конструктор без параметров - обязательное требование для XML сериализации
        public Person() { }

        public Person(string Name)
        {
            FirstName = Name;
        }

        public Person(string _firstName, string _lastName, string _patronymic, string _phoneNumber, string _address)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Patronymic = _patronymic;
            PhoneNumber = _phoneNumber;
            Address = _address;
        }
        //Имя
        [XmlAttribute]
        public string FirstName { get; set; }

        //Фамилия
        [XmlAttribute]
        public string LastName { get; set; }

        //Отчество
        [XmlAttribute]
        public string Patronymic { get; set; }

        //Номер телефона
        [XmlAttribute]
        public string PhoneNumber { get; set; }

        //Адрес
        [XmlAttribute]
        public string Address { get; set; }


        public override string ToString()
        {
            return $"FirstName: {FirstName}\nLastName: {LastName}\nPatronymic: {Patronymic}\nPhoneNumber: {PhoneNumber}\nAddress: {Address}";
        }


    }
}
