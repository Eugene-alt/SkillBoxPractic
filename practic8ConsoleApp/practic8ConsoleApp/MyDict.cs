using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace practic8ConsoleApp
{
    internal class MyDict
    {
        private Dictionary<string, string> dictionary;

        #region Методы

        #region DictLife
        /// <summary>
        /// Пользователь заполняет словарь, пока не введет пустую строку
        /// </summary>
        private void DictLife()
        {
            bool isFill = true;
            bool isCheck = true;
            Console.WriteLine("Заполнение словаря-------------------------------");
            while (isFill)
            {
                isFill = AddNewNumber();
            }
            Console.WriteLine("Конец заполнения---------------------------------");
            Console.WriteLine();

            Console.WriteLine("Ввод номеров для получения ФИО владельцев--------");
            while (isCheck)
            {
                isCheck = GetFio();
            }
            Console.WriteLine("Конец ввода номеров------------------------------");
            Console.WriteLine();

            Console.WriteLine("Ну и бонусом держи информацию о всех номерах");
            Print();
        }
        #endregion


        #region Print
        public void Print()
        {
            foreach(KeyValuePair<string, string> pair in dictionary)
            {
                Console.WriteLine("Номер: {0}, ФИО владельца: {1}", pair.Key, pair.Value);
            }
        }
        #endregion


        #region GetFio
        public bool GetFio()
        {
            string key;

            Console.Write("Введи ключ >>> ") ;
            key = Console.ReadLine();
            if (String.IsNullOrEmpty(key)) { return false; } else { key.Trim(); }

            if(dictionary.TryGetValue(key, out var value))
            {
                Console.WriteLine($"ФИО: {dictionary[key]}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Не знаю таких номеров") ;
                Console.WriteLine();
            }
            return true;
        }
        #endregion


        #region AddNewNumber
        /// <summary>
        /// Добавляет в словарь новый номер и его владельца
        /// </summary>
        /// <returns>Возвращает false если пользователь ввел пустую строку</returns>
        public bool AddNewNumber()
        {
            Console.Write("Введи номер телефона >>> ");
            string number = Console.ReadLine();
            if (String.IsNullOrEmpty(number)) { return false; }

            Console.Write("Введи ФИО владельца номера >>> ");
            string fio = Console.ReadLine();
            if (String.IsNullOrEmpty(fio)) { return false; }

            Console.WriteLine();

            dictionary.Add(number.Trim(), fio.Trim());
            return true;
        }
        #endregion

        #endregion


        #region Конструкторы
        public MyDict()
        {
            dictionary = new Dictionary<string, string>();
            DictLife();
        }
        #endregion

    }
}
