using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic8ConsoleApp
{
    public class Person
    {
        #region Поля
        //string fio;
        //string street;
        //uint houseNumber;
        //uint flatNumber;
        //string mobilePhone;
        //string flatPhone;
        #endregion


        #region Авто-свойства
        public string Fio { get; private set; }
        public string Street { get; private set; }
        public uint HouseNumber { get; private set; }
        public uint FlatNumber { get; private set; }
        public string MobilePhone { get; private set; }
        public string FlatPhone { get; private set; }
        #endregion


        #region Методы
        public void Print()
        {
            Console.WriteLine("ФИО:{0}\n" +
                    "Улица:{1}\n" +
                    "Номер дома:{2}\n" +
                    "Номер квартиры{3}\n" +
                    "Мобильный телефон:{4}\n" +
                    "Домашний телефон:{5}\n",
                    Fio, Street, HouseNumber, FlatNumber, MobilePhone, FlatPhone);
        }
        #endregion


        #region Конструкторы
        public Person(string fio, string street, uint houseNumber, uint flatNumber, string mobilePhone, string flatPhone)
        {
            this.Fio = fio;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.FlatNumber = flatNumber;
            this.MobilePhone = mobilePhone;
            this.FlatPhone = flatPhone;
        }
        public Person(string fio, string street, uint houseNumber, uint flatNumber, string mobilePhone):
            this(fio,street,houseNumber,flatNumber,mobilePhone,"-")
        { 
        }
        public Person(string fio, string street, uint houseNumber, uint flatNumber) :
            this(fio, street, houseNumber, flatNumber, "-", "-")
        {
        }
        public Person(string fio, string street, uint houseNumber) :
            this(fio, street, houseNumber, 0, "-", "-")
        {
        }
        public Person(string fio, string street) :
            this(fio, street, 0, 0, "-", "-")
        {
        }
        public Person(string fio) :
            this(fio, "-", 0, 0, "-", "-")
        {
        }
        public Person():
           this("-", "-", 0, 0, "-", "-")
        {
        }
        #endregion

    }
}
