using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace practic8ConsoleApp
{
    internal class RepositoryXml
    {
        private List<Person> persons;
        private string path;

        #region Print
        private void Print()
        {
            Console.WriteLine("Вывод всех записанных контактов:");
            foreach(Person person in persons)
            {
                person.Print();
                Console.WriteLine();
            }
        }
        #endregion

        #region Serialize
        private void Serialize(string Path, List<Person> concretePersons)
        {
            Console.WriteLine("Начало сериализации");

            XElement personsElement = new XElement("Persons");

            foreach (Person person in persons)
            {
                XElement personElement = new XElement("Person");
                XElement adressElement = new XElement("Adress");
                XElement streetElement = new XElement("Street");
                XElement houseNumberElement = new XElement("HouseNumber");
                XElement flatNumberElement = new XElement("FlatNumber");
                XElement phonesElement = new XElement("PhonesNumber");
                XElement mobilePhoneElement = new XElement("MobilePhone");
                XElement flatPhoneElement = new XElement("FlatPhone");
                XAttribute nameAttributePerson = new XAttribute("name", "NoName");

                // Установка аттрибута элементу Person
                personElement.Add(nameAttributePerson);

                // Установка значений элементам Adress
                streetElement.Value = person.Street;
                houseNumberElement.Value = person.HouseNumber.ToString();
                flatNumberElement.Value = person.FlatNumber.ToString();

                // Установка значений элементам Phones
                mobilePhoneElement.Value = person.MobilePhone.ToString();
                flatPhoneElement.Value = person.FlatNumber.ToString();

                // Установка значений аттрибута name элемента Person
                nameAttributePerson.Value = person.Fio;


                // Установка элементов Adress
                adressElement.Add(streetElement);
                adressElement.Add(houseNumberElement);
                adressElement.Add(flatNumberElement);

                // Установка элементов Phones
                phonesElement.Add(mobilePhoneElement);
                phonesElement.Add(flatPhoneElement);

                // Установка элементов Person
                personElement.Add(adressElement);
                personElement.Add(phonesElement);

                // Установка элементов Persons
                personsElement.Add(personElement);

            }

            personsElement.Save(Path);

            Console.WriteLine("Сериализация завершена");
        }
        #endregion

        #region Deserialize
        private void Deserialize(string Path)
        {
            Console.WriteLine("Начало десериализации");
            string xml = File.ReadAllText(Path);
            var doc = XDocument.Parse(xml).Descendants("Person").ToList() ;

            foreach ( var element in doc )
            {
                Person person;
                XAttribute nameAttribute = element.Attribute("name");
                XElement adress = element.Element("Adress");
                XElement phones = element.Element("PhonesNumber");
                XElement streetElement = adress.Element("Street");
                XElement houseNumberElement = adress.Element("HouseNumber");
                XElement flatNumberElement = adress.Element("FlatNumber");
                XElement mobilePhoneElement = phones.Element("MobilePhone");
                XElement flatPhoneElement = phones.Element("FlatPhone");

                person = new Person(nameAttribute.Value,
                    streetElement.Value,
                    Convert.ToUInt32(houseNumberElement.Value),
                    Convert.ToUInt32(flatNumberElement.Value),
                    mobilePhoneElement.Value,
                    flatPhoneElement.Value);

                persons.Add(person);

            }

            Console.WriteLine("Десериализация завершена") ;
            Console.WriteLine();
        }
        #endregion

        #region AddNewPerson
        /// <summary>
        /// Добавление нового контакта
        /// </summary>
        /// <returns>Возвращает ложь, если введена хоть одна пустая строка</returns>
        private bool AddNewPerson()
        {
            Person person;

            string fio;
            string street;
            uint houseNumber;
            uint flatNumber;
            string mobilePhone;
            string flatPhone;

            string userAnswer;

            Console.Write("Введите ФИО >>> ");
            userAnswer = Console.ReadLine().Trim();
            if(String.IsNullOrEmpty(userAnswer)) { return false; } else { fio = userAnswer; }
            Console.Write("Введите Улицу >>> ");
            userAnswer = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(userAnswer)) { return false; } else {street = userAnswer; }
            Console.Write("Введите Номер дома >>> ");
            userAnswer = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(userAnswer)) { return false; } else { houseNumber = Convert.ToUInt32(userAnswer); }
            Console.Write("Введите Номер квартиры >>> ");
            userAnswer = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(userAnswer)) { return false; } else { flatNumber = Convert.ToUInt32(userAnswer); }
            Console.Write("Введите Номер мобильного телефона >>> ");
            userAnswer = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(userAnswer)) { return false; } else { mobilePhone = userAnswer; }
            Console.Write("Введите Номер домашнего телефона >>> ");
            userAnswer = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(userAnswer)) { return false; } else { flatPhone = userAnswer; }

            person = new Person(fio, street, houseNumber, flatNumber, mobilePhone, flatPhone);
            persons.Add(person);

            return true;
        }
        #endregion

        #region RepositoryLife
        /// <summary>
        /// Жизненный цикл репозитория
        /// </summary>
        private void RepositoryLife(string Path)
        {
            Deserialize(Path);
            Print();
            bool isFill = true;
            while (isFill)
            {
                Console.WriteLine("Заполните данные о новом контакте");
                isFill = AddNewPerson();
                Console.WriteLine("Заполнение завершено");
                Console.WriteLine();
            }
            Print();
            Serialize(Path, persons);
        }
        #endregion

        #region Конструктор
        public RepositoryXml(string path)
        {
            persons = new List<Person>();
            this.path = path;
            RepositoryLife(path);
        }
        #endregion
    }
}
