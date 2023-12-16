using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic10ConsoleApp_2
{
    internal class Client
    {
        // Общие для всех клиентов ключи для словаря с записью изменения
        public static string[] keysDict;

        // Статический конструктор
        static Client()
        {
            keysDict =  new string[]{ "dateTime", "dataType", "changeType", "worker" };
        }

        // Данные клиента
        public int id;
        public string name;
        public string surname;
        public string patronimic;
        public string passport;
        public string phoneNumber;
        public List<Dictionary<string, string>> changesList; // Лист словарей изменений

        /// <summary>
        /// Установка Id клиента
        /// </summary>
        private void SetId()
        {
            id = Repository.index++;
        }

        /// <summary>
        /// Перезаписанный метод преобразования клиента в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.id, 10} " +
                $"{this.name,15} " +
                $"{this.surname,15} " +
                $"{this.patronimic,15} " +
                $"{this.passport,15} " +
                $"{this.phoneNumber,20}";
        }

        /// <summary>
        /// Добавляет изменение записи в список изменений
        /// </summary>
        /// <param name="dateTime">Дата и время изменения записи</param>
        /// <param name="dataType">Какие данные изменены</param>
        /// <param name="changeType">Тип изменения</param>
        /// <param name="worker">Работник, совершивший изменение</param>
        public void AddChange(string dateTime, string dataType, string changeType, string worker)
        {
            Dictionary<string, string> oneChangeDict = new Dictionary<string, string>(); // Словарь одного изменения

            oneChangeDict[keysDict[0]] = dateTime;
            oneChangeDict[keysDict[1]] = dataType;
            oneChangeDict[keysDict[2]] = changeType;
            oneChangeDict[keysDict[3]] = worker;

            changesList.Add(oneChangeDict);
        }

        // Конструктор с параметрами
        public Client(string name, string surname, string patronimic, string passport, string phoneNumber)
        {
            this.name = name;
            this.surname = surname;
            this.patronimic = patronimic;
            this.passport = passport;
            this.phoneNumber = phoneNumber;
            this.changesList = new List<Dictionary<string, string>>();
            SetId();
        }
        // Конструктор по умолчанию
        public Client():
            this("Evgen","Panuev","Vasilevich","5323 534775", "89325346")
        { }
    }
}
